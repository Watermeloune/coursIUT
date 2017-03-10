using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resonance.Niveaux
{
    class EvenementDialogue : Evenement //Parler à un PNJ
    {
        public PNJ PNJ;
        public String Dialogue;
        public EvenementDialogue()
        {

        }
        public EvenementDialogue(PNJ PNJ, int timer, String nom, String Dialogue) : base(timer, nom)
        {
            this.Dialogue = Dialogue;
            this.PNJ = PNJ;
            this.type = Type_Event.Dialogue;
        }
    }
}
