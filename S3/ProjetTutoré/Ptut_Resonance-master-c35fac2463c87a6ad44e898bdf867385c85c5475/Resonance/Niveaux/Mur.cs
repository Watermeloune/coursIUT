using System;
using Microsoft.Xna.Framework;

namespace Resonance.Niveaux
{
    public class Mur : Core.GameObject
    {
        public Côté côté;
        public enum Côté
        {
            Haut = 0,
            Droite = 1,
            Bas = 2,
            Gauche = 3
        }
        public int identifiant;
        public String nom;
        public const int HEIGHT = 30;
        public const int WIDTH = 30;
        public Mur(int identifiant, Vector2 Position, Côté côté)
        {
            this.identifiant = identifiant;
            this.nom = Niveau.getNom(this.identifiant, "BD_Blocs.txt");
            this.Position = Position;
            this.côté = côté;
        }
    }
}
