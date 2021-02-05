using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pizza_du_domaine
{
    class Personne: IContact
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

        public string Tel
        {
            get { return this.tel; }
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

        /// <summary>
        ///  Cette fonction permet d'appeler une pizzeria pour prendre commande
        /// </summary>
        /// <param name="pizzeria"></param>
        /// 
        public virtual void Appeler(Pizzeria pizzeria)
        {
            Console.Write("Appel en cours"); // pour le Menu interactif
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
            Commande commandeEnregistre = pizzeria.Decrocher(this); //on appelle la methode Decrocher qui permet de renvoyer une commande
            pizzeria.Caisse += commandeEnregistre.Prix(); // on ajoute le prix de la commande a la caisse de la pizzeria
        }

    }
}
