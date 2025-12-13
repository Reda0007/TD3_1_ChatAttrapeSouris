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
            AfficheDebuDuJeu();
            
        }

        private void AfficheDebuDuJeu()
        {
           UCDebutDuJeu uc = new UCDebutDuJeu();
            ZoneJeu.Content = uc;
            uc.ButtonRegles.Click += AfficheRegles;
            uc.ButtonJeu.Click += AfficheJeu;
        }

        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCChoixChat uc = new UCChoixChat();
            ZoneJeu.Content = uc;
            
        }

        private void AfficheRegles(object sender, RoutedEventArgs e)
        {
            UCRegles uc = new UCRegles();
            ZoneJeu.Content = uc;
            uc.ButtonRetour.Click += AfficheRetour;
        }

        private void AfficheRetour(object sender, RoutedEventArgs e)
        {
            AfficheDebuDuJeu();
        }

        private void AfficheMenu()
        {
          // UCMenu uc = new UCMenu();
          // il faut mettre ici le uc menu pour pouvoir acceder au autre bouton
        }

        

        
    }
}