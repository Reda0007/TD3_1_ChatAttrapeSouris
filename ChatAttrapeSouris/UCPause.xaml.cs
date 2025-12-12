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
    /// Interaction logic for UCPause.xaml
    /// </summary>
    public partial class UCPause : UserControl
    {
        public UCPause()
        {
            InitializeComponent();
        }
        private void Annul_Click(object sender, RoutedEventArgs e)
        {

            var parentControl = this.Parent as Panel;

            if (parentControl != null)
            {

                parentControl.Children.Remove(this);
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
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
