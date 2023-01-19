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
    /// Interaction logic for AddEditProfessorWindow.xaml
    /// </summary>
    public partial class AddEditProfessorWindow : Window
    {
        private Profesor selektovaniProfesor;
        private EStatus selektovaniStatus;

        public AddEditProfessorWindow(EStatus status, Profesor profesor)
        {
            InitializeComponent();
            selektovaniProfesor = profesor;
            selektovaniStatus = status;

            this.DataContext = profesor;  //setujem binding source

            //dinamcki kreiram sadrzaj combobox-a
            
            cbPol.ItemsSource = Enum.GetValues(typeof(EPol));
            cbAdresa.ItemsSource = Data.Instance.Adrese;
            lbSkole.ItemsSource = Data.Instance.Skole;
            
            List<string> jezici = new List<string>();
            jezici.Add("Engleski".ToUpper());
            jezici.Add("Spanski".ToUpper());
            jezici.Add("Nemacki".ToUpper());
            jezici.Add("Makedonski".ToUpper());
            jezici.Add("Srpski".ToUpper());
            
            lbJezici.ItemsSource = jezici;
            lbCasovi.ItemsSource = Data.Instance.Casovi;

            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj profesora";

                
                
            }
            else
            {
               this.Title = "Izmeni profesora";
                txtIme.Text = profesor.Korisnik.Ime;
                txtPrezime.Text = profesor.Korisnik.Prezime;
                txtJmbg.Text = profesor.Korisnik.JMBG;
                txtEmail.Text = profesor.Korisnik.Email;
                txtLozinka.Text = profesor.Korisnik.Lozinka;
                foreach(string s in profesor.ListaJezikaKojeProfesorPredaje){
                    lbJezici.SelectedItems.Add(s);
                }
                foreach(Cas s in profesor.ListaCasovaKojeProfesorPredaje)
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
                Profesor novi = new Profesor();

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
                    TipKorisnika = ETipKorisnika.PROFESOR
                };

                novi.Korisnik = korisnik;
                novi.Skola = (Skola)lbSkole.SelectedItem;

                List<Cas> listaCasova = new List<Cas>();
                foreach(Cas c in lbCasovi.SelectedItems)
                {
                    listaCasova.Add(c);
                }

                List<string> listaJezika = new List<string>();
                foreach(string s in lbJezici.SelectedItems)
                {
                    listaJezika.Add(s);
                }

                novi.ListaCasovaKojeProfesorPredaje = listaCasova;
                novi.ListaJezikaKojeProfesorPredaje = listaJezika;
                Data.Instance.Korisnici.Add(novi.Korisnik);
                Data.Instance.SacuvajEntitet(novi.Korisnik);
                Data.Instance.Profesori.Add(novi);
                Data.Instance.SacuvajEntitet(novi);


            } else
            {
                EPol pol = new EPol();
                Enum.TryParse(cbPol.Text, out pol);
                Profesor p = Data.Instance.Profesori.ToList().Find(x => x.Korisnik.Email.Equals(txtEmail.Text));
                p.Korisnik.Ime = txtIme.Text;
                p.Korisnik.Prezime = txtPrezime.Text;
                p.Korisnik.JMBG = txtJmbg.Text;
                p.Korisnik.Pol = pol;
                p.Korisnik.Email = txtEmail.Text;
                p.Korisnik.Lozinka = txtLozinka.Text;
                p.Korisnik.Adresa = (Adresa)cbAdresa.SelectedItem;
                p.Skola = (Skola)lbSkole.SelectedItem;
                List<Cas> listaCasova = new List<Cas>();
                foreach (Cas c in lbCasovi.SelectedItems)
                {
                    listaCasova.Add(c);
                }
                List<string> listaJezika = new List<string>();
                foreach (string s in lbJezici.SelectedItems)
                {
                    listaJezika.Add(s);
                }
                p.ListaCasovaKojeProfesorPredaje = listaCasova;
                p.ListaJezikaKojeProfesorPredaje = listaJezika;
                Data.Instance.SacuvajEntitet(p);

            }
            this.Close();
        }
    }
}
