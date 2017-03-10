using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using Resonance.Core;

namespace Resonance.Niveaux
{
    class ListeEvènement : Liste
    {
        public ListeEvènement(Color colorText, Vector2 Position, ArrayList DataList) : base(Position, DataList)
        {
            textAreas.Add(new TextArea("Nouvel Evènement", colorText));
            foreach (Evenement Data in DataListe)
            {
                this.textAreas.Add(new TextArea(Data.nom, colorText));
            }
        }
        public void LoadListe(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            bouton.Texture = content.Load<Texture2D>("icone_event");
            bouton.longueur = bouton.Texture.Width;
            bouton.largeur = bouton.Texture.Height;
            texturetype = content.Load<Texture2D>("texturetype_évènements");
            for (int i = 0; i < textAreas.Count; i++)
            {
                BoutonsText.Add(new Bouton(bouton.Position + new Vector2(0, bouton.Texture.Height + texturetype.Height * i), texturetype));
                ((TextArea)textAreas[i]).Position = ((Bouton)BoutonsText[i]).Position + new Vector2(marge, marge / 2);
                ((TextArea)textAreas[i]).textfont = content.Load<SpriteFont>("PoliceEditeurListes");
                if (((TextArea)textAreas[i]).textfont.MeasureString(((TextArea)textAreas[i]).texte).X > bouton.Texture.Width - marge * 2)
                {
                    do
                    {
                        ((TextArea)textAreas[i]).texte = ((TextArea)textAreas[i]).texte.Remove(((TextArea)textAreas[i]).texte.Length - 1, 1);
                    }
                    while (((TextArea)textAreas[i]).textfont.MeasureString(((TextArea)textAreas[i]).texte).X > bouton.Texture.Width - marge * 2);
                    ((TextArea)textAreas[i]).texte = ((TextArea)textAreas[i]).texte.Insert(((TextArea)textAreas[i]).texte.Length, "...");
                }

            }
        }
    }
}
