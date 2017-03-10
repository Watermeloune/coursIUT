using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Resonance.Core;

namespace Resonance.Niveaux
{
    class Menu_Latéral
    // Compléter les attributs
    
    {
        public static int Nb_cases_par_lignes = 4;
        public static int Nb_lignes = 10;
        public static int X_inférieur_Cases_menu;
        public static int Y_inférieur_Cases_menu;
        public static int X_supérieur_Cases_menu;
        public static int Y_supérieur_Cases_menu;
        public Case[] Liste_Bloc;
        public Case[] Liste_Mur;
        public Case[] Liste_Objet;
        public Case[] Liste_Ennemi;
        public Case[] Liste_PNJ;
        public Case Bloc_Null;

        public static int marge_intérieur = 20;
        public static int intervalle = 10;
        public static int Width_Bouton = 40;
        public Bouton_Liste[] Boutons;

        public GameObject panneau_latéral;

        public Case[] ChargerListe(String Path, Case.Type type)
        {
            int nb_lignes = Editeur.Nombre_lignes_fichier(Path);
            StreamReader SR = new StreamReader(String.Concat(Niveau.Root, Path));
            String ligne;
            Case[] liste;
            if (type == Case.Type.Objet)
                liste = new Case[nb_lignes];
            else
                liste = new Case[nb_lignes+1];
            for (int i = 0; i < nb_lignes; i++)
            {
                ligne = SR.ReadLine();
                int identifiant = int.Parse(ligne.Substring(0, 3));
                liste[i] = new Case(identifiant, type, new Vector2(panneau_latéral.Position.X + marge_intérieur + (Case.Width + intervalle) * (i % Nb_cases_par_lignes), Boutons[0].Position.Y+Width_Bouton+marge_intérieur+(Case.Height+intervalle*4)*(i/Nb_cases_par_lignes)));
            }
            if(type != Case.Type.Objet)
                liste[nb_lignes] = new Case(0, Case.Type.Ajout, new Vector2(panneau_latéral.Position.X + marge_intérieur + (Case.Width + intervalle) * (nb_lignes % Nb_cases_par_lignes), Boutons[0].Position.Y + Width_Bouton + marge_intérieur + (Case.Height + intervalle * 4) * (nb_lignes / Nb_cases_par_lignes)));
            return liste;
        }
        public static void Initialiser_Proportions_CasesMenu(Menu_Latéral menu)
        {
            X_inférieur_Cases_menu = (int)menu.panneau_latéral.Position.X + marge_intérieur;
            Y_inférieur_Cases_menu = (int)menu.Boutons[0].Position.Y + Width_Bouton + marge_intérieur;
            X_supérieur_Cases_menu = (int)menu.panneau_latéral.Position.X + marge_intérieur + (Case.Width + intervalle) * (Nb_cases_par_lignes);
            Y_supérieur_Cases_menu = (int)menu.Boutons[0].Position.Y + Width_Bouton + marge_intérieur + (Case.Height + intervalle * 4) * (Nb_lignes);
        }
        public void ChargerTextureListes(Microsoft.Xna.Framework.Content.ContentManager content)
        //Charge les sprites de chaque bloc de la map
        {
            panneau_latéral.Texture = content.Load<Texture2D>("Editeur - Panneau latéral droit");
            Boutons[0].Texture = content.Load<Texture2D>("bouton_liste_bloc");
            Boutons[1].Texture = content.Load<Texture2D>("bouton_liste_mur");
            Boutons[2].Texture = content.Load<Texture2D>("bouton_liste_objet");
            Boutons[3].Texture = content.Load<Texture2D>("bouton_liste_ennemi");
            Boutons[4].Texture = content.Load<Texture2D>("bouton_liste_PNJ");
            foreach(Bouton_Liste bouton in Boutons)
            {
                bouton.longueur = Width_Bouton + intervalle/2;
                bouton.largeur = Width_Bouton + intervalle/2;
                bouton.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_bouton");
            }
            foreach(Case element in Liste_Bloc)
            {
                if (element.identifiant == 0)
                {
                    element.Texture = content.Load<Texture2D>("Ajout");
                }
                else
                {
                    element.Texture = content.Load<Texture2D>(String.Concat("Blocs\\", (Niveau.getNom(element.identifiant, "BD_Blocs.txt"))));
                    element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                }
            }

            foreach (Case element in Liste_Mur)
            {

                if (element.identifiant == 0)
                {
                    element.Texture = content.Load<Texture2D>("Ajout");
                }
                else
                {
                    element.Texture = content.Load<Texture2D>(String.Concat("Murs\\", (Niveau.getNom(element.identifiant, "BD_Murs.txt"))));
                    element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                }

            }
            foreach (Case element in Liste_Objet)
            {
                element.Texture = content.Load<Texture2D>(String.Concat("Objets\\", (Niveau.getNom(element.identifiant, "BD_Objets.txt"))));
                element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
            }
            foreach (Case element in Liste_Ennemi)
            {
                if (element.identifiant == 0)
                {
                    element.Texture = content.Load<Texture2D>("Ajout");
                }
                else
                {
                    element.Texture = content.Load<Texture2D>(String.Concat("Ennemis\\", Niveau.getNom(element.identifiant, "BD_Ennemis.txt"), "_Bas_Stat"));
                    element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                }
            }
            foreach (Case element in Liste_PNJ)
            {
                if (element.identifiant == 0)
                {
                    element.Texture = content.Load<Texture2D>("Ajout");
                }
                else
                {
                    element.Texture = content.Load<Texture2D>(String.Concat("PNJ\\", Niveau.getNom(element.identifiant, "BD_PNJs.txt"), "_Bas_Stat"));
                    element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                }                
            }
        }
        public void DessinerMenu(SpriteBatch spriteBatch, Case[] liste_sélectionnée)
        {
            panneau_latéral.Draw(spriteBatch);
            for (int i = 0; i < 5; i++)
                Boutons[i].Draw(spriteBatch);
            for (int i = 0; i < liste_sélectionnée.Length; i++)
            {
                if (DansMenuLatéral(liste_sélectionnée[i])) liste_sélectionnée[i].Draw(spriteBatch);
            }
        }
        public bool DansMenuLatéral(Case case_liste)
        {
            return (case_liste.Position.X >= X_inférieur_Cases_menu && case_liste.Position.Y >= Y_inférieur_Cases_menu && case_liste.Position.X <= X_supérieur_Cases_menu && case_liste.Position.Y <= Y_supérieur_Cases_menu);
        }
        public bool DansMenuLatéral(Vector2 Position)
        {
            return (Position.X >= panneau_latéral.Position.X && Position.Y >= panneau_latéral.Position.Y && Position.X <= panneau_latéral.Position.X + panneau_latéral.Texture.Width && Position.Y <= panneau_latéral.Position.Y + panneau_latéral.Texture.Height);
        }
        public bool Mode_Bloc(Bouton_Liste Liste)
        {
            if (Liste == Boutons[0]) return true;
            else return false;
        }
        public bool Mode_Mur(Bouton_Liste Liste)
        {
            if (Liste == Boutons[1]) return true;
            else return false;
        }
        public bool Mode_Objet(Bouton_Liste Liste)
        {
            if (Liste == Boutons[2]) return true;
            else return false;
        }
        public bool Mode_Ennemis(Bouton_Liste Liste)
        {
            if (Liste == Boutons[3]) return true;
            else return false;
        }
        public bool Mode_PNJ(Bouton_Liste Liste)
        {
            if (Liste == Boutons[4]) return true;
            else return false;
        }
        public Case[] Recharger(Case[] Liste, Microsoft.Xna.Framework.Content.ContentManager content)
        {
            if (Liste_Bloc.Equals(Liste))
            {
                Liste_Bloc = ChargerListe("BD_Blocs.txt", Case.Type.Bloc);
                foreach (Case element in Liste_Bloc)
                {
                    if (element.identifiant == 0)
                    {
                        element.Texture = content.Load<Texture2D>("Ajout");
                    }
                    else
                    {
                        element.Texture = content.Load<Texture2D>(String.Concat("Blocs\\", (Niveau.getNom(element.identifiant, "BD_Blocs.txt"))));
                        element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                    }
                }
                return Liste_Bloc;
            }
            else if (Liste_Mur.Equals(Liste))
            {
                Liste_Mur = ChargerListe("BD_Murs.txt", Case.Type.Mur);
                foreach (Case element in Liste_Mur)
                {
                    if (element.identifiant == 0)
                    {
                        element.Texture = content.Load<Texture2D>("Ajout");
                    }
                    else
                    {
                        element.Texture = content.Load<Texture2D>(String.Concat("Murs\\", (Niveau.getNom(element.identifiant, "BD_Murs.txt"))));
                        element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                    }
                }
                return Liste_Mur;
            }
            else if (Liste_Objet.Equals(Liste))
            {
                Liste_Objet = ChargerListe("BD_Objets.txt", Case.Type.Objet);
                foreach (Case element in Liste_Objet)
                {
                    element.Texture = content.Load<Texture2D>(String.Concat("Objets\\", (Niveau.getNom(element.identifiant, "BD_Objets.txt"))));
                    element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                }
                return Liste_Objet;
            }
            else if (Liste_Ennemi.Equals(Liste))
            {
                Liste_Ennemi = ChargerListe("BD_Ennemis.txt", Case.Type.Ennemis);
                foreach (Case element in Liste_Ennemi)
                {
                    if (element.identifiant == 0)
                    {
                        element.Texture = content.Load<Texture2D>("Ajout");
                    }
                    else
                    {
                        element.Texture = content.Load<Texture2D>(String.Concat("Ennemis\\", Niveau.getNom(element.identifiant, "BD_Ennemis.txt"),"_Bas_Stat"));
                        element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                    }
                }
                return Liste_Ennemi;
            }
            else
            {
                Liste_Bloc = ChargerListe("BD_PNJs.txt", Case.Type.PNJ_Neutres);
                foreach (Case element in Liste_PNJ)
                {
                    if (element.identifiant == 0)
                    {
                        element.Texture = content.Load<Texture2D>("Ajout");
                    }
                    else
                    {
                        element.Texture = content.Load<Texture2D>(String.Concat("PNJ\\", Niveau.getNom(element.identifiant, "BD_PNJs.txt"), "_Bas_Stat"));
                        element.Contour_Sélection.Texture = content.Load<Texture2D>("Contour_sélection_case");
                    }
                }
                return Liste_PNJ;
            }
        }
        public Menu_Latéral()
        {
            panneau_latéral = new GameObject();
            Boutons = new Bouton_Liste[5];
            panneau_latéral.Position = new Vector2(5 * Editeur.WINDOW_WIDTH / 6, 4 * Editeur.WINDOW_HEIGHT / 21);
            for (int i = 0; i < 5; i++)
            {
                Boutons[i] = new Bouton_Liste(new Vector2(panneau_latéral.Position.X + marge_intérieur + i * (Width_Bouton + intervalle), panneau_latéral.Position.Y + marge_intérieur));
            }
            Bloc_Null = new Case(0, Case.Type.Bloc, new Vector2(0,0));
            Liste_Bloc = ChargerListe("BD_Blocs.txt", Case.Type.Bloc);
            Liste_Mur = ChargerListe("BD_Murs.txt", Case.Type.Mur);
            Liste_Objet = ChargerListe("BD_Objets.txt", Case.Type.Objet);
            Liste_Ennemi = ChargerListe("BD_Ennemis.txt", Case.Type.Ennemis);
            Liste_PNJ = ChargerListe("BD_PNJs.txt", Case.Type.PNJ_Neutres);
        }
    }
}
