using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        string filePath = @"C:\Users\tobia\OneDrive\Dokument\GitHub\Library_DB\Resources\lösen.txt";
        
        MySqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainPage();

            string passFile = File.ReadAllText(filePath);

            string server = "localhost";
            string database = "librarydbmodel";
            string user = "root";
            string pass = passFile;

            //Establera kopplika till Database
            string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
            conn = new MySqlConnection(connString);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddBook();
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ListBooks();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainPage();
        }

       
    }
}
