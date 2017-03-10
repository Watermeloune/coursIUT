__author__ = 'Nersesian Robert, Guillaume Baratte, Kriss Garel'


import time
import pygame
from pygame.locals import *
from random import randint

pygame.init()

#création de la fenêtre
fenetre = pygame.display.set_mode((400, 550))
pygame.display.set_caption("Priest vs Aliens")
horloge = pygame.time.Clock()
white = (255, 255, 255)

                                        #############################
                                        #   FONCTIONS SECONDAIRES   #
                                        #############################



#Foncion pour vérifier si le jouer a perdu lorsque la plateforme atteint sa hauteur
def verif_lose(plat_x,char_x, score):
    if plat_x-char_x <=0 and plat_x-char_x>=-50:
        print ("score=,", score)
        return True
    else:
        return False


#Fonction pour empêcher le jouer de sortir de l'écran
def verif_bord(char_x):
    if char_x < 0:
        return 0
    elif char_x >350:
        return 350
    elif char_x>=0 and char_x <=350 :
        return char_x


#Fonction pour faire apparaître le score
def score(compte):
    police = pygame.font.Font("BradBunR.ttf", 16)
    texte = police.render("score:" + str(compte), True, white)
    fenetre.blit(texte, [10, 460])


#Fonction pour savoir si le joueur appuie sur une touche
def rejouOuQuitte():
    for event in pygame.event.get([pygame.QUIT, pygame.KEYUP, pygame.KEYDOWN]):
        if event.type == pygame.QUIT:
            pygame.quit()
            quit()
        elif event.type == pygame.KEYUP:  # Sinon le jeu repart lorsque l'on lache la touche
            continue
        return event.key
    return None


#Création de la police d'écriture
def crea_texte_obj(texte, Police):
    textesurface = Police.render(texte, True, white)
    return textesurface, textesurface.get_rect()


#Affichage d'un texte après avoir perdu + bloquer le jeu jusqu'à qu'une touche soit appuyé
def Affichage(texte):
    GOTexte = pygame.font.Font('BradBunR.ttf', 150)
    petitTexte = pygame.font.Font('BradBunR.ttf', 20)

    GOTexteSurf, GOTexteRect = crea_texte_obj(texte, GOTexte)
    GOTexteRect.center = 400 / 2, ((550 / 2) - 50)
    fenetre.blit(GOTexteSurf, GOTexteRect)

    petitTexteSurf, petitTexteRect = crea_texte_obj("Appuyer sur une touche pour continuer", petitTexte)
    petitTexteRect.center = 400 / 2, ((550 / 2) + 50)
    fenetre.blit(petitTexteSurf, petitTexteRect)

    pygame.display.update()


    while rejouOuQuitte() == None:
        horloge.tick()

    main()



                    #####################
                    #   FONCTION MAIN   #
                    #####################

def main ():
    compte = 0

    #
    x1 = 0
    y1 = 0

    x2 = 5*50
    y2 = 3*50

    x3 = 50
    y3 = 6*50




    #Ouverture de la fenêtre Pygame

    fenetre = pygame.display.set_mode((400, 500))


    #Chargement et collage du fond

    fond = pygame.image.load("background.jpg").convert()
    fenetre.blit(fond, (0,0))


    #Chargement du personnage

    perso = pygame.image.load("Bonhomme3.jpg").convert_alpha()
    position_perso = perso.get_rect()
    position_perso.center = 175,415


    #chargement des ovnis

    plateform1 = pygame.image.load("sv.png").convert_alpha()

    position_plateform1 = plateform1.get_rect()
    position_plateform1.center = x1-25, y1-25  #on enlève la moitié de la largeur et de la longueur du personnage car
                                               # la position est défini par le centre avec la méthode ".center"


    plateform2 = pygame.image.load("sv.png").convert_alpha()
    position_plateform2 = plateform2.get_rect()
    position_plateform2.center = x2-25,y2-25

    plateform3 = pygame.image.load("sv.png").convert_alpha()
    position_plateform3 = plateform3.get_rect()
    position_plateform3.center = x3-25,y3-25
    #fenetre.blit(plateform, position_plateform)



    #Rafraîchissement de l'écran

    pygame.display.flip()


    #BOUCLE D'EVENEMENTS

    gameover = False

    while gameover==False:

        for event in pygame.event.get():    #Attente des événements


            if event.type == QUIT:          #permet au joueur de quitter en pleine partie
                quit()                      #

            if event.type == KEYDOWN:                               #
                if event.key == K_LEFT:                             #
                    position_perso = position_perso.move(-50,0)     # Mouvement du personnage
                if event.key == K_RIGHT:                            #
                    position_perso = position_perso.move(50,0)      #


        pygame.time.Clock().tick(30)    #limitation à 30 ips

        y1 = y1+25                      #
        y2 = y2+25                      #Aumgentation des ordonnées des ovnis de 25
        y3 = y3+25                      #

        time.sleep(0.025)     #pause du programme pendant 25 ms pour éviter que le jeu soit injouable


        #Lorsque les ovnis atteignent la hauteur du personnage
        if y1 >= 400:

            gameover = verif_lose(x1,position_perso[0], score) #
            if gameover == True:                               # si le joueur touche l'ovni, lancer la fonction affichage
                Affichage("Failed")                            #

            x1 = 50*randint(0,6)                               # l'ovni réaparaît en haut au hasard
            y1 = 0
                                                         #
        elif y2>=400:

            gameover = verif_lose(x2,position_perso[0],compte)
            if gameover == True:
                Affichage("Failed")

            x2 = 50*randint(0,6)
            y2 = 0

        elif y3 >= 400:
            gameover = verif_lose(x3,position_perso[0],compte)
            if gameover == True:
                Affichage("Failed")

            x3 = 50*randint(0,6)
            y3 = 0


        #augmentation du score et affichage
        compte = compte +1
        score(compte)

        #Re-collage
        position_perso[0] = verif_bord(position_perso[0])
        fenetre.blit(fond, (0,0))
        score(compte)
        fenetre.blit(perso, position_perso)
        fenetre.blit(plateform1, (x1,y1))
        fenetre.blit(plateform2, (x2,y2))
        fenetre.blit(plateform3, (x3,y3))




        #Rafraichissement

        pygame.display.flip()


#lancement de la fonction main pour commencer à jouer au jeu
main()