using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProblemePizzeria
{
    class Item
    {
        private string nom;
        private string type;
        private double prix;
        public Item(string Nom, string Type, double Prix)
        {
            this.nom = Nom;
            this.type = Type;
            this.prix = Prix;
        }

        #region Proprietes
        public string Nom
        {
            get { return this.nom; }
        }

        public string Type
        {
            get { return this.type; }
        }

        public double Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
        }
        #endregion

        public override string ToString()
        {
            string retour = this.nom;
            int intervalle = 25 - this.nom.Length;
            for (int i = 0; i < intervalle; i++)
            {
                retour += "-";
            }
            retour += this.prix + "$";
            return retour;
        }

        
    }
}
