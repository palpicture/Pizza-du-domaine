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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
  
        public MainWindow()
        {
            Program.menu = Program.Menu("pizzas.txt", false);
            Program.items = Program.Stock("items.txt", false);
            Program.personnes = Program.Annuaire("annuaire.txt", false);
            Program.commandes = new List<Commande>();
            InitializeComponent();
            Home.Content = new Home();
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void minimizeApp(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OuvrirCommander(object sender, RoutedEventArgs e)
        {
            Home.Content = new MenuCommande();

        }


    }
}
