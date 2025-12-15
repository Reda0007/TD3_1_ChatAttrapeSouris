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

namespace ChatAttrapeSouris
{
    /// <summary>
    /// Logique d'interaction pour UCDebutDuJeu.xaml
    /// </summary>
    public partial class UCDebutDuJeu : UserControl
    {
        public UCDebutDuJeu()
        {
            InitializeComponent();
        }

        private void ButtonRegles_Click(object sender, RoutedEventArgs e)
        {
            UCRegles uc = new UCRegles();
            ((MainWindow)Application.Current.MainWindow).ZoneJeu.Content = uc; 
        }

        private void ButtonChoixChat_Click(object sender, RoutedEventArgs e)
        {
            UCJeu uc = new UCJeu();
            ((MainWindow)Application.Current.MainWindow).ZoneJeu.Content = uc;
        }

        private void ButtonJeu_Click(object sender, RoutedEventArgs e)
        {
            ParametresVitesse uc = new ParametresVitesse();
            ((MainWindow)Application.Current.MainWindow).ZoneJeu.Content = uc;
        }
    }
}
