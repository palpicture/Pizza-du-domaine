using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        public virtual void Appeler(string telPizzeria)
        {
            Repertoire r = new Repertoire("repertoire.txt");
            List<Pizzeria> repertoire = r.CentreAppel;
            bool test = false;
            foreach (Pizzeria element in repertoire) // verifie si le telephone d'une pizzeria est dans le repertoire
            {
                if (element.Telephone == telPizzeria)
                {
                    Console.Write("Appel en cours");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine();
                    element.Decrocher(this);
                    test = true;
                }
            }
            if (!test)
            {
                Console.WriteLine("Telephone introuvable...");
            }
        }

        public string Tel
        {
            get { return this.tel; }
        }

     



    }
}
