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
        private int[] CatColorOffsets = { 0, 128, 256, 384 };
        private int CurrentColorIndex = 32;
        private const int CatSpriteWidth = 32;
        private const int CatSpriteHeight = 32;
        private const int SpriteSheetRow = 128;
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

    }
}
