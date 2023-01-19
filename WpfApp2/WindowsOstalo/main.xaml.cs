using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main()
        {
            ObservableCollection<RegistrovaniKorisnik> profesoriDTO = new ObservableCollection<RegistrovaniKorisnik>();

            InitializeComponent();
            Data.Instance.CitanjeEntiteta("adrese.txt");
            Data.Instance.CitanjeEntiteta("skole.txt");
            Data.Instance.CitanjeEntiteta("korisnici.txt");
            Data.Instance.CitanjeEntiteta("profesori.txt");
            Data.Instance.CitanjeEntiteta("studenti.txt");
            Data.Instance.CitanjeEntiteta("casovi.txt");
            Data.Instance.NalepiCasoveNaProfesore();
            Data.Instance.NalepiCasoveNaStudente();
            Console.Write("lele");
            dgSkole.ItemsSource = Data.Instance.Skole;
            foreach(Profesor p in Data.Instance.Profesori)
            {
                string profesor = p.Korisnik.Ime + " " + p.Korisnik.Prezime + " radi u skoli: " + p.Skola.Naziv;
                profesoriDTO.Add(p.Korisnik);
            }
            dgProfesori.ItemsSource = profesoriDTO;

            //dgProfesori.Columns[2].Visibility = Visibility.Hidden;

            //dgProfesori.Columns[3].Visibility = Visibility.Hidden;
            //dgProfesori.Columns[4].Visibility = Visibility.Hidden;
            //dgProfesori.Columns[5].Visibility = Visibility.Hidden;


        }

        private void miLogin_Click(object sender, RoutedEventArgs e)
        {
            login noviLogin = new login();
            noviLogin.Show();
            this.Close();
        }
    }
}
