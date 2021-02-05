using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_du_domaine
{
    class Employer: Personne
    {
        protected string key;
        protected string RIB;
        protected string etat;

        public Employer(string Key, string Nom, string Prenom, string Adresse, string Tel, string RIB, string Etat):
            base(Nom, Prenom, Adresse, Tel)
        {
            this.key = Key;
        }

        public string Key // clé unique pour un employer
        {
            get { return this.key; }
        }

        public string Etat // soit present, congé
        {
            get { return this.etat; }
            set { this.etat = value; }
        }

        public string ReleveId
        {
            get { return this.RIB; }
        }


    }
}
