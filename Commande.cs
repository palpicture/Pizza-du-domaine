using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Commande
    {

        public string numCommande;
        public DateTime dateCommande;
        public Client client;
        public Commis commis;
        public List<Item> items;
        public List<Pizza> listPizzas;

        public Commande(string Num, DateTime DateCommande, List<Item> Items, List<Pizza> ListPizzas, Client Client, Commis Commis)
        {
            this.numCommande = Num;
            this.dateCommande = DateCommande;
            this.client = Client;
            this.commis = Commis;
            this.items = Items;
            this.listPizzas = ListPizzas;
        }

        public Commande(string Num, DateTime DateCommande, List<Item> Items, List<Pizza> ListPizzas)
        {
            this.numCommande = Num;
            this.dateCommande = DateCommande;
            this.items = Items;
            this.listPizzas = ListPizzas;
        }

        public string Facture(double prix)
        {
            string retour = "";
            retour += "Commande: " + this.numCommande + ",Date: "+ this.dateCommande + "\n";
            retour += "Client: " + this.client.Nom + ", " + this.client.Prenom + "\n";
            retour += "___________________\n";
            this.listPizzas.ForEach(item => retour += item.ToString() + "\n");
            this.items.ForEach(item => retour += item.ToString() + "\n");
            retour += "-----------------" + prix + "$\n";
            return retour;
        }

        
    }
}
