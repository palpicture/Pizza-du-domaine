using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Commis: Employer
    {
        private DateTime dateEmbauche;

        public Commis(string Nom, string Prenom, string Adresse, string Tel, string Key, string RIB, string Etat, DateTime DateEmbauche):
            base(Nom, Prenom, Adresse, Tel, Key, RIB, Etat)
        {
            this.nom = Nom;
            this.prenom = Prenom;
            this.key = Key;
            this.RIB = RIB;
            this.etat = Etat;
            this.dateEmbauche = DateEmbauche;
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
            List<Pizza> listPizza = null;
            List<Item> listItem = null;
            Console.WriteLine("Que voulez vous manger ?");
            Console.WriteLine("Tapez 0 pour quitter");
            bool quit = false;
            int choix = 0;
            double prix = 0;
            while(!quit)
            {
                if (choix == 0)
                {
                    Console.WriteLine("*Pizza => Tapez 1");
                    Console.WriteLine("*Accompagnements => Tapez 2");
                    Console.WriteLine("*Regler la commande => Tapez 3");
                    Console.WriteLine("Quitter => Tapez 0");
                    choix = Convert.ToInt32(Console.ReadLine());
                    switch (choix)
                    {
                        case 0: //pour quitter
                            {
                                quit = true;
                                break;
                            }
                        case 1: // pour les pizzas
                            {
                                List<Pizza> pizza = Program.Menu("menu.txt", true);
                                Console.WriteLine("Choissisez vos pizzas: ");
                                Console.WriteLine("Tapez le numero: ");
                                Console.WriteLine("Quitter => Tapez 0");
                                int choix1 = -1;
                                while (choix1 != 0)
                                {
                                    choix1 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Quelle est la taille ?");
                                    string taille = Console.ReadLine().ToLower();
                                    Pizza pizzaChoix = pizza[choix1 - 1];
                                    Pizza pizzaFinal = new Pizza(pizzaChoix.Nom, taille, pizzaChoix.Type, pizzaChoix.Prix);
                                    listPizza.Add(pizzaFinal);
                                }
                                break;
                            }
                        case 2: // pour les accompagnements
                            {
                                List<Item> items = Program.Stock("item.txt", true);
                                Console.WriteLine("Choissisez vos accompagnements: ");
                                Console.WriteLine("Tapez le numero: ");
                                Console.WriteLine("Quitter => Tapez 0");
                                int choix2 = -1;
                                while (choix2 != 0)
                                {
                                    choix2 = Convert.ToInt32(Console.ReadLine());
                                    listItem.Add(items[choix2 - 1]);
                                }
                                break;
                            }
                        case 3: // regler la commande: calcul du prix
                            {
                                listPizza.ForEach(item => prix += item.PrixFinal());
                                listItem.ForEach(item => prix += item.Prix);
                                break;
                            }
                    }
                }
            }
            Commande commande = new Commande(numCommande, dateCommande, listItem, listPizza);
            Livreur.Livraison(commande);
            commande.Facture(prix);
            return commande;
        }
        









    }
}
