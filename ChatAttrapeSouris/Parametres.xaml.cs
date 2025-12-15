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
    /// Logique d'interaction pour Parametres.xaml
    /// </summary>
    public partial class Parametres : Window
    {
        public Parametres()
        {
            InitializeComponent();
            this.slidVitesse.Value = MainWindow.vitesse;
            this.slidSon.Value = MainWindow.son;
        }

        private void ButtonConfirmer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
