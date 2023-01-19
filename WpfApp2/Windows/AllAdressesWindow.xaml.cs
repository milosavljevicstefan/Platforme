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
    /// Interaction logic for AllAdressesWindow.xaml
    /// </summary>
    public partial class AllAdressesWindow : Window
    {
        public AllAdressesWindow()
        {
            InitializeComponent();
            dgAdrese.ItemsSource = Data.Instance.Adrese;
        }

        private void miDodajAdresu_Click(object sender, RoutedEventArgs e)
        {
            Adresa a = new Adresa();
            AddEditAdressesWindow addEditAdressesWindow = new AddEditAdressesWindow(EStatus.DODAJ, a);
            addEditAdressesWindow.Show();
        }

        private void miIzmeniAdresu_Click(object sender, RoutedEventArgs e)
        {
            //provera da li je selektovan
            Adresa a = (Adresa)dgAdrese.SelectedItem;
            Adresa kopijaAdrese = new Adresa();
            kopijaAdrese.ID = a.ID;
            kopijaAdrese.Ulica = a.Ulica;
            kopijaAdrese.Broj = a.Broj;
            kopijaAdrese.Grad = a.Grad;
            kopijaAdrese.Drzava = a.Drzava;

            AddEditAdressesWindow addEditAdressesWindow = new AddEditAdressesWindow(EStatus.IZMENI, a);

            if ((bool)!addEditAdressesWindow.ShowDialog())
            {
                //kopiju postavljam umesto izmenjenog objekta
                int index = Data.Instance.Adrese.ToList().FindIndex(adr => adr.ID.Equals(a.ID));
                Data.Instance.Adrese[index] = kopijaAdrese;
            }
        }

        private void miObrisiAdresu_Click(object sender, RoutedEventArgs e)
        {
            //provera da li je selektovan
            Adresa a = (Adresa)dgAdrese.SelectedItem;

            Data.Instance.ObrisiAdresu(a.ID);
        }

        private void miVratiNaPocetnu_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            this.Hide();
            homeWindow.Show();
        }
    }
}
