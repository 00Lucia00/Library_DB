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

namespace Library_DB
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        public AddBook()
        {
            InitializeComponent();
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(favoSlider.Value == 0 || favoSlider.Value == 1)
            {
                favoLabl.Content = "LIKED";
            }
            else if(favoSlider.Value == 2)
            {
                favoLabl.Content = "Quite Favored";
            }
            else if (favoSlider.Value == 3 )
            {
                favoLabl.Content = "Favored";
            } 
            else if (favoSlider.Value == 4 )
            {
                favoLabl.Content = "Very Favored";
            }
        }

        private void favoChecked(object sender, RoutedEventArgs e)
        {
            if(favoCheck.IsChecked == true)
            {
                favoSlider.IsEnabled = true;

            }
            else if(favoCheck.IsChecked == false)
            {
                favoSlider.IsEnabled = false;
            }

        }
    }
}
