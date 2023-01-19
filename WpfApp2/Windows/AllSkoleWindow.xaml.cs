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
    /// Interaction logic for AllSkoleWindow.xaml
    /// </summary>
    public partial class AllSkoleWindow : Window
    {
        public AllSkoleWindow()
        {
            InitializeComponent();
            dgSkole.ItemsSource = Data.Instance.Skole;
        }

        private void miDodajSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola s = new Skola();
            AddEditSkoleWindow addEditSkoleWindow = new AddEditSkoleWindow(EStatus.DODAJ, s);
            addEditSkoleWindow.Show();
        }

        private void miIzmeniSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola s = (Skola)dgSkole.SelectedItem;
            Skola skolaKopija = new Skola();
            skolaKopija.ID = s.ID;
            skolaKopija.ListaJezikaKojeJeMogucePolagati = s.ListaJezikaKojeJeMogucePolagati;
            skolaKopija.Adresa = s.Adresa;
            skolaKopija.Naziv = s.Naziv;

            AddEditSkoleWindow addEditSkoleWindow = new AddEditSkoleWindow(EStatus.IZMENI, skolaKopija);
            if ((bool)!addEditSkoleWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Skole.ToList().FindIndex(x => x.ID.Equals(s.ID));
                Data.Instance.Skole[index] = skolaKopija;
            }

        }

        private void miObrisiSkolu_Click(object sender, RoutedEventArgs e)
        {
            Skola s = (Skola)dgSkole.SelectedItem;

            Data.Instance.ObrisiSkolu(s.ID);
        }

        private void miVratiNaPocetnu_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            this.Hide();
            homeWindow.Show();
        }
    }
}
