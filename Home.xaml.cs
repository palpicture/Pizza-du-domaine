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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            
            InitializeComponent();
            foreach (Pizza a in Program.menu)
            {
                AffichagePizzas.Items.Add(a);
            }
        }

        private void ouvrirMenu(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Menu.Content = new Menu();

        }

        private void Recherche(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);
            objMainWindow.Home.Content = new RechercheClient();
        }

        private void Commander(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);
            objMainWindow.Home.Content = new MenuCommande();
        }
    }
}
