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
    /// Interaction logic for ZakazivanjeCasaWindow.xaml
    /// </summary>
    public partial class ZakazivanjeCasaWindow : Window
    {
        private RegistrovaniKorisnik prijavljeniKorisnik;
        public ZakazivanjeCasaWindow(RegistrovaniKorisnik prijavljeniKorisnik)
        {
            InitializeComponent();
            lbCasovi.ItemsSource = Data.Instance.DajSlobodneCasove();
            this.prijavljeniKorisnik = prijavljeniKorisnik;
            
        }

        private void sacuvajButton_Click(object sender, RoutedEventArgs e)
        {
            Student noviStudent = Data.Instance.Studenti.ToList().Find(x => x.Korisnik.Email == prijavljeniKorisnik.Email);
            Cas s = (Cas)lbCasovi.SelectedItem;
            s.Student = noviStudent;
            s.StatusCasa = EStatusCasa.REZERVISAN;
            Data.Instance.UpdateEntitet(s);
            this.Close();
            lbCasovi.ItemsSource = Data.Instance.DajSlobodneCasove();
        }

        private void odustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
