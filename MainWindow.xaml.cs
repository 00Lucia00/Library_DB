﻿using MySql.Data.MySqlClient;
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
        
       
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainPage();
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
