using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ListBooks.xaml
    /// </summary>
    public partial class ListBooks : Page
    { 
        
        MySqlConnection conn;
        string filePath = @"C:\Users\tobia\OneDrive\Dokument\GitHub\Library_DB\Resources\lösen.txt";
        private const string z = "book_title";
        private const string y = "idBooks";
        private const string x = "page_amount";

        public ListBooks()
        {
            
            InitializeComponent();
            string passFile = File.ReadAllText(filePath);

            string server = "localhost";
            string database = "librarydbmodel";
            string user = "root";
            string pass = passFile;

            //Establera kopplika till Database
            string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
            conn = new MySqlConnection(connString);

            string SQLquerry = "CALL SelectBooks();";

            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
            try
            {
                conn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                
                DataTable dataTable = new DataTable("books");
                dataTable.Load(reader);
                conn.Close();

                BooksGrid.DataContext = dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        
       

        private void showData(object sender, RoutedEventArgs e)
        {
            
            
        }
       
        
    }
}
