using System;
using Microsoft.Xna.Framework;

namespace Resonance.Niveaux
{
    public class Bloc : Core.GameObject
    {
        public Type type;
        public Orientation orientation;
        public int identifiant;
        public String nom;
        public const int HEIGHT=50;
        public const int WIDTH=50;
        public enum Type
        {
            Null=0,
            Vide =1,
            Sol =2,
            Mur=3
        }
        public enum Orientation
        {
            Normal = 0,
            Droite = 1,
            Retourné = 2,
            Gauche = 3
        }
        public Bloc(Type type, int identifiant, Vector2 Position, Orientation orientation)
        {
            this.type = type;
            this.identifiant = identifiant;
            this.nom = Niveau.getNom(this.identifiant, "BD_Blocs.txt");
            this.Position = Position;
            this.orientation = orientation;
        }
        public Bloc(Type type, int identifiant, String nom)
        {
            this.type = type;
            this.identifiant = identifiant;
            this.nom = nom;
            this.orientation = Orientation.Normal;
        }
    }
}
