using System;
using Microsoft.Xna.Framework;
namespace Resonance.Niveaux
{
    class EvenementPorte : Evenement //Allez sur une case et atterir sur n'importe quelle autre case voir autre map
    {
        public Vector2 position_source;
        public Vector2 position_destination;
        public EvenementPorte()
        {

        }
        public EvenementPorte(Vector2 position_source, Vector2 position_destination, int timer, String nom) : base(timer, nom)
        {
            this.position_source = position_source;
            this.position_destination = position_destination;
            this.type = Type_Event.Porte;
        } 
    }
}
