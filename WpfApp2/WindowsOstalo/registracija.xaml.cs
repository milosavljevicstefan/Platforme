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

namespace WpfApp2.WindowsOstalo
{
    /// <summary>
    /// Interaction logic for registracija.xaml
    /// </summary>
    public partial class registracija : Window
    {
        public registracija()
        {
            InitializeComponent();
            cbPol.ItemsSource = Enum.GetValues(typeof(EPol));
            cbAdresa.ItemsSource = Data.Instance.Adrese;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            Student novi = new Student();
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
            novi.Korisnik = korisnik;
            List<Cas> listaCasova = new List<Cas>();
            novi.ListaCasova = listaCasova;
            Data.Instance.Korisnici.Add(korisnik);
            Data.Instance.Studenti.Add(novi);
            Data.Instance.SacuvajEntitet(korisnik);
            Data.Instance.SacuvajEntitet(novi);
            MessageBox.Show("uspesna registracija!");
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
