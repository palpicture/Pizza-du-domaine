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
using System.Windows.Shapes;

namespace Pizza_du_domaine
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        
        public Menu()
        {
            InitializeComponent();

            /*List<Pizza> pizzaMenu = new List<Pizza>();
            pizzaMenu = Program.Menu("pizzas.txt", false);

            DataContext = this;
            //ListView pizzaMenuLV = new ListView();
            //pizzaMenuLV.ItemsSource = pizzaMenu;

            //Pizzas.Children.Add(pizzaMenuLV);
            */
        }


        private void OuvrirCommander(object sender, RoutedEventArgs e)
        {

        }
    }
}
