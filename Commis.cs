using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_du_domaine
{
    class Commis: Employer
    {
        private DateTime dateEmbauche;

        public Commis(string Key, string Nom, string Prenom, string Adresse, string Tel, string RIB, string Etat):
            base(Key, Nom, Prenom, Adresse, Tel, RIB, Etat)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.key = Key;
            this.RIB = RIB;
            this.etat = Etat;
            this.dateEmbauche = DateTime.Now;
        }

        #region Prorietes      
        public string Etat // soit present, congé
        {
            get { return this.etat; }
            set { this.etat = value; }
        }
        #endregion
        
        public Commande PrendreCommande(Client c)
        {
            Random rnd = new Random();
            string numCommande = Convert.ToString(rnd.Next(0, 10000));
            DateTime dateCommande = new DateTime().Date;
            List<Pizza> listPizza = new List<Pizza>();
            List<Item> listItem = new List<Item>();
            Console.WriteLine("Bonjour!\nQue voulez vous manger ?");
            bool quit = false;
            int choix = 0;
            double prix = 0;
            while(!quit)
            {
                if (choix == 0)
                {
                    Console.WriteLine("Accueil");
                    Console.WriteLine("*Pizza => Tapez 1");
                    Console.WriteLine("*Accompagnements => Tapez 2");
                    Console.WriteLine("Quitter (affiche la facture) => Tapez 0");
                    choix = Convert.ToInt32(Console.ReadLine());
                    switch (choix)
                    {
                        case 0: //pour quitter
                            {
                                listPizza.ForEach(item => prix += item.PrixFinal());
                                listItem.ForEach(item => prix += item.Prix);
                                choix = 0;
                                quit = true;
                                break;
                            }
                        case 1: // pour les pizzas
                            {
                                List<Pizza> pizza = Program.Menu("pizzas.txt", true);
                                Console.WriteLine("\nChoissisez vos pizzas: ");                             
                                int choix1 = -1;
                                while (choix1 != 0)
                                {
                                    Console.WriteLine("Tapez le numero: ");
                                    Console.WriteLine("Quitter => Tapez 0");
                                    choix1 = Convert.ToInt32(Console.ReadLine());
                                    if (choix1 != 0)
                                    {                                       
                                        Pizza pizzaChoix = pizza[choix1 - 1];
                                        Console.WriteLine("Quelle est la taille de la " + pizzaChoix.Nom + "? (p, m, g)");
                                        string taille = Console.ReadLine().ToLower();
                                        Pizza pizzaFinal = new Pizza(pizzaChoix.Nom, taille, pizzaChoix.Type, pizzaChoix.Prix);
                                        listPizza.Add(pizzaFinal);
                                    }
                                }
                                choix = 0;
                                break;
                            }
                        case 2: // pour les accompagnements
                            {
                                List<Item> items = Program.Stock("items.txt", true);
                                Console.WriteLine("\nChoissisez vos accompagnements: ");
                                Console.WriteLine("Tapez le numero: ");
                                Console.WriteLine("Quitter => Tapez 0");
                                int choix2 = -1;
                                while (choix2 != 0)
                                {
                                    choix2 = Convert.ToInt32(Console.ReadLine());
                                    if (choix2 != 0)
                                    {
                                        listItem.Add(items[choix2 - 1]);
                                        Console.WriteLine("Tapez le numero: ");
                                    }                                   
                                }
                                choix = 0;
                                break;
                            }
                    }
                }
            }
            Commande commande = new Commande(numCommande, dateCommande, listItem, listPizza, c, this);
            Console.WriteLine(commande.Facture(prix));
            Livreur.Livraison(commande);
            
            return commande;
        }


    }
}
