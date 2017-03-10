using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Resonance.Niveaux
{
    public class PNJ
    {
        public const int nbTextures = 12;
        public Texture2D[] Texture;
        public Vector2 Position;
        public Vector2 PointDépart;
        public int identifiant;
        public string nom;
        public string nomEditeur;
        public string nomréel;

        public void Draw(SpriteBatch spriteBatch, Vector2 Position_dans_ecran , int frame)
        {
            spriteBatch.Draw(Texture[frame], Position_dans_ecran, Color.White);
        }
        public PNJ(int identifiant, Vector2 PointDépart)
        {
            this.identifiant = identifiant;
            
            this.PointDépart = PointDépart;
            Position = PointDépart;
        }
        public PNJ(int identifiant, string nomEditeur)
        {
            this.identifiant = identifiant;
            this.nomEditeur = nomEditeur;
        }
        public PNJ(int identifiant, Vector2 PointDépart, string nomEditeur)
        {
            this.identifiant = identifiant;
            this.PointDépart = PointDépart;
            this.nomEditeur = nomEditeur;
            Position = PointDépart;
        }
    }
}
