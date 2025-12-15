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
    /// </summary>::
    public partial class MainWindow : Window
    {
        public static double vitesse;
        public static double son;
        public static string Perso { get; set; }




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
            //uc.ButtonParametres.Click += AfficheParametres;
            uc.ButtonChoixChat.Click += AfficheChoixChat;

        }


        private void AfficheChoixChat(object sender, RoutedEventArgs e)
        {
            UCChoixChat uc = new UCChoixChat();
            ZoneJeu.Content = uc;
            uc.butJouer.Click += AfficheJeu;
        }

        public void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCJeu uc = new UCJeu();
            ZoneJeu.Content = uc;
            uc.ButtonPause.Click += AffichePause;
            //uc.menuParametre.Click += AfficheParametres;

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
        private void AffichePause(object sender, RoutedEventArgs e)
        {
            UCPause uc = new UCPause();
            ZoneJeu.Content = uc;
            uc.Annul.Click += AfficheJeu;
            uc.Exit.Click += AfficheDebutDuJeu;
        }
        //private void AficherResultat(object sender, RoutedEventArgs e)
        //{
        //    UCResultat uc = new UCResultat();
        //    ZoneJeu.Content = uc;
        //    uc.ButtonRejouer.Click += AfficheJeu;
        //    uc.ButtonMenu.Click += AfficheDebutDuJeu;



    }  }
