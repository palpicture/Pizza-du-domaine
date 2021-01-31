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

namespace ProblemePizzeria
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Commander(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous avez commander!! Youpi (petit con va)");
        }

        private void Mes_commandes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rien");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Travaille!");
        }
    }
}
