using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Client: Personne, IContact
    {
        private List<Commande> historique;
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

        #region Prorietes
        public string Nom
        {
            get { return this.nom; }
        }

        public string Prenom
        {
            get { return this.prenom; }
        }
        public string Adresse
        {
            get { return this.adresse; }
        }
        public string Telephone
        {
            get { return this.tel; }
        }
        #endregion

        public override string ToString()
        {
            return base.ToString();
        }

        public void Appeler(string telPizzeria)
        {
            Repertoire r = new Repertoire("repertoire.txt");
            List<Pizzeria> repertoire = r.CentreAppel;
            bool test = false;
            foreach(Pizzeria element in repertoire) // verifie si le telephone d'une pizzeria est dans le repertoire
            {
                if(element.Telephone == telPizzeria)
                {
                    Console.WriteLine("Appelle en cours...");
                    //new Client(this.nom, this.prenom, this.adresse, this.tel, this.historique, this.dateCommande)
                    Client c = new Client(this.nom, this.prenom, this.adresse, this.tel, this.historique, this.dateCommande);
                    this.historique.Add(element.Decrocher(c)); // on ajoute cette commande a son historique
                    test = true;
                }                    
            }
            if(!test)
            {
                Console.WriteLine("Telephone introuvable...");
            }
        }
    }
}
