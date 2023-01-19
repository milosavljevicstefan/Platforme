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

namespace WpfApp2.WindowsStudent
{
    /// <summary>
    /// Interaction logic for IzmeniPodatkeStudentWindow.xaml
    /// </summary>
    public partial class IzmeniPodatkeStudentWindow : Window
    {
        private RegistrovaniKorisnik prijavljeniKorisnik;
        public IzmeniPodatkeStudentWindow(RegistrovaniKorisnik prijavljeniKorisnik)
        {
            InitializeComponent();
            this.prijavljeniKorisnik = prijavljeniKorisnik;
            this.DataContext = prijavljeniKorisnik;
            cbPol.ItemsSource = Enum.GetValues(typeof(EPol));
            cbAdresa.ItemsSource = Data.Instance.Adrese;

            this.Title = "Izmeni korisnika";
            txtIme.Text = prijavljeniKorisnik.Ime;
            txtPrezime.Text = prijavljeniKorisnik.Prezime;
            txtJmbg.Text = prijavljeniKorisnik.JMBG;
            txtEmail.Text = prijavljeniKorisnik.Email;
            txtLozinka.Text = prijavljeniKorisnik.Lozinka;
            txtEmail.IsEnabled = false;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            EPol pol = new EPol();
            Enum.TryParse(cbPol.Text, out pol);
            RegistrovaniKorisnik korisnik = new RegistrovaniKorisnik
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                JMBG = txtJmbg.Text,
                Pol = pol,
                Email = txtEmail.Text,
                Lozinka = txtLozinka.Text,
                Adresa = (Adresa)cbAdresa.SelectedItem,
                Aktivan = true,
                TipKorisnika = ETipKorisnika.STUDENT
            };
            Data.Instance.UpdateEntitet(korisnik);
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
