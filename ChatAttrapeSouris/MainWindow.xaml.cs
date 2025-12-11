using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AfficheDemarrage();
        }
        private void AfficheDemarrage()
        {
            UCDebutDuJeu uc = new UCDebutDuJeu(); // crée et charge l'écran de 
            ZoneJeu.Content = uc; // associe l'écran au conteneur 
            uc.ButtonJouer.Click += AfficherJouer; //
        }

        private void AfficherJouer(object sender, RoutedEventArgs e)
        {
          
        }
    }
}