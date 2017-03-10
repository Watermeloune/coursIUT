using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Resonance.Niveaux
{
    public class PNJ_Neutres : PNJ
    {
        public Evenement déclencheur;
        public string dialogue;
        public Role role;
        public enum Role
        {
            Random = 0,
            Garde_neutre = 1,
            Otage = 2
            
        }
        public void GetTextures(ContentManager content)
        {
            Texture = new Texture2D[nbTextures];
            Texture[0] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Bas_Stat"));
            Texture[1] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Bas_Mv1"));
            Texture[2] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Bas_Mv2"));
            Texture[3] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Gauche_Stat"));
            Texture[4] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Gauche_Mv1"));
            Texture[5] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Gauche_Mv2"));
            Texture[6] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Haut_Stat"));
            Texture[7] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Haut_Mv1"));
            Texture[8] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Haut_Mv2"));
            Texture[9] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Droite_Stat"));
            Texture[10] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Droite_Mv1"));
            Texture[11] = content.Load<Texture2D>(string.Concat("PNJ\\", nom, "_Droite_Mv2"));
        }
        public PNJ_Neutres(int identifiant, Vector2 PointDepart) : base(identifiant, PointDepart)
        {
            this.nom = Niveau.getNom(identifiant, "BD_PNJs.txt");
        }
        public PNJ_Neutres(int identifiant, Vector2 PointDépart, Evenement déclencheur,  Role role, string dialogue, string nomEditeur) : base(identifiant, PointDépart, nomEditeur)
        {
            this.nom = Niveau.getNom(identifiant, "BD_PNJs.txt");
            this.déclencheur = déclencheur;
            this.dialogue = dialogue;
            this.role = role;
        }
    }
}
