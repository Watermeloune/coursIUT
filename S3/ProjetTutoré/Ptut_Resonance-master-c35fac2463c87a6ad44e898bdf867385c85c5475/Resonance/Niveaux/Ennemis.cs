using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Resonance.Niveaux
{
    public class Ennemis : PNJ
    {
        public ArrayList Pattern;
        public Arme arme;
        public Aggressivité aggressivité;
        public enum Aggressivité
        {
            Statique = 0,
            Statique_Alerté=1,
            Non_armé = 2,
            Non_armé_Alerté=3,
            Armé = 4,
            Armé_Alerté=5
        }
        public bool Armé()
        {
            if (aggressivité >= Aggressivité.Armé)
                return true;
            else
                return false;
        }
        public void GetTextures(ContentManager content)
        {
            Texture = new Texture2D[nbTextures];
            Texture[0] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Bas_Stat"));
            Texture[1] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Bas_Mv1"));
            Texture[2] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Bas_Mv2"));
            Texture[3] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Gauche_Stat"));
            Texture[4] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Gauche_Mv1"));
            Texture[5] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Gauche_Mv2"));
            Texture[6] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Haut_Stat"));
            Texture[7] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Haut_Mv1"));
            Texture[8] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Haut_Mv2"));
            Texture[9] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Droite_Stat"));
            Texture[10] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Droite_Mv1"));
            Texture[11] = content.Load<Texture2D>(string.Concat("Ennemis\\", nom, "_Droite_Mv2"));
        }
        public Ennemis(int identifiant, string nomEditeur) : base(identifiant, nomEditeur)
        {
            this.nom = Niveau.getNom(identifiant, "BD_Ennemis.txt");
        }
        public Ennemis(int identifiant, Vector2 PointDepart) : base(identifiant, PointDepart)
        {
            this.nom = Niveau.getNom(identifiant, "BD_Ennemis.txt");
            Pattern = new ArrayList();
            Pattern.Add(PointDepart);
        }
        public Ennemis(int identifiant, Vector2 PointDépart, Aggressivité aggressivité, string carac_arme, ArrayList Pattern, string nomEditeur) : base(identifiant, PointDépart, nomEditeur)
        {
            this.nom = Niveau.getNom(identifiant, "BD_Ennemis.txt");
            this.Pattern = Pattern;
            this.aggressivité = aggressivité;
            if (Armé())
            {
                arme = new Arme(int.Parse(carac_arme.Substring(0, 2)), PointDépart, int.Parse(carac_arme.Substring(4, 4)), int.Parse(carac_arme.Substring(2, 2)), int.Parse(carac_arme.Substring(8, 3)),this);
            }
        }
    }
}
