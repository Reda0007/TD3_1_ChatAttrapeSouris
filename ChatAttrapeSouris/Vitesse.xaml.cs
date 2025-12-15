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

namespace ChatAttrapeSouris
{
    /// <summary>
    /// Logique d'interaction pour Vitesse.xaml
    /// </summary>
    public partial class Vitesse : Window
    {
        public Vitesse()
        {
            InitializeComponent();
            this.slidVitesse.Value = MainWindow.vitesse;
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        private void button_annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }
    }
}
