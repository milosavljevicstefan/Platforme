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
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        private Student selektovaniStudent;
        private EStatus selektovaniStatus;
        public AddEditStudentWindow(EStatus status, Student student)
        {
            InitializeComponent();
            selektovaniStudent= student;
            selektovaniStatus = status;
            this.DataContext = student;

            cbPol.ItemsSource = Enum.GetValues(typeof(EPol));
            cbAdresa.ItemsSource = Data.Instance.Adrese;
            lbCasovi.ItemsSource = Data.Instance.Casovi;

            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj studenta";



            }
            else
            {
                this.Title = "Izmeni studenta";
                txtIme.Text = student.Korisnik.Ime;
                txtPrezime.Text = student.Korisnik.Prezime;
                txtJmbg.Text = student.Korisnik.JMBG;
                txtEmail.Text = student.Korisnik.Email;
                txtLozinka.Text = student.Korisnik.Lozinka;
                
                foreach (Cas s in student.ListaCasova)
                {
                    lbCasovi.SelectedItems.Add(s);
                }
                txtEmail.IsEnabled = false;
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (selektovaniStatus.Equals(EStatus.DODAJ))
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
                foreach (Cas c in lbCasovi.SelectedItems)
                {
                    listaCasova.Add(c);
                }
                novi.ListaCasova = listaCasova;
                Data.Instance.Korisnici.Add(korisnik);

                Data.Instance.Studenti.Add(novi);

            } else
            {
                EPol pol = new EPol();
                Enum.TryParse(cbPol.Text, out pol);
                Student p = Data.Instance.Studenti.ToList().Find(x => x.Korisnik.Email.Equals(txtEmail.Text));
                p.Korisnik.Ime = txtIme.Text;
                p.Korisnik.Prezime = txtPrezime.Text;
                p.Korisnik.JMBG = txtJmbg.Text;
                p.Korisnik.Pol = pol;
                p.Korisnik.Email = txtEmail.Text;
                p.Korisnik.Lozinka = txtLozinka.Text;
                p.Korisnik.Adresa = (Adresa)cbAdresa.SelectedItem;
                List<Cas> listaCasova = new List<Cas>();
                foreach (Cas c in lbCasovi.SelectedItems)
                {
                    listaCasova.Add(c);
                }
                p.ListaCasova = listaCasova;

            }
            Data.Instance.SacuvajEntitet("korisnici.txt");
            Data.Instance.SacuvajEntitet("studenti.txt");
            this.Close();
        }
    }
}
