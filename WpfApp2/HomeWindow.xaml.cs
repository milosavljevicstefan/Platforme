﻿using System;
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
using System.Windows.Shapes;
using WpfApp2.Models;
using WpfApp2.Windows;
using WpfApp2.WindowsOstalo;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            //uvlacim inicijalne test podatke - kada prvi put pokrecem
            //Data.Instance.Initialize();

            //inicijalne podatke citam iz fajlova - kada imam kreirane fajlove
            
            //
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            AllProfessorsWindow mainWindow = new AllProfessorsWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void btnAdrese_Click(object sender, RoutedEventArgs e)
        {
            AllAdressesWindow mainWindow = new AllAdressesWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void btnCasovi_Click(object sender, RoutedEventArgs e)
        {
            AllCasoviWindow mainWindow = new AllCasoviWindow();
            this.Hide();
            mainWindow.Show();
        }
        private void btnStudenti_Click(object sender, RoutedEventArgs e)
        {
            AllStudentsWindow mainWindow = new AllStudentsWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void btnRegisterProfesor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkole_Click(object sender, RoutedEventArgs e)
        {
            AllSkoleWindow mainWindow = new AllSkoleWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            main mai = new main();
            mai.Show();
            this.Close();
        }
    }
}
