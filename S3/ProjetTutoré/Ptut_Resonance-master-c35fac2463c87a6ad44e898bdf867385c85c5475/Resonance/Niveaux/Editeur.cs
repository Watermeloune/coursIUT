using System;
using System.Threading;
using System.IO;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Resonance.Core;
namespace Resonance.Niveaux
{
    class Editeur : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int WINDOW_WIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int WINDOW_HEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        //private EcranDémarrage ecran;
        private Pointeur pointeur;
        private Vector2 pointeur_position_précédente;
        private BoutonEcran[] bouton;
        private Niveau niveau;
        private Bloc[] Map_Blocs;
        private Menu_Supérieur menu_supérieur;
        private Menu_Latéral menu_latéral;
        private Case[] Liste_Active;
        private Case case_selectionnee = null;
        private int index_bloc1;
        private Bouton_Liste bouton_survolé = null;
        private Case case_survolée = null;
        private Ennemis ennemi_préparé;
        private Vector2 position_pattern;
        private ArrayList pattern_préparé;
        private Texture2D texture_pattern;
        private Texture2D texture_quadrillage;
        private Ajouter_Bloc AjBl;
        private Ajouter_Mur AjMr;
        private Ajouter_Objet AjOb;
        private Ajouter_Ennemi AjEn;
        private Ajouter_PNJ AjPnj;
        private ChangerNom ChNm;
        private float zoom = 1;
        private bool mode_attribution_pattern = false;
        private bool quadrillage = true;
        public Editeur()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            //graphics.IsFullScreen = true;
        }
        public void Quit()
        {
            if (this != null)
            {
                Exit();
            }
        }

        public void Déplacermap(float distance, String orientation)
        //Déplace rééllement la map, suivant les instructions de la fonction suivante
        {
            switch (orientation)
            {
                case "Y":
                    for (int i = 0; i < niveau.NbBlocsX * niveau.NbBlocsY; i++) niveau.map[i].Position.Y += distance;
                    break;
                case "X":
                    for (int i = 0; i < niveau.NbBlocsX * niveau.NbBlocsY; i++) niveau.map[i].Position.X += distance;
                    break;
            }
        }
        public void check_déplacements()
        // Permet de déplacer la map de léditeur de niveaux avec le curseur (lorsqu'il est sur les bords de l'écran)
        {
            Vector2 décalage = pointeur.Position - pointeur_position_précédente;
            if (décalage != Vector2.Zero)
            {
                if (niveau.map[0].Position.X < 0 && décalage.X > 0)
                {
                    if (niveau.map[0].Position.X <= -décalage.X) Déplacermap(décalage.X, "X");
                    else Déplacermap(-niveau.map[0].Position.X, "X");
                }
                if (niveau.map[0].Position.Y < menu_supérieur.panneau_supérieur.Texture.Height && décalage.Y > 0)
                {
                    if (niveau.map[0].Position.Y <= menu_supérieur.panneau_supérieur.Texture.Height - décalage.Y) Déplacermap(décalage.Y, "Y");
                    else Déplacermap(menu_supérieur.panneau_supérieur.Texture.Height - niveau.map[0].Position.Y, "Y");
                }
                if (niveau.map[niveau.NbBlocsX * niveau.NbBlocsY - 1].Position.X > WINDOW_WIDTH && décalage.X < 0)
                {
                    if (niveau.map[niveau.NbBlocsX * niveau.NbBlocsY - 1].Position.X >= menu_latéral.panneau_latéral.Position.X - décalage.X) Déplacermap(décalage.X, "X");
                    else Déplacermap(menu_latéral.panneau_latéral.Position.X - niveau.map[niveau.NbBlocsX * niveau.NbBlocsY - 1].Position.X, "X");
                }
                if (niveau.map[niveau.NbBlocsX * niveau.NbBlocsY - 1].Position.Y + Bloc.HEIGHT > WINDOW_HEIGHT && décalage.Y < 0)
                {
                    if (niveau.map[niveau.NbBlocsX * niveau.NbBlocsY - 1].Position.Y + Bloc.HEIGHT >= WINDOW_HEIGHT - décalage.Y) Déplacermap(décalage.Y, "Y");
                    else Déplacermap(WINDOW_HEIGHT - niveau.map[niveau.NbBlocsX * niveau.NbBlocsY - 1].Position.Y, "Y");
                }
            }
        }
        public void changer_bloc(int indice) //A intégrer dans l'update
                                             //Remplace le bloc de la map à l'indice indiqué par celui selectionné dans la liste
        { // A compléter
            switch (case_selectionnee.type)
            {
                case Case.Type.Bloc:
                    niveau.map[indice] = new Bloc(getTypeBloc(case_selectionnee.identifiant), case_selectionnee.identifiant, niveau.map[indice].Position, Bloc.Orientation.Normal);
                    niveau.map[indice].Texture = case_selectionnee.Texture;
                    break;
                case Case.Type.Mur:
                    break;
                case Case.Type.Objet:
                    break;
                case Case.Type.Ennemis:
                    break;
                case Case.Type.PNJ_Neutres:
                    break;
            }

        }
        public void check_sélection_map()
        {
            if (!menu_supérieur.CliqEdEn && !menu_supérieur.CliqEdpnj)
            {
                if (Mouse.GetState().Position.X < menu_latéral.panneau_latéral.Position.X && Mouse.GetState().Position.Y > menu_supérieur.panneau_supérieur.Texture.Height && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (Liste_Active.Equals(menu_latéral.Liste_Bloc))
                    {
                        int ligne = (int)(Mouse.GetState().Position.Y - niveau.map[index_bloc1].Position.Y) / Bloc.HEIGHT;
                        int colonne = (int)(Mouse.GetState().Position.X - niveau.map[index_bloc1].Position.X) / Bloc.WIDTH;
                        changer_bloc(ligne * niveau.NbBlocsX + index_bloc1 + colonne);
                    }
                    else if (Liste_Active.Equals(menu_latéral.Liste_Mur))
                    {

                    }
                    else if (Liste_Active.Equals(menu_latéral.Liste_Objet))
                    {

                    }
                    else if (Liste_Active.Equals(menu_latéral.Liste_Ennemi))
                    {
                        int colonne = index_bloc1%niveau.NbBlocsX + (int)(Mouse.GetState().Position.X - niveau.map[index_bloc1].Position.X) / Bloc.WIDTH;
                        int ligne = index_bloc1 / niveau.NbBlocsX + (int)(Mouse.GetState().Position.Y - niveau.map[index_bloc1].Position.Y) / Bloc.HEIGHT;
                        if (!mode_attribution_pattern)
                        {
                            ennemi_préparé = new Ennemis(case_selectionnee.identifiant, new Vector2(colonne, ligne));
                            mode_attribution_pattern = true;
                            position_pattern = new Vector2(colonne, ligne);
                            Thread.Sleep(200);
                        }
                        else
                        {
                            if (position_pattern == new Vector2(colonne, ligne))
                            {
                                menu_supérieur.CliqEdEn = true;
                            }
                            else
                            {
                                if (position_pattern.X == colonne)
                                {
                                    if (position_pattern.Y > ligne)
                                    {
                                        for (int i = 1; i < position_pattern.Y - ligne; i++)
                                            ennemi_préparé.Pattern.Add(new Vector2(colonne, position_pattern.Y - i));
                                    }
                                    else
                                    {
                                        for (int i = 1; i < ligne - position_pattern.Y; i++)
                                            ennemi_préparé.Pattern.Add(new Vector2(colonne, position_pattern.Y + i));
                                    }
                                    position_pattern = new Vector2(colonne, ligne);
                                    ennemi_préparé.Pattern.Add(new Vector2(colonne, ligne));
                                    Thread.Sleep(200);
                                }
                                else if(position_pattern.Y == ligne)
                                {
                                    if (position_pattern.X > colonne)
                                    {
                                        for (int i = 1; i < position_pattern.X - colonne; i++)
                                            ennemi_préparé.Pattern.Add(new Vector2(position_pattern.X - i, ligne));
                                    }
                                    else
                                    {
                                        for (int i = 1; i < colonne - position_pattern.X; i++)
                                            ennemi_préparé.Pattern.Add(new Vector2(position_pattern.X + i, ligne));
                                    }
                                    position_pattern = new Vector2(colonne, ligne);
                                    ennemi_préparé.Pattern.Add(new Vector2(colonne, ligne));
                                    Thread.Sleep(200);
                                }
                                
                            }
                        }

                    }
                    else if (Liste_Active.Equals(menu_latéral.Liste_PNJ))
                    {
                        menu_supérieur.CliqEdpnj = true;
                    }
                }
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                if (Liste_Active.Equals(menu_latéral.Liste_Mur))
                {

                }
                else if (Liste_Active.Equals(menu_latéral.Liste_Ennemi)&& menu_supérieur.CliqEdEn)
                {
                    mode_attribution_pattern = false;
                    menu_supérieur.EdEn = new Editer_Ennemi(ennemi_préparé, niveau, menu_latéral.Liste_Ennemi, menu_latéral.Liste_Objet, Content, true);
                    menu_supérieur.EdEn.ShowDialog();
                    menu_supérieur.ennemis = new ListeEnnemis(new Color(43, 30, 22), new Vector2(550, 80), niveau.ennemis);
                    menu_supérieur.ennemis.LoadListe(Content);
                    menu_supérieur.CliqEdEn = false;
                }
                else if (Liste_Active.Equals(menu_latéral.Liste_PNJ)&& menu_supérieur.CliqEdpnj)
                {
                    int colonne = index_bloc1 % niveau.NbBlocsX + (int)(Mouse.GetState().Position.X - niveau.map[index_bloc1].Position.X) / Bloc.WIDTH;
                    int ligne = index_bloc1 / niveau.NbBlocsX + (int)(Mouse.GetState().Position.Y - niveau.map[index_bloc1].Position.Y) / Bloc.HEIGHT;
                    menu_supérieur.EdPnj = new Editer_PNJ(new PNJ_Neutres(case_selectionnee.identifiant, new Vector2(colonne, ligne)), niveau, menu_latéral.Liste_PNJ, Content, true);
                    menu_supérieur.EdPnj.ShowDialog();
                    menu_supérieur.PNJs = new ListePNJ(new Color(43, 30, 22), new Vector2(900, 80), niveau.PNJneutres);
                    menu_supérieur.PNJs.LoadListe(Content);
                    menu_supérieur.CliqEdpnj = false;
                }
            }
        }
        public void check_sélection_case()
        {
            if (menu_latéral.DansMenuLatéral(Mouse.GetState().Position.ToVector2()) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                foreach (Case element in Liste_Active)
                {
                    if (element.DansCase(Mouse.GetState().Position.ToVector2()))
                    {
                        if (element.identifiant == 0)
                        {
                            if (Liste_Active.Equals(menu_latéral.Liste_Bloc))
                            {
                                AjBl = new Ajouter_Bloc();
                                AjBl.ShowDialog();
                                Liste_Active = menu_latéral.Recharger(Liste_Active, Content);
                                AjBl = null;

                            }
                            else if (Liste_Active.Equals(menu_latéral.Liste_Mur))
                            {
                                AjMr = new Ajouter_Mur();
                                AjMr.ShowDialog();
                                Liste_Active = menu_latéral.Recharger(Liste_Active, Content);
                                AjMr = null;
                            }
                            else if (Liste_Active.Equals(menu_latéral.Liste_Objet))
                            {
                                AjOb = new Ajouter_Objet();
                                AjOb.ShowDialog();
                                Liste_Active = menu_latéral.Recharger(Liste_Active, Content);
                                AjOb = null;
                            }
                            else if (Liste_Active.Equals(menu_latéral.Liste_Ennemi))
                            {
                                AjEn = new Ajouter_Ennemi();
                                AjEn.ShowDialog();
                                Liste_Active = menu_latéral.Recharger(Liste_Active, Content);
                                AjEn = null;
                            }
                            else if (Liste_Active.Equals(menu_latéral.Liste_PNJ))
                            {
                                AjPnj = new Ajouter_PNJ();
                                AjPnj.ShowDialog();
                                Liste_Active = menu_latéral.Recharger(Liste_Active, Content);
                                AjPnj = null;
                            }
                        }
                        else
                             case_selectionnee = element;
                    }
                }
            }
        }
        public static int Nombre_lignes_fichier(String Path)
            //Revoi le nombre de lignes d'un fichier indiqué
        {
            StreamReader SR = new StreamReader(String.Concat(Niveau.Root, Path));
            int i = 0;
            string buff = "a";
            while (buff != null)
            {
                buff = SR.ReadLine();
                if (buff == null) { break; }
                else { i++; }
            }
            SR.Close();
            return i;
        }
        public void ChargerTextureMap(Niveau niveau)
            //Charge les sprites de chaque bloc de la map
        {
            for (int i = 0; i < niveau.NbBlocsX * niveau.NbBlocsY; i++)
            {
                niveau.map[i].Texture = Content.Load<Texture2D>(String.Concat("Blocs\\", niveau.map[i].nom));
            }
            texture_pattern = Content.Load<Texture2D>("texture_pattern");
            texture_quadrillage = Content.Load<Texture2D>("texture_quadrillage");
        }
        private void DessinerMap(Niveau niveau, float zoom)
            //Dessine la partie de la map qui est affiché à l'écran
        {
            //Zoom à implémenter
            index_bloc1 = 0;
            while (niveau.map[index_bloc1].Position.X <= -Bloc.WIDTH || niveau.map[index_bloc1].Position.Y <= menu_supérieur.panneau_supérieur.Texture.Height-Bloc.HEIGHT) index_bloc1++;
            for (int j = 0; j <= WINDOW_HEIGHT / Bloc.HEIGHT; j++)
            {
                for (int i = 0; i <= WINDOW_WIDTH / Bloc.WIDTH;i++)
                {
                    if (j * niveau.NbBlocsX + index_bloc1 + i < niveau.NbBlocsX * niveau.NbBlocsY) niveau.map[j * niveau.NbBlocsX + index_bloc1 + i].Draw(spriteBatch);
                }
            }
            if (mode_attribution_pattern)
            {
                foreach(Vector2 emplacement in ennemi_préparé.Pattern)
                {
                    if (position_pattern.Y * niveau.NbBlocsX + index_bloc1 + position_pattern.X < niveau.NbBlocsX * niveau.NbBlocsY) spriteBatch.Draw(texture_pattern, niveau.map[(int)emplacement.Y * niveau.NbBlocsX + (int)emplacement.X].Position, Color.White);
                }
                for (int j = 0; j <= (WINDOW_HEIGHT - menu_supérieur.panneau_supérieur.Texture.Height + 1) / Bloc.HEIGHT; j++)
                {
                    if (j * niveau.NbBlocsX + index_bloc1 + position_pattern.X < niveau.NbBlocsX * niveau.NbBlocsY) spriteBatch.Draw(texture_quadrillage, niveau.map[j * niveau.NbBlocsX + index_bloc1 - index_bloc1 % niveau.NbBlocsX + (int)position_pattern.X].Position, Color.White);
                }
                for (int i = 0; i <= (WINDOW_WIDTH - menu_latéral.panneau_latéral.Texture.Width + 1) / Bloc.WIDTH; i++)
                {
                    if (position_pattern.Y * niveau.NbBlocsX + index_bloc1 + i < niveau.NbBlocsX * niveau.NbBlocsY) spriteBatch.Draw(texture_quadrillage, niveau.map[((int)position_pattern.Y)* niveau.NbBlocsX + index_bloc1 % niveau.NbBlocsX + i].Position, Color.White);
                }
            }
            else
                if (quadrillage)
                {
                    for (int j = 0; j <= (WINDOW_HEIGHT - menu_supérieur.panneau_supérieur.Texture.Height+1) / Bloc.HEIGHT; j++)
                    {   
                        for (int i = 0; i <= (WINDOW_WIDTH - menu_latéral.panneau_latéral.Texture.Width+1) / Bloc.WIDTH; i++)
                        {
                            if (j * niveau.NbBlocsX + index_bloc1 + i < niveau.NbBlocsX * niveau.NbBlocsY) spriteBatch.Draw(texture_quadrillage, niveau.map[j * niveau.NbBlocsX + index_bloc1 + i].Position, Color.White);
                        }
                    }
                }     
        }
        private void DessinerPNJs(Niveau niveau, float zoom)
        {
            for (int i = 0; i < niveau.ennemis.Count; i++)
            {
                Vector2 position = new Vector2((((Ennemis)niveau.ennemis[i]).Position.X - index_bloc1 % niveau.NbBlocsX) * Bloc.WIDTH + niveau.map[index_bloc1].Position.X, (((Ennemis)niveau.ennemis[i]).Position.Y - index_bloc1 / niveau.NbBlocsX) * Bloc.HEIGHT + niveau.map[index_bloc1].Position.Y);
                if (position.X >= -Bloc.WIDTH && position.Y >= menu_supérieur.panneau_supérieur.Texture.Height - Bloc.HEIGHT && position.X < menu_latéral.panneau_latéral.Position.X && position.Y < WINDOW_HEIGHT)
                    ((Ennemis)niveau.ennemis[i]).Draw(spriteBatch, position, 0);
            }
            for (int i = 0; i < niveau.PNJneutres.Count; i++)
            {
                Vector2 position = new Vector2(((int)((PNJ_Neutres)niveau.PNJneutres[i]).Position.X - index_bloc1 % niveau.NbBlocsX) * Bloc.WIDTH + niveau.map[index_bloc1].Position.X, ((int)((PNJ_Neutres)niveau.PNJneutres[i]).Position.Y - index_bloc1 / niveau.NbBlocsX) * Bloc.HEIGHT + niveau.map[index_bloc1].Position.Y);
                if (position.X >= -Bloc.WIDTH && position.Y >= menu_supérieur.panneau_supérieur.Texture.Height - Bloc.HEIGHT && position.X < menu_latéral.panneau_latéral.Position.X && position.Y < WINDOW_HEIGHT)
                    ((PNJ_Neutres)niveau.PNJneutres[i]).Draw(spriteBatch, position, 0);
            }
        }
        public Bloc[] ChargerListeBlocs()
            //Charge la liste des blocs de la BD
        {
            int nb_lignes = Nombre_lignes_fichier("BD_Blocs.txt");
            Bloc[] liste = new Bloc[nb_lignes];
            StreamReader SR = new StreamReader(String.Concat(Niveau.Root, "BD_Blocs.txt"));
            for (int i = 0; i < nb_lignes; i++)
            {
                String ligne = SR.ReadLine();
                int identifiant = int.Parse(ligne.Substring(0, 3));
                liste[i] = new Bloc(getTypeBloc(identifiant), identifiant,ligne.Substring(4));
            }
            SR.Close();
            return liste;

        }
        public static Bloc.Type getTypeBloc(int identifiant)
            //Renvoie le type d'un bloc en fonction de son identifiant
        {
            int type=0;
            if (identifiant == 0) type = 0;
            else if (identifiant < 100) type = 1;
            else if (identifiant < 200) type = 2;
            else if (identifiant < 300) type = 3;
            else if (identifiant < 400) type = 4;
            //A revérifier et compléter
            return (Bloc.Type) type;
        }
        public void quickSort(Bloc[] tableau, int debut, int fin)
            //Trie un tableau de bloc par leur identifiant
        {
            int gauche = debut - 1;
            int droite = fin + 1;
            int pivot = (int)tableau[debut].type ;
            if (debut < fin)
            {
                bool réunion = true;
                while (réunion)
                {
                    do droite--; while ((int)tableau[droite].type > pivot);
                    do gauche++; while ((int)tableau[gauche].type < pivot);
                    if (gauche < droite)
                    {
                        Bloc temp = tableau[gauche];
                        tableau[gauche] = tableau[droite];
                        tableau[droite] = temp;
                    }
                    else réunion = false;
                }
                quickSort(tableau, debut, droite);
                quickSort(tableau, droite + 1, fin);
            }
        }
        protected override void Initialize()
            //Charge les variables nécessaires à l'affichage
        {
            pointeur = new Pointeur();
            niveau = new Niveau("Sans nom");
            niveau.ChargerMapVierge(Niveau.Taille.PETITE);
            menu_latéral = new Menu_Latéral();
            menu_supérieur = new Menu_Supérieur(niveau.nom, niveau);
            Liste_Active = menu_latéral.Liste_Bloc;
            Map_Blocs = ChargerListeBlocs();
            Menu_Latéral.Initialiser_Proportions_CasesMenu(menu_latéral);
            base.Initialize();
        }
        protected override void LoadContent()
            //Charge les sprites et les positions nécessaires à l'affichage
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pointeur.Texture = Content.Load<Texture2D>("souris");
            ChargerTextureMap(niveau);
            menu_latéral.ChargerTextureListes(Content);
            menu_supérieur.ChargerTexturesMenu(Content);
            pointeur.Position = new Vector2(0, 0);
        }
        protected override void UnloadContent()
        {

        }
        private void check_boutons_menu_latéral()
        {
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                if (menu_latéral.Boutons[i].CheckSelection())
                    bouton_survolé = menu_latéral.Boutons[i];
                else
                    j++;
            }
            if (j > 4)
                bouton_survolé = null;
            if (bouton_survolé != null && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (bouton_survolé == menu_latéral.Boutons[0])
                    Liste_Active = menu_latéral.Liste_Bloc;
                else if (bouton_survolé == menu_latéral.Boutons[1])
                    Liste_Active = menu_latéral.Liste_Mur;
                else if (bouton_survolé == menu_latéral.Boutons[2])
                    Liste_Active = menu_latéral.Liste_Objet;
                else if (bouton_survolé == menu_latéral.Boutons[3])
                    Liste_Active = menu_latéral.Liste_Ennemi;
                else if (bouton_survolé == menu_latéral.Boutons[4])
                    Liste_Active = menu_latéral.Liste_PNJ;
                case_selectionnee = null;
            }
        }
        private void check_boutons_menu_supérieur()
        {
            //Renommer le niveau
            if (menu_supérieur.bouton_renommer.Clic_valide)
            {
                menu_supérieur.bouton_renommer.Clic_valide = false;
                ChNm = new ChangerNom();
                ChNm.ShowDialog();
                if (ChNm.nom_modifié) menu_supérieur.nom_niveau.texte = ChNm.nom_niveau;
                ChNm = null;
                menu_supérieur.ChargerProportionsBoutonRenommer();
            }
            else
                menu_supérieur.bouton_renommer.checkBouton();
            //Sauvegarder le niveau
            if(menu_supérieur.Sauvegarde.Clic_valide)
            {
                menu_supérieur.Sauvegarde.Clic_valide = false;
                if (!File.Exists(String.Concat("Content\\Niveaux\\Liste_niveaux\\", niveau.nom,".txt")))
                    File.Create(String.Concat("Content\\Niveaux\\Liste_niveaux\\", niveau.nom, ".txt"));
                niveau.SauvegarderNiveau();
                Texture2D temp = menu_supérieur.Sauvegarde_Validation;
                menu_supérieur.Sauvegarde_Validation = menu_supérieur.Sauvegarde.Texture;
                menu_supérieur.Sauvegarde.Texture = temp;
            }
            else
            {
                menu_supérieur.Sauvegarde.checkBouton();
                if(menu_supérieur.Sauvegarde.Clic_valide)
                {
                    Texture2D temp = menu_supérieur.Sauvegarde_Validation;
                    menu_supérieur.Sauvegarde_Validation = menu_supérieur.Sauvegarde.Texture;
                    menu_supérieur.Sauvegarde.Texture = temp;
                }
            }
                
            //Traiter liste des évènements
            if (menu_supérieur.evenements.bouton.Clic_valide)
            {
                menu_supérieur.evenements.bouton.Clic_valide = false;
                menu_supérieur.evenements.selection = !menu_supérieur.evenements.selection;
                
            }
            else
                menu_supérieur.evenements.bouton.checkBouton();
            if (menu_supérieur.evenements.selection)
            {
                for (int i = 0; i < menu_supérieur.evenements.BoutonsText.Count; i++)
                {
                    if (((Bouton)menu_supérieur.evenements.BoutonsText[i]).Clic_valide)
                    {
                        ((Bouton)menu_supérieur.evenements.BoutonsText[i]).Clic_valide = false;
                        if (i == 0)
                        {
                            niveau.evenements.Add(new Evenement(0, "Ajouter un évènement", Evenement.Type_Event.Indéfini));
                            menu_supérieur.EdEv = new Editer_Evenement((Evenement)niveau.evenements[niveau.evenements.Count-1], niveau, menu_latéral.Liste_Ennemi);
                            menu_supérieur.EdEv.ShowDialog();
                        }
                        else
                        {
                            menu_supérieur.EdEv = new Editer_Evenement(((Evenement)menu_supérieur.evenements.DataListe[i-1]), niveau, menu_latéral.Liste_Ennemi);
                            menu_supérieur.EdEv.ShowDialog();
                        }
                        menu_supérieur.EdEv = null;
                        menu_supérieur.evenements = new ListeEvènement(new Color(43, 30, 22), new Vector2(200, 80), niveau.evenements);
                        menu_supérieur.evenements.LoadListe(Content);
                    }
                    else
                        ((Bouton)menu_supérieur.evenements.BoutonsText[i]).checkBouton();
                }
            }
            //Traiter liste des ennemis
            if (menu_supérieur.ennemis.bouton.Clic_valide)
            {
                menu_supérieur.ennemis.bouton.Clic_valide = false;
                menu_supérieur.ennemis.selection = !menu_supérieur.ennemis.selection;

            }
            else
                menu_supérieur.ennemis.bouton.checkBouton();
            if (menu_supérieur.ennemis.selection)
            {
                for (int i = 0; i < menu_supérieur.ennemis.BoutonsText.Count; i++)
                {
                    if (((Bouton)menu_supérieur.ennemis.BoutonsText[i]).Clic_valide)
                    {
                        ((Bouton)menu_supérieur.ennemis.BoutonsText[i]).Clic_valide = false;
                            menu_supérieur.EdEn = new Editer_Ennemi(((Ennemis)menu_supérieur.ennemis.DataListe[i]), niveau, menu_latéral.Liste_Ennemi, menu_latéral.Liste_Objet, Content, false);
                            menu_supérieur.EdEn.ShowDialog();
                        menu_supérieur.EdEn = null;
                        menu_supérieur.ennemis = new ListeEnnemis(new Color(43, 30, 22), new Vector2(550, 80), niveau.ennemis);
                        menu_supérieur.ennemis.LoadListe(Content);
                    }
                    else
                        ((Bouton)menu_supérieur.ennemis.BoutonsText[i]).checkBouton();
                }
            }
            //Traiter liste des PNJs
            if (menu_supérieur.PNJs.bouton.Clic_valide)
            {
                menu_supérieur.PNJs.bouton.Clic_valide = false;
                menu_supérieur.PNJs.selection = !menu_supérieur.PNJs.selection;

            }
            else
                menu_supérieur.PNJs.bouton.checkBouton();
            if (menu_supérieur.PNJs.selection)
            {
                for (int i = 0; i < menu_supérieur.PNJs.BoutonsText.Count; i++)
                {
                    if (((Bouton)menu_supérieur.PNJs.BoutonsText[i]).Clic_valide)
                    {
                        ((Bouton)menu_supérieur.PNJs.BoutonsText[i]).Clic_valide = false;
                        menu_supérieur.EdPnj = new Editer_PNJ(((PNJ_Neutres)menu_supérieur.PNJs.DataListe[i]), niveau, menu_latéral.Liste_PNJ, Content, false);
                        menu_supérieur.EdPnj.ShowDialog();
                        menu_supérieur.EdPnj = null;
                        menu_supérieur.PNJs = new ListePNJ(new Color(43, 30, 22), new Vector2(900, 80), niveau.PNJneutres);
                        menu_supérieur.PNJs.LoadListe(Content);
                    }
                    else
                        ((Bouton)menu_supérieur.PNJs.BoutonsText[i]).checkBouton();
                }
            }
        }
        private void Update_indicateur_position()
        {
            //Récupérer la position actuel du curseur
            if (Mouse.GetState().Position.ToVector2().X > 0 && Mouse.GetState().Position.ToVector2().X <= menu_latéral.panneau_latéral.Position.X && Mouse.GetState().Position.ToVector2().Y > menu_supérieur.panneau_supérieur.Texture.Height && Mouse.GetState().Position.ToVector2().Y <= WINDOW_HEIGHT)
            {
                menu_supérieur.indicateur_position_data[0].texte = ((Mouse.GetState().X + (int)niveau.map[index_bloc1].Position.X) / Bloc.WIDTH + index_bloc1 % niveau.NbBlocsX).ToString();
                menu_supérieur.indicateur_position_data[1].texte = ((Mouse.GetState().Y - menu_supérieur.panneau_supérieur.Texture.Height + (int)niveau.map[index_bloc1].Position.Y) / Bloc.HEIGHT + index_bloc1 / niveau.NbBlocsX).ToString();
            }
        }
        private void check_cases()
        {
            int j = 0;
            foreach(Case element in Liste_Active)
            {
                if (element.DansCase(Mouse.GetState().Position.ToVector2())&&element.identifiant!=0)
                    case_survolée = element;
                else
                    j++;
            }
            if (j >= Liste_Active.Length)
                case_survolée = null;
        }
        protected override void Update(GameTime gameTime)
            //Déplace le curseur - Déplace la map (en fonction du curseur)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Quit();
            pointeur_position_précédente = pointeur.Position;
            pointeur.Position = Mouse.GetState().Position.ToVector2();
            Update_indicateur_position();
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                check_déplacements();
            if(!mode_attribution_pattern)
            {
                if (menu_latéral.DansMenuLatéral(Mouse.GetState().Position.ToVector2()))
                {
                    check_boutons_menu_latéral();
                    check_cases();
                    check_sélection_case();
                }
                else if (menu_supérieur.DansMenuSupérieur(Mouse.GetState().Position.ToVector2()) || menu_supérieur.evenements.selection)
                {
                    check_boutons_menu_supérieur();
                }
            }
            if (case_selectionnee != null)
            {
                if (!menu_supérieur.ennemis.selection && !menu_supérieur.evenements.selection && !menu_supérieur.PNJs.selection)
                    check_sélection_map();
                else if(menu_supérieur.ennemis.selection && ((Mouse.GetState().Position.ToVector2().X < menu_supérieur.ennemis.bouton.Position.X || Mouse.GetState().Position.ToVector2().X > menu_supérieur.ennemis.bouton.Position.X + menu_supérieur.ennemis.bouton.largeur)&& Mouse.GetState().Position.ToVector2().Y > menu_supérieur.ennemis.bouton.Position.Y + (menu_supérieur.ennemis.BoutonsText.Count+1) * menu_supérieur.ennemis.bouton.longueur))
                    check_sélection_map();
                else if (menu_supérieur.evenements.selection && ((Mouse.GetState().Position.ToVector2().X < menu_supérieur.evenements.bouton.Position.X || Mouse.GetState().Position.ToVector2().X > menu_supérieur.evenements.bouton.Position.X + menu_supérieur.evenements.bouton.largeur) && Mouse.GetState().Position.ToVector2().Y > menu_supérieur.evenements.bouton.Position.Y + (menu_supérieur.evenements.BoutonsText.Count + 1) * menu_supérieur.evenements.bouton.longueur))
                    check_sélection_map();
                else if (menu_supérieur.PNJs.selection && ((Mouse.GetState().Position.ToVector2().X < menu_supérieur.PNJs.bouton.Position.X || Mouse.GetState().Position.ToVector2().X > menu_supérieur.PNJs.bouton.Position.X + menu_supérieur.PNJs.bouton.largeur) && Mouse.GetState().Position.ToVector2().Y > menu_supérieur.PNJs.bouton.Position.Y + (menu_supérieur.PNJs.BoutonsText.Count + 1) * menu_supérieur.PNJs.bouton.longueur))
                    check_sélection_map();
            }
            ///
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DessinerMap(niveau, zoom);
            DessinerPNJs(niveau, 1);
            menu_supérieur.DessinerMenu(spriteBatch);
            menu_latéral.DessinerMenu(spriteBatch, Liste_Active);
            if (bouton_survolé != null)
                bouton_survolé.Contour_Sélection.Draw(spriteBatch);
            if (case_survolée != null)
                case_survolée.Contour_Sélection.Draw(spriteBatch);
            if (case_selectionnee != null)
                case_selectionnee.Contour_Sélection.Draw(spriteBatch);
            pointeur.Draw(spriteBatch);
            this.Window.Title = "Resonance - Editeur de niveaux";
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}