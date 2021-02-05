using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pizza_du_domaine
{
    class Client: Personne
    {
        private List<Commande> historique = new List<Commande>();
        private DateTime dateCommande;
        private double cumul;

        public Client(string Nom, string Prenom, string Adresse, string Tel, List<Commande> Historique, DateTime DateCommande) :
            base(Nom, Prenom, Adresse, Tel)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.adresse = Adresse;
            this.tel = Tel;
            this.historique = Historique;
            this.dateCommande = DateCommande;
            this.cumul = CalculCumul();
        }

        public Client(string Nom, string Prenom, string Adresse, string Tel) :
            base(Nom, Prenom, Adresse, Tel)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.adresse = Adresse;
            this.tel = Tel;
            this.historique = new List<Commande>();
            this.cumul = CalculCumul();
        }


        #region Prorietes
        public List<Commande> Historiques
        {
            get { return this.historique; }
            set { this.historique = value; }
        }

        public double Cumul { get { return cumul; } }
        #endregion

        public override void Appeler(Pizzeria pizzeria)
        {
            base.Appeler(pizzeria);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        public double CalculCumul() //Calcul le cumulle des commandes passé par le client
        {
            double res = 0;
            foreach(Commande a in historique)
            {
                res += a.Prix();
            }
            return res;
        }

        public void AddCommande(Commande commande)
        {
            historique.Add(commande);
        }
    }
}
