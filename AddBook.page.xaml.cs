using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities;
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

    public partial class AddBook : Page
    {
        ListBooks listPage = new ListBooks();
        //SQL comands //TODO put in maneger klass
        MySqlConnection conn;
        int id; // book ID- id variable that saves id from row that is being selected
        TextBox[] txtBoxes;
        public AddBook(int id)  //konstruktor med parameter
        { 
            this.id = id;
            InitializeComponent();
            ConnPath();
            
            fillCombo();
            txtBoxes = new TextBox[] { authorTbx, pageTbx, TitleTbx, yearTbx, langTbx};
        }
        public AddBook()  //konstruktor
        {
            
            InitializeComponent();
            ConnPath();
            
            fillCombo();
            txtBoxes = new TextBox[] { authorTbx, pageTbx, TitleTbx, yearTbx, langTbx };
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
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            insertToTable();
        }
        void insertToTable()
        {

            string SQLquerry;
            string nameA;
            int page;
            string nameB;
            int year;
            string nameL;
            string cb2;
            int favo;
            bool valid = true;

            foreach (TextBox textbox in txtBoxes)
            {
                if (textbox.Text == "") //if box null then no insert to databas from that box
                {
                    textbox.Text = null;
                }
                else if(textbox.Text == "Author" || textbox.Text == "Pages" || textbox.Text == "Book Title" || textbox.Text == "Publishing year" || textbox.Text == "Language")
                {
                    textbox.Text = null;
                    MessageBox.Show("Unvalide input");
                    return;
                }
                else if (typeCheckInt(txtBoxes[1].Text) != true  || typeCheckInt(txtBoxes[3].Text) != true)
                {
                    valid = false;
                    txtBoxes[1].Text = "Error";
                    txtBoxes[3].Text = "Error";
                    if(valid == false)
                    {
                        MessageBox.Show("Unvalid input! You can only write numbers here");
                    }
                    return;
                }
                
            }
            if (cbx2.SelectedItem == null)
            {
                MessageBox.Show("Unvalid input! must choose category");
                return;
            }
            //values from boxes to query
            nameA = txtBoxes[0].Text;
            page = Convert.ToInt32(txtBoxes[1].Text);
            nameB = txtBoxes[2].Text;
            year = Convert.ToInt32(txtBoxes[3].Text);
            nameL = txtBoxes[4].Text;
            cb2 = cbx2.SelectedItem.ToString();
            favo = Convert.ToInt32(favoSlider.Value);

            //sqlQuery
            SQLquerry = $"CALL insert_toBooks('{nameB}', {page}, {year},'{nameA}','{cb2}',{favo},'{nameL}');";
            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
            try
            {
                //Öppna koppling till DB
                conn.Open();

                //Exekvera SQL querry
                cmd.ExecuteReader();

                //stänger kopplingen till DB
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            MessageBox.Show("Inserted successfully!");

            clearAllboxes();
            listPage.getTable();
            Frame2.Content = listPage;
        }
        public bool typeCheckInt(String input)//check for int
        {
            int nr = 0;
            return int.TryParse(input, out nr);
        }
        
        private void updateBtn1_Click(object sender, RoutedEventArgs e)
        {
            updateData();
        }
        public void updateData()
        {
            bool v = true;

            string Title = TitleTbx.Text;
            string AuthorName = authorTbx.Text;
            int fav = Convert.ToInt32(favoSlider.Value);
            int pages = Convert.ToInt32(pageTbx.Text.ToString());

            if (typeCheckInt(txtBoxes[1].Text) != true || typeCheckInt(txtBoxes[1].Text) != true)
            {
                v = false;
                txtBoxes[1].Text = "Error";
                txtBoxes[3].Text = "Error";
                if (v == false)
                {
                    MessageBox.Show("Unvalid input! You can only write numbers here");
                }
            }

            try
            {
                //Öppna kommunimation
                conn.Open();

                string SQLQuerry;


                if (favoSlider.Value < 1)
                {
                    pages = Convert.ToInt32(pageTbx.Text);
                    SQLQuerry = $"CALL UpdateData_procedure({id}, '{Title}',{pages}, null ,'{AuthorName}');";
                }
                else
                { 
                    SQLQuerry = $"CALL UpdateData_procedure({id}, '{Title}', {pages}, {fav},'{AuthorName}');";
                }

                MySqlCommand cmd = new MySqlCommand(SQLQuerry, conn);

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
            authorTbx.Text = "Author";
            pageTbx.Text = "Pages"; 
            TitleTbx.Text = "Book Title";
            yearTbx.Text = "Publishing year";
            langTbx.Text = "Language";
        }

        void fillCombo()
        {
            conn.Open();

            string SQLQuerry1 = $"SELECT * FROM categorys ";

            
            MySqlCommand cmd = new MySqlCommand(SQLQuerry1, conn);
            //Exekvera command
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(1);
                cbx2.Items.Add(name);
                string genre = reader.GetString(2);
                cbx1.Items.Add(genre);
            }
            conn.Close();
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
