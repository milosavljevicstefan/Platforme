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
    /// Interaction logic for AddEditSkoleWindow.xaml
    /// </summary>
    public partial class AddEditSkoleWindow : Window
    {
        private Skola selektovanaSkola;
        private EStatus selektovaniStatus;
        public AddEditSkoleWindow(EStatus selektovaniStatus, Skola skola)
        {
            InitializeComponent();
            this.selektovaniStatus = selektovaniStatus;
            this.selektovanaSkola = skola;
            this.DataContext = skola;

            cbAdresa.ItemsSource = Data.Instance.Adrese;
            List<string> jezici = new List<string>();
            jezici.Add("Engleski".ToUpper());
            jezici.Add("Spanski".ToUpper());
            jezici.Add("Nemacki".ToUpper());
            jezici.Add("Makedonski".ToUpper());
            jezici.Add("Srpski".ToUpper());

            lbJezici.ItemsSource = jezici;
            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj skolu";
            }
            else
            {
                this.Title = "Izmeni skolu";
                txtId.Text = skola.ID;
                txtId.IsEnabled = false;
                txtNaziv.Text = skola.Naziv;
                foreach (string jezik in skola.ListaJezikaKojeJeMogucePolagati)
                {
                    lbJezici.SelectedItems.Add(jezik);
                }
            }
        }

        private void sacuvajButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> lista = new List<string>();
            foreach (string jezik in lbJezici.SelectedItems)
            {
                lista.Add(jezik);
            }
            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                

                
                Skola skola = new Skola
                {
                    ID = txtId.Text,
                    Naziv = txtNaziv.Text,
                    Adresa = (Adresa)cbAdresa.SelectedItem,
                    ListaJezikaKojeJeMogucePolagati = lista
                    
                };
                Data.Instance.Skole.Add(skola);
                Data.Instance.SacuvajEntitet(skola);



            }
            else
            {

                Skola skola = Data.Instance.Skole.ToList().Find(x => x.ID == txtId.Text);
                skola.Naziv = txtNaziv.Text;
                skola.Adresa = (Adresa)cbAdresa.SelectedItem;
                skola.ListaJezikaKojeJeMogucePolagati = lista;
                Data.Instance.UpdateEntitet(skola);
            }
            this.Close();
        }

        private void odustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
