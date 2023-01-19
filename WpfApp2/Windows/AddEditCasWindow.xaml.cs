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
    /// Interaction logic for AddEditCasWindow.xaml
    /// </summary>
    public partial class AddEditCasWindow : Window
    {
        private Cas selektovaniCas;
        private EStatus selektovaniStatus;
        public AddEditCasWindow(EStatus status, Cas cas)
        {
            InitializeComponent();
            selektovaniCas = cas;
            selektovaniStatus = status;

            this.DataContext = cas;

            lbProfesori.ItemsSource = Data.Instance.Profesori;
            lbStatusi.ItemsSource = Enum.GetValues(typeof(EStatusCasa));
            lbStudenti.ItemsSource = Data.Instance.Studenti;
            
            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj cas";
            } else
            {
                this.Title = "Izmeni cas";
                txtID.Text = cas.ID;
                lbProfesori.SelectedItem = cas.Profesor;
                dpDatum.DisplayDate = cas.DatumIVremeOdrzavanja.Date;
                txtVreme.Text = cas.DatumIVremeOdrzavanja.TimeOfDay.ToString();
                txtTrajanje.Text = cas.Trajanje.ToString();
                lbStatusi.SelectedItem = cas.StatusCasa;
                lbStudenti.SelectedItem = cas.Student;
                txtID.IsEnabled = false;
            }

        }
        //sacuvaj
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {

                EStatusCasa statusCasa = new EStatusCasa();
                Enum.TryParse(lbStatusi.SelectedItem.ToString(), out statusCasa);

                string[] listaNekaOdKorisnika = lbProfesori.SelectedItem.ToString().Split(':');
                string emailProfesora = listaNekaOdKorisnika[2];

                string[] listaNekaOdStudenta = lbStudenti.SelectedItem.ToString().Split(':');
                string emailStudenta = listaNekaOdStudenta[1];

                string[] datum = dpDatum.SelectedDate.ToString().Split('/');
                string[] godinaIVisak = datum[2].Split(' ');
                int mesec = int.Parse(datum[0]);
                int dan = int.Parse(datum[1]);
                int godina = int.Parse(godinaIVisak[0]);

                string[] vreme = txtVreme.Text.Split(':');
                int sati = int.Parse(vreme[0]);
                int minuti = int.Parse(vreme[1]);
                DateTime datumIVreme = new DateTime(godina, mesec, dan, sati, minuti, 00);

                Cas novi = new Cas
                {
                    ID = txtID.Text,
                    Profesor = Data.Instance.Profesori.ToList().Find(x => x.Korisnik.Email.Equals(emailProfesora)),
                    DatumIVremeOdrzavanja = datumIVreme,
                    Trajanje = int.Parse(txtTrajanje.Text),
                    StatusCasa = statusCasa,
                    Student = Data.Instance.Studenti.ToList().Find(x => x.Korisnik.Email.Equals(emailStudenta))
                };
                Data.Instance.Casovi.Add(novi);
                Data.Instance.SacuvajEntitet(novi);
            } 
            else
            {
                EStatusCasa statusCasa = new EStatusCasa();
                Enum.TryParse(lbStatusi.SelectedItem.ToString(), out statusCasa);

                Cas c = Data.Instance.Casovi.ToList().Find(x => x.ID.Equals(txtID.Text));

                string[] datum = dpDatum.SelectedDate.ToString().Split('/');
                string[] godinaIVisak = datum[2].Split(' ');
                int mesec = int.Parse(datum[0]);
                int dan = int.Parse(datum[1]);
                int godina = int.Parse(godinaIVisak[0]);

                string[] listaNekaOdKorisnika = lbProfesori.SelectedItem.ToString().Split(':');
                string emailProfesora = listaNekaOdKorisnika[2];

                string[] listaNekaOdStudenta = lbStudenti.SelectedItem.ToString().Split(':');
                string emailStudenta = listaNekaOdStudenta[1];

                string[] vreme = txtVreme.Text.Split(':');
                int sati = int.Parse(vreme[0]);
                int minuti = int.Parse(vreme[1]);
                DateTime datumIVreme = new DateTime(godina, mesec, dan, sati, minuti, 00);
                c.Profesor = Data.Instance.Profesori.ToList().Find(x => x.Korisnik.Email.Equals(emailProfesora));
                c.DatumIVremeOdrzavanja = datumIVreme;
                c.Trajanje = int.Parse(txtTrajanje.Text);
                c.StatusCasa = statusCasa;
                c.Student = Data.Instance.Studenti.ToList().Find(x => x.Korisnik.Email.Equals(emailStudenta));

                Data.Instance.SacuvajEntitet("casovi.txt");
            }
            this.Close();
        }
        //odustani
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
