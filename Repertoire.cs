using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemePizzeria
{
    class Repertoire
    {

        private List<Pizzeria> listPizzerias;

        public Repertoire(List<Pizzeria> ListPizzerias)
        {
            this.listPizzerias = ListPizzerias;
        }

        public Repertoire(string fichier)
        {
            StreamReader lecteur = new StreamReader(fichier);
            string ligne = "";
            List<Pizzeria> listP = new List<Pizzeria>();
            var lineCount = File.ReadLines(fichier).Count();
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine(); // lis les pizzerias
                if (ligne != null)
                {
                    string[] motsFichier = ligne.Split(';');   // split des chaines séparés par un ;
                    listP.Add(new Pizzeria(motsFichier[0], motsFichier[1], motsFichier[2]));
                }
            }
            lecteur.Close();
            this.listPizzerias = listP;
        }

        public List<Pizzeria> CentreAppel
        {
            get { return this.listPizzerias; }
            set { this.listPizzerias = value; }
        }

        public override string ToString()
        {
            string retour = "";
            this.listPizzerias.ForEach(item => retour += item.ToString());
            return retour;
        }

    }
}
