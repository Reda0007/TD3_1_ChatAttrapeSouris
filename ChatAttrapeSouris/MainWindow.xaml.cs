using System.Media;
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
        public static SoundPlayer Son;
        public static int Score = 0;
        public static string Perso { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            AfficheMenu();
            InitMusique();
            InitSon();
        }
        public void AfficheMenu()
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
            uc.ShowDialog();
        }
        public void AfficheResultat(object sender, RoutedEventArgs e)
        {
            UCResultat uc = new UCResultat();
            ZoneJeu.Content = uc;
            uc.ButtonRejouer.Click += AfficheRejouer;
            uc.ButtonMenuResultat.Click += AfficheMenuResultat;
            uc.ButtonQuitter.Click += AfficheQuitter;
        }

        private void AfficheQuitter(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void AfficheMenuResultat(object sender, RoutedEventArgs e)
        {
            AfficheMenu();
        }

        public void AfficheRejouer(object sender, RoutedEventArgs e)
        {
            AfficheJeu(sender, e);
        }

        private static MediaPlayer musique;
        private void InitMusique()
        {
            musique = new MediaPlayer();
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "ASSETS/Music_chat.mp3"));
            musique.MediaEnded += RelanceMusique;
            musique.Volume = 0.5;
            musique.Play();
        }

        private void RelanceMusique(object? sender, EventArgs e)
        {
            musique.Position = TimeSpan.Zero;
            musique.Play();
        }

        private void InitSon()
        {
            Son = new SoundPlayer(Application.GetResourceStream(new Uri("pack://application:,,,/ASSETS/Bruit_mort.wav.wav")).Stream);
        }
    }
}
