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
        

       

        // Modifiez la méthode Deplace pour gérer le repositionnement
        


        public UCJeu()
        {
            InitializeComponent();
            InitializeImages();
             // Nouvelle méthode
            InitializeTimer();

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

            if (saut)
                Canvas.SetBottom(imgPerso, Canvas.GetBottom(imgPerso) + 2);

            Deplace(Fond1, 2);
            Deplace(Fond2, 2);
            Deplace(buisson, 2);
            
            Deplace(box, 2);
           

            if (saut)
                Canvas.SetBottom(imgPerso, Canvas.GetBottom(imgPerso) + 2);

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
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                saut = true;
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                saut = false;
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
