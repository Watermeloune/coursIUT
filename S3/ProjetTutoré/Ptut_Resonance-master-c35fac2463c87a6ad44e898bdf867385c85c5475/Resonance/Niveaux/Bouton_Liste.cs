using System;
using Resonance.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Resonance.Niveaux
{
    class Bouton_Liste : Bouton
    {
        public int longueur;
        public int largeur;
        public GameObject Contour_Sélection;
        public Bouton_Liste(Vector2 Position) : base(Position)
        {
            Contour_Sélection = new GameObject();
            Contour_Sélection.Position = new Vector2(Position.X - Menu_Latéral.intervalle / 2, Position.Y - Menu_Latéral.intervalle / 2);
        }
        public bool CheckSelection()
        //Vérifie si le curseur de la souris est dans la hitbox du bouton
        {
            if (Mouse.GetState().Position.X >= Position.X && Mouse.GetState().Position.Y >= Position.Y && Mouse.GetState().Position.X <= Position.X + longueur && Mouse.GetState().Position.Y <= Position.Y + largeur) return true;
            else return false;
        }
    }
}
