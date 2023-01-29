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
using System.Xml.Linq;

namespace Library_DB
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        //SQL comands //TODO put in maneger klass
        MySqlConnection conn;
        string filePath = @"C:\Users\tobia\OneDrive\Dokument\GitHub\Library_DB\Resources\lösen.txt";

        int id; // book ID- id variable that saves id from row that is being selected
        public AddBook(int id) //konstruktor med parameter
        { 
            this.id = id;
            InitializeComponent();
            string passFile = File.ReadAllText(filePath);

            string server = "localhost";
            string database = "librarydbmodel";
            string user = "root";
            string pass = passFile;

            string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
            conn = new MySqlConnection(connString);
        }
        public AddBook()//konstruktor
        {
            
            InitializeComponent();
            string passFile = File.ReadAllText(filePath);

            string server = "localhost";
            string database = "librarydbmodel";
            string user = "root";
            string pass = passFile;

            string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
            conn = new MySqlConnection(connString);
        }
    

        private void updateBtn1_Click(object sender, RoutedEventArgs e)
        {
            updateData();
        }
        public void updateData()
        {
            ListBooks listPage = new ListBooks();

            string Title = TitleTbx.Text;
            string AuthorName = authorTbx.Text;
            int fav = Convert.ToInt32(favoSlider.Value);
            int pages;
            
            
            try
            {
                //Öppna kommunimation
                conn.Open();

                string SQLQuerry1 = $"CALL getIdA({id})";
                

                // MySQL Command
                MySqlCommand cmd = new MySqlCommand(SQLQuerry1, conn);

                //Exekvera command
                MySqlDataReader reader = cmd.ExecuteReader();
                int idA =Convert.ToInt32(reader.Read());
              
                string SQLQuerry2;

                if (pageTbx.Text == "")// för att förhindra error när txtbx är tom, stored pro hanterar null värden.
                {
                   SQLQuerry2 = $"CALL UpdateData_procedure({id}, '{Title}', null, {fav},{idA},'{AuthorName}');";
                }
                else if(favoSlider.Value < 1)
                {
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, '{Title}',{pages}, null ,{idA},'{AuthorName}');";
                }
                if (authorTbx.Text == "")
                {
                    Title = TitleTbx.Text;
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, '{Title}', {pages}, {fav},null,null);";
                }
                if (TitleTbx.Text == "")
                {
                    AuthorName = authorTbx.Text;
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, 'null', {pages}, {fav},{idA},'{AuthorName}');";
                }
                else if (pageTbx.Text == ""|| favoSlider.Value < 1|| authorTbx.Text == "")
                {
                    Title = TitleTbx.Text;
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, '{Title}',null, null ,null,null);";
                } 
                else if (pageTbx.Text == ""|| favoSlider.Value < 1|| TitleTbx.Text == "")
                {
                    
                    AuthorName = authorTbx.Text;
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, 'null,null, null ,{idA},'{AuthorName}');";
                } 
                else if (authorTbx.Text == ""|| TitleTbx.Text == "")
                {
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, null,{pages}, {fav},null,null);";
                }
                else if (authorTbx.Text == ""|| TitleTbx.Text == ""|| favoSlider.Value < 1)
                {
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, null,{pages}, null,null,null);";
                }else if (authorTbx.Text == ""|| TitleTbx.Text == ""||pageTbx.Text == "")
                {
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, null,null, {fav},null,null);";
                }
                else
                {
                    Title = TitleTbx.Text;
                    AuthorName = authorTbx.Text;
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry2 = $"CALL UpdateData_procedure({id}, '{Title}', {pages}, {fav},{idA},'{AuthorName}');";
                }

                conn.Close();// så att nästa cmd kan exekeveras

                conn.Open();

                cmd = new MySqlCommand(SQLQuerry2, conn);

                cmd.ExecuteReader();

                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Updated  Successfully!");


            clearAllboxes();
            listPage.getTable();
            Frame2.Content = listPage;
        }

        //Clearing txtbxs
        public void clearAllboxes()
        {
            authorTbx.Clear();
            pageTbx.Clear();
            TitleTbx.Clear();
            yearTbx.Clear();
        }

        private void authorTbx_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            clearAllboxes();
        }
        private void yearTbx_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            clearAllboxes();
        }
        private void pageTbx_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            clearAllboxes();
        }
        private void TitleTbx_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            clearAllboxes();
        }
        
        //favorit pointer Slider
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) 
        {
            if (favoSlider.Value == 0 || favoSlider.Value == 1)
            {
                favoLabl.Content = "LIKED";
            }
            else if (favoSlider.Value == 2)
            {
                favoLabl.Content = "Quite Favored";
            }
            else if (favoSlider.Value == 3)
            {
                favoLabl.Content = "Favored";
            }
            else if (favoSlider.Value == 4)
            {
                favoLabl.Content = "Very Favored";
            }
        }
        private void favoChecked(object sender, RoutedEventArgs e)
        {
            if (favoCheck.IsChecked == true)
            {
                favoSlider.IsEnabled = true;

            }
            else if (favoCheck.IsChecked == false)
            {
                favoSlider.IsEnabled = false;
            }

        }
    }
}
