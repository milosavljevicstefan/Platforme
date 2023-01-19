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
using WpfApp2.WindowsOstalo;

namespace WpfApp2.WindowsStudent
{
    /// <summary>
    /// Interaction logic for StudentWindowMain.xaml
    /// </summary>
    public partial class StudentWindowMain : Window
    {
        private RegistrovaniKorisnik prijavljeniKorisnik;
        public StudentWindowMain(RegistrovaniKorisnik prijavljeniKorisnik)
        {
            InitializeComponent();
            this.prijavljeniKorisnik = prijavljeniKorisnik;
        }

        private void zakaziDugme_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeCasaWindow main = new ZakazivanjeCasaWindow(prijavljeniKorisnik);
            main.Show();

        }

        private void miEditStudent_Click(object sender, RoutedEventArgs e)
        {
            IzmeniPodatkeStudentWindow edit = new IzmeniPodatkeStudentWindow(prijavljeniKorisnik);
            edit.Show();
        }

        private void milogout_Click(object sender, RoutedEventArgs e)
        {
            main mai = new main();
            mai.Show();
            this.Close();
        }
    }
}
