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
    /// Logique d'interaction pour ClientComisCommande.xaml
    /// </summary>
    public partial class ClientComisCommande : Page
    {
        public ClientComisCommande()
        {
            InitializeComponent();
            foreach(Personne a in Program.personnes)
            {
                if(a is Commis)
                    cmbComis.Items.Add(a);
            }
        }

        private void ChercheClient(object sender, RoutedEventArgs e)
        {
            List<Client> res = Program.FindClient(Program.personnes,txtClient.Text) ;
            foreach(Client a in res)
            {
                liste.Items.Add(a);
            }
        }

        private void CommandeFinal(object sender, RoutedEventArgs e)
        {
            Program.commandes.Add(new Commande(Program.commandeI, Program.commandeP, (Client)liste.SelectedValue, (Commis)cmbComis.SelectedValue));
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);
            objMainWindow.Home.Content = new Home();
        }
    }
}
