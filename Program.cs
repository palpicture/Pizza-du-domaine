using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Pizza_du_domaine
{
    class Program
    {
        public static List<Pizza> menu;
        public static List<Item> items;
        public static List<Personne> personnes;
        public static List<Pizza> commandeP;
        public static List<Item> commandeI;
        public static List<Commande> commandes;
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
                    if (motsFichier[0].ToLower() == "client")
                    {
                        listItems.Add(new Client(motsFichier[1], motsFichier[2], motsFichier[3], motsFichier[4]));
                    }
                    else if (motsFichier[0].ToLower() == "commis" && motsFichier.Length > 7) 
                    {
                        listItems.Add(new Commis(motsFichier[1], motsFichier[2], motsFichier[3], motsFichier[4], motsFichier[5], motsFichier[6], motsFichier[7]));
                    }
                    else if (motsFichier[0].ToLower() == "livreur" && motsFichier.Length > 8)
                    {
                        listItems.Add(new Livreur(motsFichier[1], motsFichier[2], motsFichier[3], motsFichier[4], motsFichier[5], motsFichier[6], motsFichier[7], motsFichier[8]));
                    }
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

        public static void Sauvegarder(List<Commis> liste)
        {
            var lines = File.ReadLines("effectifs.txt").Count();
            foreach (Commis element in liste)
            {
                if (element != null)
                {
                    using (StreamWriter writer = File.AppendText("effectifs.txt"))
                    {
                        writer.WriteLine("Commis;" + lines + ";" + element.Nom + ";" + element.Prenom + ";" + element.Adresse + ";" + element.Tel + ";" + element.ReleveId + ";" + element.Etat);
                    }
                }
            }
        }
        public static void Sauvegarder(List<Livreur> liste)
        {
            var lines = File.ReadLines("effectifs.txt").Count();
            foreach (Livreur element in liste)
            {
                if (element != null)
                {
                    using (StreamWriter writer = File.AppendText("effectifs.txt"))
                    {
                        writer.WriteLine("Commis;" + lines + ";" + element.Nom + ";" + element.Prenom + ";" + element.Adresse + ";" + element.Tel + ";" + element.ReleveId + ";" + element.Etat + ";" + element.MoyenTransport);
                    }
                }
            }
        }
        public static void Sauvegarder(List<Personne> liste)
        {
            var lines = File.ReadLines("annuaire.txt").Count();
            foreach (Personne element in liste)
            {
                if (element != null)
                {
                    using (StreamWriter writer = File.AppendText("annuaire.txt"))
                    {
                        writer.WriteLine(element.Nom + ";" + element.Prenom + ";" + element.Adresse + ";" + element.Tel);
                    }
                }
            }
        }

        public static List<Commis> FindCommis(List<Commis> liste, string cherche)
        {
            List<Commis> res = new List<Commis>();
            foreach (Commis a in liste)
            {
                if (a.Nom.ToLower().Contains(cherche.ToLower()))
                {
                    res.Add(a);
                }
            }
            return res;
        }

        public static List<Livreur> FindLivreur(List<Livreur> liste, string cherche)
        {
            List<Livreur> res = new List<Livreur>();
            foreach (Livreur a in liste)
            {
                if (a.Nom.ToLower().Contains(cherche.ToLower()))
                {
                    res.Add(a);
                }
            }
            return res;
        }

        public static List<Client> FindClient(List<Personne> liste, string cherche)
        {
            List<Client> res = new List<Client>();
            foreach (Personne a in liste)
            {
                if (a is Client)
                {
                    if (a.Nom.ToLower().Contains(cherche.ToLower()))
                    {
                        res.Add((Client)a);
                    }
                    else if (a.Adresse.ToLower().Contains(cherche.ToLower()))
                    {
                        res.Add((Client)a);
                    }
                    else if (a.Tel.ToLower().Contains(cherche.ToLower()))
                    {
                        res.Add((Client)a);
                    }
                    else if (a.Prenom.ToLower().Contains(cherche.ToLower()))
                    {
                        res.Add((Client)a);
                    }
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            //Client Hugo = new Client("Nabeth", "Hugo", "18 rue Gabriel Faure", "0665570792)
            //Console.WriteLine(Hugo);

            //Stock("items.txt", true);
            Annuaire("annuaire.txt", true);
            Menu("pizzas.txt", true);
            //Console.WriteLine(repertoire);
            List<Personne> listPersonne = Annuaire("annuaire.txt", false);
            Personne hugo = listPersonne[0];
            Pizzeria Dominos = new Pizzeria("Dominos", "adresse", "01815466");
            hugo.Appeler(Dominos);

            Console.ReadKey();
        }
     
    }
}
