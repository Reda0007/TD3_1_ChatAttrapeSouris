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
            
        }
        public void AfficherMenu()
        {
            ZoneJeu.Content = new UCDebutDuJeu();
        }

        public void AfficherRegles()
        {
            ZoneJeu.Content = new UCRegles();
        }

        public void AfficherJeu()
        {
            ZoneJeu.Content = new UCJeu();
        }






        private void AfficheRegles(object sender, RoutedEventArgs e)
        {
            UCRegles uc = new UCRegles(); // crée et charge l'écran de 
            ZoneJeu.Content = uc; // associe l'écran au conteneur 
            //uc.ButtonRetour.Click += AfficheRetour;
           
        }

        

        private void AfficherJouer(object sender, RoutedEventArgs e)
        {
            UCJeu uc = new UCJeu(); // crée et charge l'écran de 
            ZoneJeu.Content = uc; // associe l'écran au conteneur 
            //uc.ButtonJouer.Click += AfficherJouer;
        }

        private void AfficherChoixChat(object sender, RoutedEventArgs e)
        {
            UCChoixChat uc = new UCChoixChat(); 
            ZoneJeu.Content = uc;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UCDebutDuJeu uc = new UCDebutDuJeu(); // crée et charge l'écran de 
            ZoneJeu.Content = uc; // associe l'écran au conteneur 
            uc.Jeu.Click += AfficherJouer;
            uc.Regles.Click += AfficheRegles;
            uc.ChoixChat.Click += AfficherChoixChat;
        }

        
    }
}