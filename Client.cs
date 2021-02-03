using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Client: Personne
    {
        private List<Commande> historique = new List<Commande>();
        private DateTime dateCommande;

        public Client(string Nom, string Prenom, string Adresse, string Tel, List<Commande> Historique, DateTime DateCommande) :
            base(Nom, Prenom, Adresse, Tel)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.adresse = Adresse;
            this.tel = Tel;
            this.historique = Historique;
            this.dateCommande = DateCommande;
        }

        public Client(string Nom, string Prenom, string Adresse, string Tel) :
            base(Nom, Prenom, Adresse, Tel)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.adresse = Adresse;
            this.tel = Tel;
        }


        #region Prorietes
        public List<Commande> Historiques
        {
            get { return this.historique; }
            set { this.historique = value; }
        }
        #endregion

        public override void Appeler(Pizzeria pizzeria)
        {
            Console.Write("Appel en cours");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
            pizzeria.Decrocher(this);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
