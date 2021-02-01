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

namespace ProblemePizzeria
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
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

        private void openMainWindow(object sender, RoutedEventArgs e)
        {
            ProblemePizzeria.MainWindow mainWindow = new ProblemePizzeria.MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
