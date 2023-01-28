using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private int idB;
        public int getId() { return idB; }
        // book ID- id variable that saves id from row that is being selected
        int idA; // Author ID

        public ListBooks() //Construktor
        {
            
            InitializeComponent();
            string passFile = File.ReadAllText(filePath);

            string server = "localhost";
            string database = "librarydbmodel";
            string user = "root";
            string pass = passFile;

            string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
            conn = new MySqlConnection(connString);
            getTable();
        }
        public void getTable()
        {
            //Establera kopplika till Database
            

            string SQLquerry = "CALL SelectBooksWithAuthors();";

            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable("books");
                dataTable.Load(reader);
                //BooksGrid.ItemSource = dataTable.DefaultView
                conn.Close();

                BooksGrid.DataContext = dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idB= getSelectedRowIDB(sender);
            delButton.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
        }
        private int getSelectedRowIDB(object sender)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView rowSelected)
            {
                int id = Convert.ToInt32(rowSelected.Row.ItemArray[0]);
                return id;
            }
            else
            {
                return -1;
            }
        }
      
        private void DeleteData_click(object sender, RoutedEventArgs e)
        {
            deleteData(idB);
        }
        public void deleteData(int id)
        {
            if (BooksGrid.SelectedItems.Count != 1) return;

            try
            {
                //Öppna kommunimation
                conn.Open();

                string SQLQuerry = $"CALL DeleteBook({id});";
                // MySQL Command
                MySqlCommand cmd = new MySqlCommand(SQLQuerry, conn);

                //Exekvera command
                cmd.ExecuteReader();

                MessageBox.Show("Deleted Successfully!");
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            getTable();
        }

        private void updateData_click(object sender, RoutedEventArgs e)
        {
            
            Frame.Content = new AddBook(idB);

            //if (BooksGrid.SelectedItems.Count != 1) return;

            //try
            //{
            //    //Öppna kommunimation
            //    conn.Open();

            //    string SQLQuerry = $"CALL UpdateData_procedure({idB}, '{Title}', {pages}, {fav},'{AuthorName}');";
            //    // MySQL Command
            //    MySqlCommand cmd = new MySqlCommand(SQLQuerry, conn);

            //    //Exekvera command
            //    cmd.ExecuteReader();

            //    MessageBox.Show("Updated Successfully!");
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //getTable();
        }
    }
}
