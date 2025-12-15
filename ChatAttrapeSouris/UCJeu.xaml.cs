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
        private double gravite = 0.5;
        private double positionSolY; // Position Y du sol
        private double FORCE_SAUT;
        private double GRAVITE;


        public UCJeu()
        {
            InitializeComponent();
            InitializeImages();
            InitializeTimer();
            BoxPosition();

            // IMPORTANT : Initialiser positionSolY AVANT InitializeTimer
            positionSolY = Canvas.GetBottom(imgPerso);
            if (double.IsNaN(positionSolY))
            {
                positionSolY = 0;
                Canvas.SetBottom(imgPerso, positionSolY);
            }

            InitializeTimer();
        }

        private void BoxPosition()
        {
            throw new NotImplementedException();
        }

        public void GererKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                saut = false;
        }

        private void InitializeTimer()
        {
            positionbox = 800;
            Canvas.SetLeft(box, positionbox);
            minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            minuterie.Tick += Jeu;
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

            if (Canvas.GetLeft(image) + image.ActualWidth <= 0)
                Canvas.SetLeft(image, this.ActualWidth);
        }

        // NOUVELLE MÉTHODE : Gérer le saut avec gravité
        private void GererSaut()
        {
            // Démarrer le saut siespace est pressé et qu'on n'est pas déjà en train de sauter
            if (saut && !enSaut)
            {
                enSaut = true;
                vitesseSaut = FORCE_SAUT;
            }

            // Si on est en train de sauter
            if (enSaut)
            {
                double positionActuelle = Canvas.GetBottom(imgPerso);
                positionActuelle += vitesseSaut;
                vitesseSaut -= GRAVITE; // La gravité ralentit puis inverse le saut

                Canvas.SetBottom(imgPerso, positionActuelle);

                // Vérifier si on retombe au sol
                if (positionActuelle <= positionSolY)
                {
                    Canvas.SetBottom(imgPerso, positionSolY);
                    enSaut = false;
                    vitesseSaut = 0;
                }
            }
        }

        // NOUVELLE MÉTHODE : Détecter collision
        private bool DetecterCollision(Image objet1, Image objet2)
        {
            double left1 = Canvas.GetLeft(objet1);
            double bottom1 = Canvas.GetBottom(objet1);

            double left2 = Canvas.GetLeft(objet2);
            double bottom2 = Canvas.GetBottom(objet2);

            // Calculer les rectangles de collision
            double right1 = left1 + objet1.ActualWidth;
            double top1 = bottom1 + objet1.ActualHeight;

            double right2 = left2 + objet2.ActualWidth;
            double top2 = bottom2 + objet2.ActualHeight;

            // Vérifier le chevauchement
            bool collisionX = left1 < right2 && right1 > left2;
            bool collisionY = bottom1 < top2 && top1 > bottom2;

            return collisionX && collisionY;
        }

        // NOUVELLE MÉTHODE : Fin du jeu
        private void FinDuJeu()
        {
            minuterie.Stop();
            MessageBox.Show("Game Over ! Vous avez touché un obstacle.", "Fin du jeu");

            // Retourner au menu
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.AfficheMenu();
        }

        private void Jeu(object? sender, EventArgs e)
        {
            // Déplacement du décor
            Deplace(Fond1, 2);
            Deplace(Fond2, 2);
            Deplace(buisson, 2);
            Deplace(box, 2);

            // APPELER la méthode de gestion du saut
            GererSaut();

            // VÉRIFIER la collision avec l'obstacle
            if (DetecterCollision(imgPerso, box))
            {
                FinDuJeu();
                return; // Arrêter le traitement
            }

            // Animation du personnage (seulement si pas en saut)
            if (!enSaut)
            {
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
        }

        private void menuParametre_Click(object sender, RoutedEventArgs e)
        {
            minuterie.Stop();
            Parametres parametreWindow = new Parametres();
            bool? rep = parametreWindow.ShowDialog();

            // Relancer le timer si l'utilisateur n'a pas quitté
            if (rep == true)
                minuterie.Start();
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            minuterie.Stop();
            UCPause parametreWindow = new UCPause();
            bool? rep = parametreWindow.ShowDialog();

            // Relancer le timer si l'utilisateur continue
            if (rep == false) // false = annuler = continuer
                minuterie.Start();
        }

        private void MainGrid_KeyUp(object sender, KeyEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += MainGrid_KeyDown; // Associer l'événement KeyDown
        }

        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space && !enSaut)
            {
                enSaut = true;
                vitesseSaut = 20;
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

