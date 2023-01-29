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

        AddBook ab;

        int idB; // book ID- id variable that saves id from row that is being selected
       

        public ListBooks() //Construktor
        {
            
            InitializeComponent();
            ConnPath();
            getTable();
        }
        public void ConnPath()
        {

            string filePath = @"C:\Users\tobia\OneDrive\Dokument\GitHub\Library_DB\Resources\lösen.txt";
            string passFile = File.ReadAllText(filePath);

            string server = "localhost";
            string database = "librarydbmodel";
            string user = "root";
            string pass = passFile;

            string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
            conn = new MySqlConnection(connString);
            
        }
        public void getTable(string key ="")
        {
            //Establera kopplika till Database

            string SQLquerry;
            if(key == "")
            {
                SQLquerry = $"CALL SelectBooksWithAuthors();";
            }
            else
            {
                SQLquerry = $"CALL Search_Title('{key}');";
            }
            
            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
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

            ab = new AddBook(idB);
            putRowValues_inTxtbxes(sender);

            delButton.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
           
        }
        private int getSelectedRowIDB(object sender) //gets id of row so that row can be changed
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
        private void putRowValues_inTxtbxes(object sender)
       {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row_selected)
            {
                ab.TitleTbx.Text = row_selected["book_title"].ToString();
                ab.pageTbx.Text = row_selected["page_amount"].ToString();
                ab.authorTbx.Text = row_selected["Author_name"].ToString();
                if (ab.favoSlider.Value != 0)
                {
                    int fav = Convert.ToInt32(ab.favoSlider.Value);
                    fav = Convert.ToInt32(row_selected["favorits_id"].ToString());
                    ab.favoSlider.IsEnabled = true;
                    ab.favoCheck.IsChecked = true;
                }
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
            Frame.Content = ab;
            ab.updateBtn1.IsEnabled =true;
        }
    }
}
