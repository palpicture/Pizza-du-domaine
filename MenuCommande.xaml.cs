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
    /// Logique d'interaction pour MenuCommande.xaml
    /// </summary>
    public partial class MenuCommande : Page
    {
        static List<Pizza> commandeP;
        static List<Item> commandeI;
        public MenuCommande()
        {
            InitializeComponent();
            Program.menu.ForEach(x => cmbPizzas.Items.Add(x));
            Program.items.ForEach(x => cmbItem.Items.Add(x));
            commandeP = new List<Pizza>();
            commandeI = new List<Item>();

        }

        private void AjoutPizza(object sender, RoutedEventArgs e)
        {
            Pizza temp = (Pizza)cmbPizzas.SelectedValue;
            temp.Taille = cmbTaille.Text;
            commandeP.Add(temp);
            liste.Items.Add(temp.ToString());
            
        }

        private void Ajouteritem(object sender, RoutedEventArgs e)
        {
            Item temp = (Item)cmbItem.SelectedValue;
            commandeI.Add(temp);
            liste.Items.Add(temp.ToString());
        }
    }
}
