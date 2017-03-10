using System;

namespace Resonance.Niveaux
{
    class EvenementObjet : Evenement //Obtenir un objet
    {
        public Objet objet;
        public EvenementObjet()
        {

        }
        public EvenementObjet(Objet objet, int timer, String nom) : base(timer, nom)
        {
            this.objet = objet;
            this.type = Type_Event.Objet;
        }
    }
}
