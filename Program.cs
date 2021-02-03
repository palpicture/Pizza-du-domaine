using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ProblemePizzeria
{
    class Program
    {
        public static List<Item> Stock(string fichier, bool affichage)
        {
            StreamReader lecteur = new StreamReader(fichier);
            string ligne = "";
            List<Item> listItems = new List<Item>();
            //var lineCount = File.ReadLines(fichier).Count();
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine(); // lis les items
                if (ligne != null)
                {
                    string[] motsFichier = ligne.Split(';');   // split des mots à comparés, séparés par un ;
                    listItems.Add(new Item(motsFichier[1], motsFichier[0], Convert.ToDouble(motsFichier[2])));
                }
            }
            lecteur.Close();
            if (affichage)
            {
                int compteur = 1;
                foreach (Item element in listItems)
                {
                    if (element != null)
                    {
                        Console.WriteLine(compteur+"*" + element);
                        compteur++;
                    }
                }
            }
            return listItems;
        }

        public static List<Pizza> Menu(string fichier, bool affichage)
        {
            StreamReader lecteur = new StreamReader(fichier);
            string ligne = "";
            List<Pizza> listItems = new List<Pizza>();
            //var lineCount = File.ReadLines(fichier).Count();
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine(); // lis les items
                if (ligne != null)
                {
                    string[] motsFichier = ligne.Split(';');   // split des mots à comparés, séparés par un ;

                    listItems.Add(new Pizza(motsFichier[0], motsFichier[1], Convert.ToDouble(motsFichier[2])));
                }
            }
            lecteur.Close();
            if (affichage)
            {
                int compteur = 1;
                foreach (Pizza element in listItems)
                {
                    if (element != null)
                    {
                        Console.WriteLine(compteur + "*" + element);
                        compteur++;
                    }
                }
            }
            return listItems;
        }

        public static List<Personne> Annuaire(string fichier, bool affichage)
        {
            StreamReader lecteur = new StreamReader(fichier);
            string ligne = "";
            List<Personne> listItems = new List<Personne>();
            //var lineCount = File.ReadLines(fichier).Count();
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine(); // lis les items
                if (ligne != null)
                {
                    string[] motsFichier = ligne.Split(';');   // split des mots à comparés, séparés par un ;
                    listItems.Add(new Personne(motsFichier[0], motsFichier[1], motsFichier[2], motsFichier[3]));
                }
            }
            lecteur.Close();
            if (affichage)
            {

                foreach (Personne element in listItems)
                {
                    if (element != null)
                    {
                        Console.WriteLine(element);
                    }
                }
            }
            return listItems;
        }
        static void Main(string[] args)
        {
            //Client Hugo = new Client("Nabeth", "Hugo", "18 rue Gabriel Faure", "0665570792)
            //Console.WriteLine(Hugo);
            //Stock("items.txt", true);

            Menu("pizzas.txt", false);
            List<Personne> listPersonne = Annuaire("annuaire.txt", false);
            Personne hugo = listPersonne[0];
            Pizzeria Dominos = new Pizzeria("Dominos", "adresse", "01815466");
            hugo.Appeler(Dominos);

            Console.ReadKey();
        }
    }
}
