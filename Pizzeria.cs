using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Pizza_du_domaine
{
    class Pizzeria: IContact
    {
        private string nom;
        private string adresse;
        private string telephone;
        private List<Client> listClients= new List<Client>();
        private List<Commande> listCommandes = new List<Commande>();
        private List<Employer> listEmployers = new List<Employer>();
        private double caisse;

        public Pizzeria(string Nom, string Adresse, string Telephone) // Creer une Pizzeria
        {
            this.nom = Nom;
            this.adresse = Adresse;
            this.telephone = Telephone;

            // Cette partie sert à initiliser les attributs liste a partir des fichiers

            StreamReader lecteur = new StreamReader("effectifs.txt");
            string ligne = "";
            //var lineCount = File.ReadLines(fichier).Count();
            this.listEmployers = new List<Employer>();
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine(); // lis les personnes
                if (ligne != null)
                {
                    string[] motsFichier = ligne.Split(';'); // split des mots à comparés, séparés par un ;
                    
                    if(motsFichier[0] == "Commis")
                    {
                        this.listEmployers.Add(new Commis(motsFichier[1], motsFichier[2], motsFichier[3], motsFichier[4], motsFichier[5], motsFichier[6], motsFichier[7]));
                    }
                    else
                    {
                        this.listEmployers.Add(new Livreur(motsFichier[1], motsFichier[2], motsFichier[3], motsFichier[4], motsFichier[5], motsFichier[6], motsFichier[7], motsFichier[8]));
                    }
                    
                }
            }
            lecteur.Close();
        }

        #region Prorietes
        public string Nom
        {
            get { return this.nom; }
        }

        public string Adresse
        {
            get { return this.adresse; }
        }
        public string Tel
        {
            get { return this.telephone; }
        }

        public double Caisse
        {
            get { return this.caisse; }
            set { this.caisse = value; }
        }

        #endregion

        public bool PizzeriaOuverte()
        {
            return this.listEmployers.Count() != 0;
        }

        /// <summary>
        /// Permet de separer la liste des employers en deux listes
        /// </summary>
        /// <returns> Revoie un arraylist qui comprend une liste de commis et une liste de livreur </returns>
        /// 
        public ArrayList EffectifSeparés()
        {
            List<Commis> listCommis = new List<Commis>();
            List<Livreur> listLivreur = new List<Livreur>();

            foreach (Employer element in this.listEmployers)
            {
                if (element.GetType().Name == "Commis")
                {
                    listCommis.Add((Commis)element);
                }
                else
                {
                    listLivreur.Add((Livreur)element);
                }
            }
            ArrayList tabEmployers = new ArrayList() { listCommis, listLivreur };
            // element1 = liste commis; element2 = liste livreur
            return tabEmployers;
        }

        /// <summary>
        /// Permet de verfier si une personne est un client ou non
        /// </summary>
        /// <param name="p"> Prend une personne en parametre</param>
        /// <returns> renvoie un tuple qui comprend un boolean et le 
        ///             client corespondant a la personne</returns>
        public Tuple<bool, Client> Adherant(Personne p)
        {
            bool test = false;
            Client dejaEnregistre = null;
            if (this.listClients != null)
            {
                listClients.ForEach(item =>
                {
                    if (item.Tel == p.Tel)
                    {
                        dejaEnregistre = item;
                        test = true;
                    }
                    else
                    {
                        dejaEnregistre = null;
                    }
                });
            }
            else
            {
                dejaEnregistre = null;
            }
            return new Tuple<bool, Client>(test, dejaEnregistre);
        }


        public Commande Decrocher(Personne p)
        {
            Commande commandeEnregistre = null;
            if (PizzeriaOuverte()) // si la pizzeria est ouverte
            {
                Random rnd = new Random();
                List<Commis> effectifCommis = (List<Commis>)EffectifSeparés()[0];
                int index = rnd.Next(0, effectifCommis.Count()); // on choisis un commis aleatoire pour prendre la commande
                
                while (effectifCommis[index].Etat != "present")
                {
                    index = rnd.Next(0, effectifCommis.Count());
                }
                Commis commisAleatoire = effectifCommis[index];
                if (Adherant(p).Item1) // si la personne est un client
                {
                    commandeEnregistre = commisAleatoire.PrendreCommande(Adherant(p).Item2); //on prend sa commande
                }
                else //il n'est pas client 
                {
                    Client newClient = new Client(p.Nom,p.Prenom,p.Adresse,p.Tel); // il devient client
                    this.listClients.Add(newClient); // on l'ajoute a la liste des clients de la pizzeria
                    commandeEnregistre = commisAleatoire.PrendreCommande(newClient); // on prend sa commande
                }
                this.listCommandes.Add(commandeEnregistre); // on ajoute la commande en cours; on la retirera quand le livreur aura donne la comm. au client
            }
            return commandeEnregistre;
        }

        public void Recruter(Commis c)
        {

        }

        public void Recruter(Livreur l)
        {

        }

        public override string ToString()
        {
            string retour = "";
            retour += "Nom: " + this.nom + "\n";
            retour += "Adresse: " + this.adresse + "\n";
            retour += "Tel: " + this.telephone + "\n";
            retour += "------------------------\n";
            return retour;
        }
    }
}
