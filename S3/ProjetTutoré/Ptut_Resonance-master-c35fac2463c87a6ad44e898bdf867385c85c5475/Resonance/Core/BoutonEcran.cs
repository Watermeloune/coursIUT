using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Resonance.Core
{
    class BoutonEcran
    {
        public Vector2 position;
        public float longueur;
        public float largeur;
        public String texte;
        public Color couleur;
        public SpriteFont textfont;
        public BoutonEcran(Vector2 position, String texte)
        {
            this.position = position;
            this.texte = texte; 
            couleur = Color.White;
        }
        public void Draw(SpriteBatch spritebatch, SpriteFont textfont, float echelle)
        {
            this.textfont = textfont;
            longueur = textfont.MeasureString(texte).X;
            largeur = textfont.MeasureString(texte).Y;
            spritebatch.DrawString(textfont, texte, position, couleur, 0, new Vector2(longueur, largeur) / 2, echelle, SpriteEffects.None, 0);
        }
        public bool CheckSelection()
        //Vérifie si le curseur de la souris est dans la hitbox du bouton
        {
            if (Mouse.GetState().Position.X >= position.X-longueur/2 && Mouse.GetState().Position.Y >= position.Y - largeur / 2 && Mouse.GetState().Position.X <= position.X+longueur/2 && Mouse.GetState().Position.Y <= position.Y+largeur/2) return true;
            else return false;
        }
    }
}
