using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Resonance.Core
{
    class TextArea : GameObject
    {
        public String texte;
        public Color couleur;
        public SpriteFont textfont;
        public float longueur;
        public float largeur;
        public void Draw(SpriteBatch spritebatch, float echelle)
        {
            longueur = textfont.MeasureString(texte).X;
            largeur = textfont.MeasureString(texte).Y;
            spritebatch.DrawString(textfont, texte, Position, couleur, 0, new Vector2(0, 0) / 2, echelle, SpriteEffects.None, 0);
        }
        public TextArea(String texte, Color couleur)
        {
            this.texte = texte;
            this.couleur = couleur;
        }
    }
}
