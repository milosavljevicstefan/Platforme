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
    /// Interaction logic for AddEditAdressesWindow.xaml
    /// </summary>
    public partial class AddEditAdressesWindow : Window
    {
        private Adresa selektovanaAdresa;
        private EStatus selektovaniStatus;
        public AddEditAdressesWindow(EStatus status, Adresa adresa)
        {
            InitializeComponent();
            selektovanaAdresa = adresa;
            selektovaniStatus = status;

            this.DataContext = adresa;

            if (status.Equals(EStatus.IZMENI))
                txtId.IsReadOnly = true;

            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj adresu";
            }
            else
            {
                this.Title = "Izmeni adresu";
            }
        }

 

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            
            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                Adresa a = new Adresa();
                a.ID = txtId.Text;
                a.Ulica = txtUlica.Text;
                a.Broj = txtBroj.Text;
                a.Grad = txtGrad.Text;
                a.Drzava = txtDrzava.Text;
                Data.Instance.Adrese.Add(a);
                Data.Instance.SacuvajEntitet("adrese.txt");
            } else
            {
                Adresa a = Data.Instance.Adrese.ToList().Find(x => x.ID.Equals(txtId.Text));
                a.Ulica = txtUlica.Text;
                a.Broj = txtBroj.Text;
                a.Grad = txtGrad.Text;
                a.Drzava = txtGrad.Text;
                Data.Instance.SacuvajEntitet("adrese.txt");
            }
            this.Close();

        }
    }
}
