﻿using System;
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
    /// Logique d'interaction pour RechercheClient.xaml
    /// </summary>
    public partial class RechercheClient : Page
    {
        public RechercheClient()
        {
            InitializeComponent();
        }
        private void ChercheClient(object sender, RoutedEventArgs e)
        {
            List<Client> res = Program.FindClient(Program.personnes, txtClient.Text);
            foreach (Client a in res)
            {
                liste.Items.Add(a);
            }
        }
    }
}
