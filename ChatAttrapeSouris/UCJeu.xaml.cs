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
        private double positionbox;
        public static BitmapImage[] persos = new BitmapImage[3];
        private int nb = 0;
        private int nbTours;
        private BitmapImage[] spritesActuels;
        private bool enSaut = false;
        private double vitesseSaut = 0;
        private double positionSolY; // Position Y du sol
        private double FORCE_SAUT=8;
        private double GRAVITE=0.6;
        private bool SautScore = true;

        public UCJeu()
        {
            InitializeComponent();
            
            this.Loaded += (s, e) =>
            {
                MainGrid.Focus();
            };
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

            if (Collision(imgPerso, box) == true)
            {
                FinDuJeu();
            }
            if (Collision(imgPerso, buisson) == true)
            {
                FinDuJeu();
                
            }

        }
        public static bool Collision(Image img1, Image img2)
        {
            if ((Canvas.GetLeft(img1) + img1.ActualWidth > Canvas.GetLeft(img2) && Canvas.GetLeft(img2) + img2.ActualWidth > Canvas.GetLeft(img1)) && (Canvas.GetBottom(img1) + img1.ActualHeight > Canvas.GetBottom(img2) && Canvas.GetBottom(img2) + img2.ActualHeight > (Canvas.GetBottom(img1))))
                return true;
            return false;

        }

        private void BoxPosition()
        {
            positionbox = 800;
            Canvas.SetLeft(box, positionbox);
        }
        private void InitializeTimer()
        {
            
            minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            minuterie.Tick += Jeu;
            minuterie.Start();
        }

        private void InitializeImages()
        {
            // --- CONFIGURATION ---
            string prefixeFichier = " ";
            // On commence toujours à 1 pour le blanc (01, 02, 03) et le jaune (01, 02, 03)
            int numeroDepart = 1;

            if (MainWindow.Perso == "ChatBlanc")
            {
                // C'EST ICI QUE ÇA SE JOUAIT : Le nom spécifique pour le blanc
                prefixeFichier = "cat_blanc_";
            }
            else // Par défaut (ChatJaune)
            {
                // Le nom standard pour les autres
                prefixeFichier = "cat_";
            }
          


            // Initialisation du tableau (pour 3 images d'animation)
            spritesActuels = new BitmapImage[3];

            // Boucle de chargement
            for (int i = 0; i < spritesActuels.Length; i++)
            {
                // Calcul du numéro : 1 + 0 = 1, puis 2, puis 3.
                int numeroImage = numeroDepart + i;

                // Construction du chemin final.
                // "D2" force l'écriture avec deux chiffres (ex: "01" au lieu de "1")
                // Cela donnera : pack://application:,,,/cats/cat_blanc_01.png
                string cheminImage = $"pack://application:,,,/cats/{prefixeFichier}{numeroImage:D2}.png";

                try
                {
                    spritesActuels[i] = new BitmapImage(new Uri(cheminImage));
                    Console.WriteLine($"Image chargée avec succès : {cheminImage}");
                }
                catch (Exception ex)
                {
                    // Ajoute ce message pour voir si le chemin est faux dans la console de sortie
                    Console.WriteLine($"ERREUR : Impossible de trouver l'image : {cheminImage}. Erreur : {ex.Message}");
                }
            }

            // Appliquer la première image au controle WPF
            if (spritesActuels[0] != null && imgPerso != null)
            {
                imgPerso.Source = spritesActuels[0];
            }
        }
        public void Deplace(Image image, int pas)
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - pas);

            if (Canvas.GetLeft(image) + image.ActualWidth <= 0)
                Canvas.SetLeft(image, this.ActualWidth);
        }
        private void GererSaut()
        {
            if (enSaut)
            {
                double positionActuelle = Canvas.GetBottom(imgPerso);  

                positionActuelle += vitesseSaut; 
                vitesseSaut -= GRAVITE;
                     
                Canvas.SetBottom(imgPerso, positionActuelle);

                if (positionActuelle <= positionSolY)
                {
                    Canvas.SetBottom(imgPerso, positionSolY);
                    enSaut = false;
                    vitesseSaut = 0;
                }
            }
        }
        private void FinDuJeu()
        {
            MainWindow.Son.Play();
            minuterie.Stop();
            MessageBox.Show("Game Over ! Vous avez touché un obstacle.", "Fin du jeu");
            MainWindow.Score = 0;


            // Retourner au menu
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.AfficheMenu();
        }

        private void Jeu(object? sender, EventArgs e)
        {
            // Déplacement du décor
            Deplace(Fond1, 5);
            Deplace(Fond2, 5);
            Deplace(buisson, 5);
            Deplace(box, 5);

            // APPELER la méthode de gestion du saut
            GererSaut();

            // VÉRIFIER la collision avec l'obstacle
            if (Collision(imgPerso, box) || Collision(imgPerso, buisson))
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
                    if (nb == spritesActuels.Length)
                        nb = 0;

                    imgPerso.Source = spritesActuels[nb];
                    nbTours = 0;
                }
            }
                Console.WriteLine (Canvas.GetLeft(imgPerso) > Canvas.GetLeft(box) + box.ActualWidth);
            if (Canvas.GetBottom(imgPerso) > Canvas.GetBottom(box) + box.ActualHeight && Canvas.GetLeft(imgPerso) > Canvas.GetLeft(box) + box.ActualWidth && SautScore )
            {
                MainWindow.Score += 1;
                MettreAJourAffichage();
                SautScore = false;
            }
            Console.WriteLine(Canvas.GetLeft(imgPerso) > Canvas.GetLeft(buisson) + buisson.ActualWidth);
            if (Canvas.GetBottom(imgPerso) > Canvas.GetBottom(buisson) + buisson.ActualHeight && Canvas.GetLeft(imgPerso) > Canvas.GetLeft(buisson) + buisson.ActualWidth && SautScore)
            {

                MainWindow.Score += 1;
                MettreAJourAffichage();
                SautScore = false;
            }
            if (Canvas.GetBottom(imgPerso) <= Canvas.GetBottom(buisson) && !SautScore)
            {
                SautScore = true;
            }
            if (Canvas.GetBottom(imgPerso) <= Canvas.GetBottom(box) && !SautScore)
            {
                SautScore = true;
            }
            Console.WriteLine("saut score" + SautScore);    

        }
        private void MettreAJourAffichage()
        {
            labScore.Content = "Score : " + MainWindow.Score.ToString();
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

        

        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && !enSaut)
            {
                enSaut = true;
                
                FORCE_SAUT = Keyboard.IsKeyDown(Key.Space) ? 18 : 13; // Saut plus haut si la touche est maintenue
                vitesseSaut = FORCE_SAUT;
            }
        }

      
    }
}

