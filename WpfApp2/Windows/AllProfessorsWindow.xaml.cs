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
    /// Interaction logic for AllProfessorsWindow.xaml
    /// </summary>
    public partial class AllProfessorsWindow : Window
    {
        public AllProfessorsWindow()
        {
            InitializeComponent();

            dgProfesori.ItemsSource = null;
            dgProfesori.ItemsSource = Data.Instance.Profesori;
        }

        private void miDodajProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor p = new Profesor();
            AddEditProfessorWindow addEditProfessorWindow = new AddEditProfessorWindow(EStatus.DODAJ, p);

            addEditProfessorWindow.Show();
        }

        private void miIzmeniProfesora_Click(object sender, RoutedEventArgs e)
        {
            // proveriti da li je nesto uopste selektovano u tabeli
            // ako nije, ispisi poruku korisniku
            Profesor p = (Profesor)dgProfesori.SelectedItem;
            //RegistrovaniKorisnik k = Data.Instance.Korisnici.ToList().Find(x => x.Email.Equals(p.Korisnik.Email));

            //kopija originalnog korisnika
            Profesor kopijaProfesora = new Profesor();
            kopijaProfesora.Korisnik = p.Korisnik;
            kopijaProfesora.Skola = p.Skola;
            kopijaProfesora.ListaJezikaKojeProfesorPredaje = p.ListaJezikaKojeProfesorPredaje;
            kopijaProfesora.ListaCasovaKojeProfesorPredaje = p.ListaCasovaKojeProfesorPredaje;

            AddEditProfessorWindow addEditProfessorWindow = new AddEditProfessorWindow(EStatus.IZMENI, p);
            
         
            if ((bool)!addEditProfessorWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Profesori.ToList().FindIndex(ko => ko.Korisnik.Email.Equals(p.Korisnik.Email));
                Data.Instance.Profesori[index] = kopijaProfesora;
            }

        }

        private void miObrisiProfesora_Click(object sender, RoutedEventArgs e)
        {
            Profesor p = (Profesor)dgProfesori.SelectedItem;
            Data.Instance.ObrisiProfesora(p);
        }
    }
}
