using System.Security.Policy;
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
        public static double vitesse;
        public MainWindow()
        {
            InitializeComponent();
            AfficheMenu();
    
        }


        private void AfficheMenu()
        {
            UCMenu uc = new UCMenu();
            ZoneJeu.Content = uc;
            uc.ButtonMenu.Click += AfficheDebutDuJeu;


        }

        private void AfficheDebutDuJeu(object sender, RoutedEventArgs e)
        {
            UCDebutDuJeu uc = new UCDebutDuJeu();
            ZoneJeu.Content = uc;
            uc.ButtonRegles.Click += AfficheRegles;
            uc.ButtonJeu.Click += AfficheJeu;
        }

        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
           
        }

        private void AfficheRegles(object sender, RoutedEventArgs e)
        {
            UCRegles uc = new UCRegles();
            ZoneJeu.Content = uc;
            uc.ButtonRetour.Click += AfficheRetour;
        }

        private void AfficheRetour(object sender, RoutedEventArgs e)
        {
            AfficheMenu();
        }
    }
}