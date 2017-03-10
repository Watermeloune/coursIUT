using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using Resonance.Core;

namespace Resonance.Niveaux
{
    public class Liste
    {
        public ArrayList DataListe;
        public ArrayList textAreas;
        public ArrayList BoutonsText;
        public Bouton bouton;
        public Texture2D texturetype;
        public bool selection;
        public const int marge = 15;

        public void DrawListe(SpriteBatch spriteBatch)
        {
            bouton.Draw(spriteBatch);
            if (selection) 
                for (int i = 0; i < textAreas.Count; i++)
                {
                    ((Bouton)BoutonsText[i]).Draw(spriteBatch);
                    ((TextArea)textAreas[i]).Draw(spriteBatch, 1);
                };
            
        }

        public Liste(Vector2 Position, ArrayList DataListe)
        {
            this.DataListe = DataListe;
            this.textAreas = new ArrayList();
            this.BoutonsText = new ArrayList();
            bouton = new Bouton(Position);
            selection = false;
            
        }
    }
}
