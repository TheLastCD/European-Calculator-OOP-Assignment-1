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

namespace European_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void x(object sender, RoutedEventArgs e)
        {
            
        }
        private void limit_Euro(object sender, RoutedEventArgs e)
        {
            bool limit;
            if(Euro_Control.IsChecked == true)
            {
                limit = false;
            }
            else
            {
                limit = true;
            }
            BulPart.IsChecked = limit;
            CroPart.IsChecked = limit;
            CzePart.IsChecked = limit;
            DenPart.IsChecked = limit;
            HunPart.IsChecked = limit;
            PolPart.IsChecked = limit;
            RomPart.IsChecked = limit;
            SwePart.IsChecked = limit;
        }
        private void Austria_Particpation(object sender, RoutedEventArgs e)
        {
            

        }

    }
}
