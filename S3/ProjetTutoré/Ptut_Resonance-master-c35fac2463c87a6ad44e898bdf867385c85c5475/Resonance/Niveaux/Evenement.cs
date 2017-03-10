using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resonance.Niveaux
{
    public class Evenement
    {
        public int timer;
        public Evenement Conséquence;
        public Type_Event type;
        public String nom;
        public enum Type_Event
        {
            Indéfini,
            Assassinat,
            Dialogue,
            Objet,
            Porte,
            Début,
            Fin
        }
        public bool Assassinat()
        {
            if (this.type == Evenement.Type_Event.Assassinat) return true;
            else return false;
        }
        public bool Dialogue()
        {
            if (this.type == Evenement.Type_Event.Dialogue) return true;
            else return false;
        }
        public bool Objet()
        {
            if (this.type == Evenement.Type_Event.Objet) return true;
            else return false;
        }
        public bool Porte()
        {
            if (this.type == Evenement.Type_Event.Porte) return true;
            else return false;
        }
        public Evenement()
        {

        }
        public Evenement(int timer, String nom)
        {
            this.timer = timer;
            this.nom = nom;
        }
        public Evenement(int timer, String nom, Type_Event type)
        {
            this.timer = timer;
            this.nom = nom;
            this.type = type;
        }
    }
}
