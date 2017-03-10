using System;
using System.IO;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Resonance.Niveaux
{
    public class Niveau
    {
        public static String Root = "Content\\Niveaux\\";
        public String nom;
        public Taille taille;
        public enum Taille
        {
            PETITE=1,
            MOYENNE=2,
            GRANDE=3
        }
        public int NbBlocsX;
        public int NbBlocsY;
        public int WIDTH;
        public int HEIGHT;
        public Bloc[] map;
        public ArrayList murs;
        public Objet[] objets;
        public ArrayList evenements;    
        public ArrayList ennemis;
        public ArrayList PNJneutres;
        public Niveau(String NomNiveau)
        {
            nom = NomNiveau;
        }

        public void LectureNiveau(String Path)
        //Charge les données du niveau à partir d'un fichier texte donné
        {
            StreamReader SR = new StreamReader(Path);
            String ligne = SR.ReadLine();
            int i = 0 , j = 0;
            this.taille = (Taille)int.Parse(SR.ReadLine());
            WIDTH = (int)taille * 10200;
            HEIGHT = (int)taille * 6000;
            NbBlocsX = WIDTH / Bloc.WIDTH;
            NbBlocsY = HEIGHT / Bloc.HEIGHT;
            this.map = new Bloc[NbBlocsX * NbBlocsY];
            ligne = SR.ReadLine();
            //Chargement des blocs de la map
            while (ligne != "/0")
            {
                this.map[i] = new Bloc((Bloc.Type)int.Parse(ligne.Substring(0, 1)), int.Parse(ligne.Substring(1, 3)), new Vector2(Bloc.WIDTH * (i % NbBlocsX), Bloc.HEIGHT * (i / NbBlocsX)), (Bloc.Orientation)int.Parse(ligne.Substring(4, 1)));
                ligne = SR.ReadLine();
                i++;

            }
            ligne = SR.ReadLine();
            //Chargement des murs
            while (ligne != "/0")
            {
                this.murs[j] = new Mur(int.Parse(ligne.Substring(0, 3)), new Vector2(int.Parse(ligne.Substring(4,4)), int.Parse(ligne.Substring(8,4))), (Mur.Côté)int.Parse(ligne.Substring(3, 1)));
                ligne = SR.ReadLine();
                j++;

            }
            //Chargement des ennemis
            this.ennemis = new ArrayList();
            ligne = SR.ReadLine();
            while (ligne != "/0")
            {
                ArrayList pattern = new ArrayList();
                string coordonnées = ligne.Substring(15);
                while (coordonnées.Length > 8)
                {
                    pattern.Add(new Vector2(int.Parse(coordonnées.Substring(0, 4)), int.Parse(coordonnées.Substring(4, 8))));
                    coordonnées = coordonnées.Substring(4);
                }
                int identifiant = int.Parse(ligne.Substring(0, 3));
                Vector2 PointDépart = (Vector2)pattern[0];
                Ennemis.Aggressivité aggressivité = (Ennemis.Aggressivité)int.Parse(ligne.Substring(3, 1));
                string carac_arme = ligne.Substring(4, 11);
                ligne = SR.ReadLine();
                string nom = ligne;
                this.ennemis.Add(new Ennemis(identifiant, PointDépart, aggressivité, carac_arme, pattern, nom));
                ligne = SR.ReadLine();
            }
            
            //Chargement des évènements
            this.evenements = new ArrayList();
            ligne = SR.ReadLine();
            while (ligne != "/0")
            {
                /*A implémenter*/
                ligne = SR.ReadLine();
            }
            //Chargement des autres PNJ
            this.PNJneutres = new ArrayList();
            ligne = SR.ReadLine();

            while (ligne != "/0")
            {
                int identifiant = int.Parse(ligne.Substring(0, 3));
                Vector2 PointDépart = new Vector2(int.Parse(ligne.Substring(3, 4)), int.Parse(ligne.Substring(7, 4)));
                int index_déclencheur = int.Parse(ligne.Substring(11, 2));
                Evenement déclencheur;
                if (index_déclencheur != -1)
                    déclencheur = ((Evenement)evenements[index_déclencheur]);
                else
                    déclencheur = null; 
                PNJ_Neutres.Role role = (PNJ_Neutres.Role)int.Parse(ligne.Substring(13, 2));
                string dialogue = ligne.Substring(15);
                ligne = SR.ReadLine();
                string nomEditeur = ligne;
                this.PNJneutres.Add(new PNJ_Neutres(identifiant, PointDépart, déclencheur, role, dialogue, nomEditeur));
                ligne = SR.ReadLine();
            }
        }
        public void SauvegarderNiveau()
        //Sauvegarde les données du niveau dans un fichier texte donné
        {
            String Path = String.Concat("Content\\Niveaux\\Liste_niveaux\\", nom, ".txt");
            StreamWriter SW = new StreamWriter(Path,false);
            SW.WriteLine(((int)taille).ToString());
            //Sauvegarde des blocs de la map
            foreach (Bloc bloc in map)
            {
                String id;
                if (bloc.identifiant < 100)
                {
                    if (bloc.identifiant < 10)
                        id = String.Concat("00", bloc.identifiant.ToString());
                    else
                        id = String.Concat("0", bloc.identifiant.ToString());
                }
                else
                    id = bloc.identifiant.ToString();
                SW.WriteLine(String.Concat(((int)bloc.type).ToString(), id, ((int)bloc.orientation).ToString()));
            }
            SW.WriteLine("/0");
            //Sauvegarde des murs
            foreach (Mur mur in murs)
            {
                String id;
                String posX;
                String posY;
                String position;
                if (mur.identifiant < 100)
                {
                    if (mur.identifiant < 10)
                        id = String.Concat("00", mur.identifiant.ToString());
                    else
                        id = String.Concat("0", mur.identifiant.ToString());
                }
                else
                    id = mur.identifiant.ToString();
                if (mur.Position.X < 1000)
                {
                    if (mur.Position.X < 10)
                        posX = String.Concat("000", ((int)mur.Position.X).ToString());
                    else if (mur.Position.X < 100)
                        posX = String.Concat("00", ((int)mur.Position.X).ToString());
                    else
                        posX = String.Concat("0", ((int)mur.Position.X).ToString());
                }
                else
                    posX = ((int)mur.Position.X).ToString();
                if (mur.Position.Y < 1000)
                {
                    if (mur.Position.Y < 10)
                        posY = String.Concat("000", ((int)mur.Position.Y).ToString());
                    else if (mur.Position.Y < 100)
                        posY = String.Concat("00", ((int)mur.Position.Y).ToString());
                    else
                        posY = String.Concat("0", ((int)mur.Position.Y).ToString());
                }
                else
                    posY = ((int)mur.Position.Y).ToString();
                position = String.Concat(posX, posY);
                SW.WriteLine(String.Concat(id, ((int)mur.côté).ToString(), position));
            }
            SW.WriteLine("/0");
            //Sauvegarde des ennemis
            foreach (Ennemis ennemi in ennemis)
            {
                String id;
                String pattern = "";
                String carac_arme;
                String posX;
                String posY;
                if (ennemi.identifiant < 100)
                {
                    if (ennemi.identifiant < 10)
                        id = String.Concat("00", ennemi.identifiant.ToString());
                    else
                        id = String.Concat("0", ennemi.identifiant.ToString());
                }
                else
                    id = ennemi.identifiant.ToString();
                carac_arme = String.Concat(((int)ennemi.arme.type).ToString(), ennemi.arme.dégats.ToString(), ennemi.arme.portée.ToString(), ennemi.arme.fréquence.ToString());
                foreach (Vector2 position in ennemi.Pattern)
                {
                    if (position.X < 1000)
                    {
                        if (position.X < 10)
                            posX = String.Concat("000", ((int)position.X).ToString());
                        else if (position.X < 100)
                            posX = String.Concat("00", ((int)position.X).ToString());
                        else
                            posX = String.Concat("0", ((int)position.X).ToString());
                    }
                    else
                        posX = ((int)position.X).ToString();
                    if (position.Y < 1000)
                    {
                        if (position.Y < 10)
                            posY = String.Concat("000", ((int)position.Y).ToString());
                        else if (position.Y < 100)
                            posY = String.Concat("00", ((int)position.Y).ToString());
                        else
                            posY = String.Concat("0", ((int)position.Y).ToString());
                    }
                    else
                        posY = ((int)position.Y).ToString();
                
                    pattern = String.Concat(pattern, posX, posY);
                }
                SW.WriteLine(String.Concat(id, ((int)ennemi.aggressivité).ToString(), carac_arme, pattern));
                SW.WriteLine(ennemi.nomEditeur);
            }
            SW.WriteLine("/0");
            //Sauvegarde des autres PNJ

            foreach (PNJ_Neutres pnj in PNJneutres)
            {
                String id;
                String posX;
                String posY;
                String position;
                String déclencheur="-1";
                if (pnj.identifiant < 100)
                {
                    if (pnj.identifiant < 10)
                        id = String.Concat("00", pnj.identifiant.ToString());
                    else
                        id = String.Concat("0", pnj.identifiant.ToString());
                }
                else
                    id = pnj.identifiant.ToString();
                if (pnj.Position.X < 1000)
                {
                    if (pnj.Position.X < 10)
                        posX = String.Concat("000", ((int)pnj.Position.X).ToString());
                    else if (pnj.Position.X < 100)
                        posX = String.Concat("00", ((int)pnj.Position.X).ToString());
                    else
                        posX = String.Concat("0", ((int)pnj.Position.X).ToString());
                }
                else
                    posX = ((int)pnj.Position.X).ToString();
                if (pnj.Position.Y < 1000)
                {
                    if (pnj.Position.Y < 10)
                        posY = String.Concat("000", ((int)pnj.Position.Y).ToString());
                    else if (pnj.Position.Y < 100)
                        posY = String.Concat("00", ((int)pnj.Position.Y).ToString());
                    else
                        posY = String.Concat("0", ((int)pnj.Position.Y).ToString());
                }
                else
                    posY = ((int)pnj.Position.Y).ToString();
                position = String.Concat(posX, posY);
                if (pnj.déclencheur != null)
                {
                    for (int i = 0; i < evenements.Count; i++)
                        if (((Evenement)evenements[i]).nom.Equals(pnj.déclencheur.nom))
                        {
                            déclencheur = i.ToString();
                            if (i < 10 && i > 0)
                                déclencheur = String.Concat("0", déclencheur);
                        }
                }
                SW.WriteLine(String.Concat(id, position, déclencheur, ((int)pnj.role).ToString(), pnj.dialogue));
                SW.WriteLine(pnj.nomEditeur);
            }
            SW.WriteLine("/0");
            //Sauvegarde des objets
            foreach (Objet objet in objets)
            {
                String id;
                if ((int)objet.type < 100)
                {
                    if ((int)objet.type < 10)
                        id = String.Concat("00", ((int)objet.type).ToString());
                    else
                        id = String.Concat("0", ((int)objet.type).ToString());
                }
                else
                    id = ((int)objet.type).ToString();
                SW.WriteLine(String.Concat(id, ((int)objet.Position.X).ToString(), ((int)objet.Position.Y).ToString()));
            }
            SW.WriteLine("/0");
            //Sauvegarde des évènements
            foreach (Evenement evenement in evenements)
            {
                String time;
                String conséquence="-1";
                if (evenement.timer < 1000)
                {
                    if (evenement.timer < 10)
                        time = String.Concat("000", evenement.timer.ToString());
                    else if (evenement.timer < 100)
                        time = String.Concat("00", evenement.timer.ToString());
                    else
                        time = String.Concat("0", evenement.timer.ToString());
                }
                else
                    time = evenement.timer.ToString();
                if (evenement.Conséquence != null)
                    for (int i = 0; i < evenements.Count; i++)
                    {
                        if (((Evenement)evenements[i]).nom.Equals(evenement.Conséquence))
                        {
                            conséquence = i.ToString();
                            if (i < 10 && i > 0)
                                conséquence = String.Concat("0", conséquence);
                        }
                    }
                SW.WriteLine(String.Concat(((int)evenement.type).ToString(),conséquence,time,evenement.nom));
                switch (evenement.type)
                {
                    case Evenement.Type_Event.Assassinat:
                        String type;
                        String cibles="";
                        if (((Ennemis)((EvenementAssassinat)evenement).cibles[0]).nomEditeur.Equals("pure random"))
                        {
                            type = "1";
                            foreach (Ennemis ennemi in ((EvenementAssassinat)evenement).cibles)
                            {
                                cibles = String.Concat(ennemi.nom, "=");
                            }
                        }  
                        else
                        {
                            type = "0";
                            foreach (Ennemis ennemi in ((EvenementAssassinat)evenement).cibles)
                            {
                                cibles = String.Concat(ennemi.nomEditeur, "=");
                            }
                        }
                        SW.WriteLine(String.Concat(type, cibles));
                        break;
                    case Evenement.Type_Event.Dialogue:
                        SW.WriteLine(String.Concat(((EvenementDialogue)evenement).PNJ, "=", ((EvenementDialogue)evenement).Dialogue));
                        break;
                    case Evenement.Type_Event.Objet:
                        SW.WriteLine(((int)((EvenementObjet)evenement).objet.type).ToString());
                        break;
                    case Evenement.Type_Event.Porte:
                        String posX;
                        String posY;
                        String positionS;
                        String positionC;
                        if (((EvenementPorte)evenement).position_source.X < 1000)
                        {
                            if (((EvenementPorte)evenement).position_source.X < 10)
                                posX = String.Concat("000", ((int)((EvenementPorte)evenement).position_source.X).ToString());
                            else if (((EvenementPorte)evenement).position_source.X < 100)
                                posX = String.Concat("00", ((int)((EvenementPorte)evenement).position_source.X).ToString());
                            else
                                posX = String.Concat("0", ((int)((EvenementPorte)evenement).position_source.X).ToString());
                        }
                        else
                            posX = ((int)((EvenementPorte)evenement).position_source.X).ToString();
                        if (((EvenementPorte)evenement).position_source.Y < 1000)
                        {
                            if (((EvenementPorte)evenement).position_source.Y < 10)
                                posY = String.Concat("000", ((int)((EvenementPorte)evenement).position_source.Y).ToString());
                            else if (((EvenementPorte)evenement).position_source.Y < 100)
                                posY = String.Concat("00", ((int)((EvenementPorte)evenement).position_source.Y).ToString());
                            else
                                posY = String.Concat("0", ((int)((EvenementPorte)evenement).position_source.Y).ToString());
                        }
                        else
                            posY = ((int)((EvenementPorte)evenement).position_source.Y).ToString();
                        positionS = String.Concat(posX, posY);
                        if (((EvenementPorte)evenement).position_destination.X < 1000)
                        {
                            if (((EvenementPorte)evenement).position_destination.X < 10)
                                posX = String.Concat("000", ((int)((EvenementPorte)evenement).position_destination.X).ToString());
                            else if (((EvenementPorte)evenement).position_destination.X < 100)
                                posX = String.Concat("00", ((int)((EvenementPorte)evenement).position_destination.X).ToString());
                            else
                                posX = String.Concat("0", ((int)((EvenementPorte)evenement).position_destination.X).ToString());
                        }
                        else
                            posX = ((int)((EvenementPorte)evenement).position_destination.X).ToString();
                        if (((EvenementPorte)evenement).position_destination.Y < 1000)
                        {
                            if (((EvenementPorte)evenement).position_destination.Y < 10)
                                posY = String.Concat("000", ((int)((EvenementPorte)evenement).position_destination.Y).ToString());
                            else if (((EvenementPorte)evenement).position_destination.Y < 100)
                                posY = String.Concat("00", ((int)((EvenementPorte)evenement).position_destination.Y).ToString());
                            else
                                posY = String.Concat("0", ((int)((EvenementPorte)evenement).position_destination.Y).ToString());
                        }
                        else
                            posY = ((int)((EvenementPorte)evenement).position_destination.Y).ToString();
                        positionC = String.Concat(posX, posY);
                        SW.WriteLine(String.Concat(positionS,positionC));
                        break;
                    case Evenement.Type_Event.Début:
                        break;
                    case Evenement.Type_Event.Fin:
                        break;
                }
            }
            SW.WriteLine("/0");
            SW.Close();
        }
        public Niveau ChargerMapVierge(Taille taille)
            //Dessine une map vierge (noir) et l'attribut au niveau indiqué
        {
            this.taille = taille;
            WIDTH = (int)taille * 10200;
            HEIGHT = (int)taille * 6000;
            NbBlocsX = WIDTH / Bloc.WIDTH;
            NbBlocsY = HEIGHT / Bloc.HEIGHT;
            this.map = new Bloc[NbBlocsX * NbBlocsY];
            for (int i = 0; i< NbBlocsX * NbBlocsY; i++)
            {
                map[i] = new Bloc(Bloc.Type.Vide, 001,new Vector2(Bloc.WIDTH * (i % NbBlocsX), Bloc.HEIGHT * (i / NbBlocsX)), Bloc.Orientation.Normal);
            }
            murs = new ArrayList();
            evenements = new ArrayList();
            evenements.Add(new Evenement(-1, "Début", Evenement.Type_Event.Début));
            ennemis = new ArrayList();
            PNJneutres = new ArrayList();
            objets = new Objet[0];
            return this;
        }
        public static String getNom(int Identifiant, String Path)
        //retourne le nom d'un objet à partir de son identifiant dans une base de données précisée
        {
            StreamReader SR = new StreamReader(String.Concat(Root,Path));
            String ligne = SR.ReadLine();
            String id;
            if (Identifiant < 10)
                id = String.Concat("00",Identifiant.ToString());
            else if (Identifiant < 100)
                id = String.Concat("0", Identifiant.ToString());
            else
                id = Identifiant.ToString();
            while (!ligne.Substring(0, 3).Equals(id))
            {
                ligne = SR.ReadLine();
            }
            SR.Close();
            return ligne.Substring(4);
        }
        public static int getID(String Nom, String Path)
        //retourne le nom d'un objet à partir de son identifiant dans une base de données précisée
        {
            StreamReader SR = new StreamReader(String.Concat(Root, Path));
            String ligne = SR.ReadLine();
            while (!ligne.Substring(4).Equals(Nom))
                ligne = SR.ReadLine();
            SR.Close();
            return int.Parse(ligne.Substring(0,3));
        }
    }
}
