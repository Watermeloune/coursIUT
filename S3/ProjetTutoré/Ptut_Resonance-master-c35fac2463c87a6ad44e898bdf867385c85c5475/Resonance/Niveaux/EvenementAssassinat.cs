using System;
using System.Collections;

namespace Resonance.Niveaux
{
    class EvenementAssassinat : Evenement //Tuer des cibles;
    {
        
        public ArrayList cibles;
        public EvenementAssassinat(ArrayList cibles, int timer, String nom) : base(timer, nom)
        {
            this.cibles = cibles;
            this.type = Type_Event.Assassinat;
        }
        public EvenementAssassinat()
        {

        }
    }
}
