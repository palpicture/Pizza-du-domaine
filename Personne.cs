using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Personne
    {
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected string tel;

        public Personne(string Nom, string Prenom, string Adresse, string Tel)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.adresse = Adresse;
            this.tel = Tel;
        }

        public override string ToString()
        {
            string retour = "";
            retour += "Nom: " + this.nom + "\n";
            retour += "Prenom: " + this.prenom + "\n";
            retour += "Adresse: " + this.adresse + "\n";
            retour += "Tel: " + this.tel + "\n";

            return retour;
        }

        /*public abstract string Nom
        {
            get;
        }

        public abstract string Prenom
        {
            get;
        }
        public abstract string Adresse
        {
            get;
        }
        public abstract string Tel
        {
            get;
        }*/



    }
}
