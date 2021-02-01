using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProblemePizzeria
{
    class Livreur: Employer
    {

        private string moyenTransp;
       
        public Livreur(string Key, string Nom, string Prenom, string Adresse, string Tel, string RIB, string Etat, string MoyenTransp) :
            base(Key, Nom, Prenom, Adresse, Tel, RIB, Etat)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.key = Key;
            this.RIB = RIB;
            this.etat = Etat;
            this.moyenTransp = MoyenTransp;
        }
       
        public static void Livraison(Commande c)
        {
            Console.Write("Livraison");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
        
    }
}
