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
        private static DispatcherTimer minuterie;
        public static BitmapImage[] persos = new BitmapImage[3];
        private int nb = 0;
        private int nbTours;

        public UCJeu()
        {
            InitializeComponent();
            InitializeImages();
            InitializeTimer();
            
        }

        

        private void InitializeTimer()
        {
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
                Canvas.SetLeft(image, image.Width);
        }
        private void Jeu(object? sender, EventArgs e)
        {
 
            Deplace(Fond1, 2);
            Deplace(Fond2, 2);


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
        private static bool saut;
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
            UCParametres uc = new UCParametres();
            ((MainWindow)Application.Current.MainWindow).ZoneJeu.Content = uc;
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            UCPause uc = new UCPause();
            ((MainWindow)Application.Current.MainWindow).ZoneJeu.Content = uc;
        }

        //private void InitTimer()
        //{
        //    minuterie = new DispatcherTimer();
        //    minuterie.Interval = TimeSpan.FromMilliseconds(16);
        //    // associe l’appel de la méthode Jeu à la fin de la minuterie
        //    minuterie.Tick += Jeu;
        //    minuterie.Start();
        //}

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
