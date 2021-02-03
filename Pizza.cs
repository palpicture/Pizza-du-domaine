using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_du_domaine
{
    class Pizza
    {
        private string nom;
        private string taille;
        private string type;
        private double prixbase;
        private double prixmoyen;
        private double prixgrand;

        public Pizza(string Nom, string Taille, string Type, double Prix)
        {
            this.nom = Nom;
            this.taille = Taille;
            this.type = Type;
            this.prixbase = Prix;
            this.prixmoyen = Prix * 1.2;
            this.prixgrand = Prix * 1.3;
        }

        public Pizza(string Nom, string Type, double Prix)
        {
            this.nom = Nom;
            this.type = Type;
            this.prixbase = Prix;
            this.prixmoyen = Prix * 1.2;
            this.prixgrand = Prix * 1.3;
        }

        public string Nom
        {
            get { return this.nom; }
        }

        public string Type
        {
            get { return this.type; }
        }

        public string Taille
        {
            get { return this.taille; }
        }

        public double Prix
        {
            get { return this.prixbase; }
        }
        public double PrixMoyen
        {
            get { return this.prixmoyen; }
        }
        public double PrixGrand
        {
            get { return this.prixgrand; }
        }

        public double PrixFinal()
        {
            double prix = this.prixbase; // prix de base pour la taille petite
            switch(this.taille)
            {
                case "petite":
                    {
                        prix = this.prixbase;
                        break;
                    }
                case "moyenne":
                    {
                        prix = prix * 1.2; // + 20% du prix de base
                        break;
                    }
                case "grande":
                    {
                        prix = prix * 1.3; // + 30% du prix de base
                        break;
                    }
            }
            return prix;
        }

        public override string ToString()
        {
            string retour = this.nom;
            int intervalle = 25 - this.nom.Length;
            for (int i = 0; i < intervalle; i++)
            {
                retour += "-";
            }
            retour += this.PrixFinal() + "$";
            return retour;
        }
    }
}
