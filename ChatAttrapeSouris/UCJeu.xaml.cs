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
using System.Windows.Threading;

namespace ChatAttrapeSouris
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private DispatcherTimer minuterie;
        private double vitesse = 5;
        private double positionbox;
        public static BitmapImage[] persos = new BitmapImage[3];
        private int nb = 0;
        private int nbTours;
        private bool saut = false;
        private bool enSaut = false;
        private double vitesseSaut = 0;
        private double gravite = 1;
        private double positionSolY; // Position Y du sol




        // Modifiez la méthode Deplace pour gérer le repositionnement



        public UCJeu()
        {
            InitializeComponent();
            InitializeImages();
            InitializeTimer();

            // Sauvegarder la position initiale au sol
            positionSolY = Canvas.GetBottom(imgPerso);

            // Vérifier si positionSolY est valide
            if (double.IsNaN(positionSolY))
            {
                positionSolY = 0;
                Canvas.SetBottom(imgPerso, positionSolY);
            }

        }

        public void GererKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space && !enSaut)
            {
                enSaut = true;
                vitesseSaut = 15;
            }
        }

        public void GererKeyUp(KeyEventArgs e)
        {
            // Vide pour l'instant
        }

        private void BoxPosition()
        {
            positionbox -= vitesse;
            Canvas.SetLeft(box, positionbox);
            // Si la box sort de l'écran à gauche, le repositionner à droite
            if (positionbox < -box.Width)
            {
                positionbox = this.Width;
            }
        }

        private void InitializeTimer()
        {
            positionbox = 800;
            Canvas.SetLeft(box, positionbox);
            minuterie = new DispatcherTimer();
            // configure l'intervalle du Timer :62 images par s
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            // associe l’appel de la méthode Jeu à la fin de la minuterie
            minuterie.Tick += Jeu;
            // lancement du timer
            minuterie.Start();
        }

        private void InitializeImages()
        {
            for (int i = 0; i < persos.Length; i++)
                persos[i] = new BitmapImage(new Uri($"pack://application:,,,/cats/cat_0{i + 1}.png"));
        }
        public void Deplace(Image image, int pas)
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - pas);

            if (Canvas.GetLeft(image) + image.Width <= 0)
                Canvas.SetLeft(image, this.ActualWidth);
        }

        
        private void Jeu(object? sender, EventArgs e)
        {



            Deplace(Fond1, 2);
            Deplace(Fond2, 2);
            Deplace(buisson, 2);
            Deplace(box, 2);

            // Gestion du saut
            if (enSaut)
            {
                double positionActuelle = Canvas.GetBottom(imgPerso);
                positionActuelle += vitesseSaut;
                vitesseSaut -= gravite; // La gravité ralentit puis inverse le saut

                Canvas.SetBottom(imgPerso, positionActuelle);

                // Vérifier si on retombe au sol
                if (positionActuelle <= positionSolY)
                {
                    Canvas.SetBottom(imgPerso, positionSolY);
                    enSaut = false;
                    vitesseSaut = 0;
                }
            }

            nbTours++;
            if (nbTours == 4)
            {
                nb++;
                if (nb == persos.Length)
                    nb = 0;

                imgPerso.Source = persos[nb];
                nbTours = 0;
            }
        }
        
        
        
        private void menuParametre_Click(object sender, RoutedEventArgs e)
        {
            minuterie.Stop();
            Parametres parametreWindow = new Parametres();
            bool? rep = parametreWindow.ShowDialog();
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            minuterie.Stop();
            UCPause parametreWindow = new UCPause();
            bool? rep = parametreWindow.ShowDialog();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += MainGrid_KeyDown;
        }

        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Canvas.SetBottom(imgPerso, Canvas.GetBottom(imgPerso) + 15);
            }
        }





        //private void Jeu(object? sender, EventArgs e)
        //{

        //}

        //private void menuParametre_Click(object sender, RoutedEventArgs e)
        //{
        //    minuterie.Stop();
        //    ParametresVitesse parametresvitesse = new ParametresVitesse();

        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    UCPause pauseOverlay = new UCPause();

        //    MainGrid.Children.Add(pauseOverlay);
        //
        //}
    }
}
