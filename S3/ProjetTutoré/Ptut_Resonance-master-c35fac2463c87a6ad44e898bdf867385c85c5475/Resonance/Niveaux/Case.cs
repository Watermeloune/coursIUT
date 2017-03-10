using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Resonance.Core;

namespace Resonance.Niveaux
{
    public class Case : GameObject
    {
        public static int Width=50;
        public static int Height=50;
        public int identifiant;
        public Type type;
        public GameObject Contour_Sélection;
        public enum Type
        {
            Ajout=-1,
            Bloc =0,
            Mur=1,
            Objet=2,
            Ennemis=3,
            PNJ_Neutres=4
        }
        public bool DansCase(Vector2 Position)
        {
            return Position.X >= this.Position.X && Position.Y >= this.Position.Y && Position.X <= this.Position.X + Width && Position.Y <= this.Position.Y + Height;
        }
        public Case(int identifiant, Type type, Vector2 Position)
        {
            this.Position = Position;
            this.identifiant = identifiant;
            this.type = type;
            Contour_Sélection = new GameObject();
            Contour_Sélection.Position = new Vector2(Position.X - 3/ 2, Position.Y - 3);
        }
    }
}
