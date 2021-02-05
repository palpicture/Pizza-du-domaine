using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza_du_domaine
{
    /// <summary>
    /// Logique d'interaction pour GestionCommis.xaml
    /// </summary>
    public partial class GestionCommis : Page
    {
        public GestionCommis()
        {
            InitializeComponent();
            foreach (Personne a in Program.personnes)
            {
                if (a is Commis)
                    AffichageCommis.Items.Add(a);

            }
            
        }
    }
}
