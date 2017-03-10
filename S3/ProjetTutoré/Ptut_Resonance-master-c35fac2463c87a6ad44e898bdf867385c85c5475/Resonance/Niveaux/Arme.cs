using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace Resonance.Niveaux
{
    public class Arme : Objet
    {
        public int portée;
        public int dégats;
        public int fréquence;
        public Ennemis propriétaire;
        public Arme(int identifiant, Vector2 Position, int portée, int dégats, int fréquence, Ennemis propriétaire) : base(identifiant, Position)
        {
            this.portée = portée;
            this.dégats = dégats;
            this.fréquence = fréquence;
            this.propriétaire = propriétaire;
        }
    }
}
