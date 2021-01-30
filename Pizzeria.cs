using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Pizzeria : IContact
    {
        private string nom;
        private string adresse;
        private string telephone;
        private List<Client> listClients;
        private List<Commande> listCommandes;
        private List<Employer> listEmployers;
        private double caisse;

        public Pizzeria(string Nom, string Adresse, string Telephone)
        {
            this.nom = Nom;
            this.adresse = Adresse;
            this.telephone = Telephone;
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
        public string Telephone
        {
            get { return this.telephone; }
        }
        #endregion

        public bool PizzeriaOuverte()
        {
            return this.listEmployers.Count() != 0;
        }


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

        public Tuple<bool, Client> Adherant(Personne p)
        {
            bool test = false;
            Client dejaEnregistre = null;
            listClients.ForEach(item =>
            {
                if (item.Tel == p.Tel)
                {
                    dejaEnregistre = item;
                    test = true;
                }
            });
            return new Tuple<bool, Client>(test, dejaEnregistre);
        }

        public Commande Decrocher(Personne p)
        {
            Commande commandeEnregistre = null;
            if (PizzeriaOuverte()) // a modifer
            {
                Random rnd = new Random();
                List<Commis> effectifCommis = (List<Commis>)EffectifSeparés()[0];
                int index = rnd.Next(0, effectifCommis.Count());
                while (effectifCommis[index].Etat != "present")
                {
                    index = rnd.Next(0, effectifCommis.Count());
                }
                Commis commisAleatoire = effectifCommis[index];
                if (Adherant(p).Item1) // si la personne est un client
                {
                    commandeEnregistre = commisAleatoire.PrendreCommande(Adherant(p).Item2);
                }
                else
                {

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
