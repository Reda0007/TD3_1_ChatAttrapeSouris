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

namespace ChatAttrapeSouris
{
    /// <summary>
    /// Logique d'interaction pour UCChoixChat.xaml
    /// </summary>
    public partial class UCChoixChat : UserControl
    {
        private int[] DecalagesCouleurChat = { 0, 128, 256, 384 };
        private int CouleurActuelle = 0;
        private const int LagreurChat = 32;
        private const int HauteurChat = 32;
        private const int Ligne = 128;
        

        public UCChoixChat()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UCDebutDuJeu menuPage = new UCDebutDuJeu();


            Window mainWindow = Window.GetWindow(this);


            if (mainWindow != null)
            {

                mainWindow.Content = menuPage;
            }
        }
        private void ImporterImageChat()
        {
            BitmapImage spriteSheet = new BitmapImage(new Uri("pack://application:,,,/Images/cat.png")); // Charger la feuille de sprite
            Int32Rect sourceRect = new Int32Rect(DecalagesCouleurChat[CouleurActuelle], Ligne, LagreurChat, HauteurChat); // Définir la région à découper
            CroppedBitmap croppedBitmap = new CroppedBitmap(spriteSheet, sourceRect); // Créer le bitmap découpé
            ImageChat.Source = croppedBitmap; // Assigner l'image découpée à l'élément Image
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            CouleurActuelle=(CouleurActuelle + 1) % DecalagesCouleurChat.Length; 
            ImporterImageChat();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            CouleurActuelle = (CouleurActuelle - 1 + DecalagesCouleurChat.Length) % DecalagesCouleurChat.Length; 
            ImporterImageChat();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Data.CouleurChatChoisie = CouleurActuelle; 
            MessageBox.Show("Vous avez choisi le chat numéro " + Data.CouleurChatChoisie);
        }

       

        private void RBChatBlanc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RBChatJaune_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
