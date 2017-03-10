using System;
using Resonance.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Resonance.Niveaux
{
    public class Bouton : GameObject
    {
        public int longueur;
        public int largeur;
        public bool On_Cliq;
        public bool Clic_valide;
        public bool CheckSelection()
        //Vérifie si le curseur de la souris est dans la hitbox du bouton
        {
            if (Mouse.GetState().Position.X >= Position.X && Mouse.GetState().Position.Y >= Position.Y && Mouse.GetState().Position.X <= Position.X + longueur && Mouse.GetState().Position.Y <= Position.Y + largeur) return true;
            else return false;
        }
        public void SetOnClic()
        {
            On_Cliq = true;
            Position += Vector2.One;
        }
        public void SetOffClic()
        {
            On_Cliq = false;
            Position -= Vector2.One;
        }
        public void checkBouton()
        {
            if (CheckSelection())
            {
                if (!On_Cliq)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        SetOnClic();
                }
                else if (Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    SetOffClic();
                    Clic_valide = true;
                }
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Released && On_Cliq)
                SetOffClic();
        }
        public Bouton(Vector2 Position)
        {
            this.Position = Position;
            On_Cliq = false;
            Clic_valide = false;
        }
        public Bouton(Vector2 Position, Texture2D Texture)
        {
            this.Position = Position;
            this.Texture = Texture;
            longueur = Texture.Width;
            largeur = Texture.Height;
            On_Cliq = false;
            Clic_valide = false;
        }
    }
}
