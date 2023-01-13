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
using System.Windows.Shapes;
using WpfApp2.Models;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Interaction logic for AllStudentsWindow.xaml
    /// </summary>
    public partial class AllStudentsWindow : Window
    {
        public AllStudentsWindow()
        {
            InitializeComponent();
            dgStudenti.ItemsSource = Data.Instance.Studenti;
        }

        private void miDodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student();
            AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow(EStatus.DODAJ, s);
            addEditStudentWindow.Show();
        }

        private void miIzmeniStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student s = (Student)dgStudenti.SelectedItem;
            AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow(EStatus.IZMENI, s);
            addEditStudentWindow.Show();
        }

        private void miObrisiStudenta_Click(object sender, RoutedEventArgs e)
        {
            Student s = (Student)dgStudenti.SelectedItem;
            Data.Instance.ObrisiStudenta(s);
        }

        private void miVratiNaPocetnu_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            this.Hide();
            homeWindow.Show();
        }
    }
}
