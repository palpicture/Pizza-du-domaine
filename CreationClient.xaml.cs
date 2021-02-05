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
    /// Logique d'interaction pour CreationClient.xaml
    /// </summary>
    public partial class CreationClient : Page
    {
        public CreationClient()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreerClient(object sender, RoutedEventArgs e)
        {
            Program.personnes.Add(new Client(Nom.Text, Prenom.Text, Adresse.Text, Tel.Text));
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);
            objMainWindow.Home.Content = new Home();
        }
    }
}
