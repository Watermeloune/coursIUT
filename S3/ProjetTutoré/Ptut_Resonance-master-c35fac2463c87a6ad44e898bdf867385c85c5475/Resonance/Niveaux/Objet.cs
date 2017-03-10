using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Resonance.Niveaux
{
    public class Objet : Core.GameObject
    {
        public Type type;
        public String nom;
        public const int min_id_arme = 50;
        public enum Type
        {
            Décor,
            Lunettes_Infrarouge,
            Bombe,
            Carte,
            Arme
            //...
        }
        public Objet(int identifiant, Vector2 Position)
        {
            type = (Type) identifiant;
            nom = Niveau.getNom(identifiant, "BD_Objets.txt");

            this.Position = Position;
        }
    }
}
