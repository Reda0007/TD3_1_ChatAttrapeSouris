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
    public partial class UCPause : Window
    {
        public UCPause()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = Application.Current.MainWindow as MainWindow; 
            //this.Close();
           
        }

        private void Annul_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
        }
    }
}
