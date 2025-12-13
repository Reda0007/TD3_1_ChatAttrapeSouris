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
        public UCJeu()
        {
            InitializeComponent();
            //InitTimer();
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
        //}
    }
}
