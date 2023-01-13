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
    /// Interaction logic for AllCasoviWindow.xaml
    /// </summary>
    public partial class AllCasoviWindow : Window
    {
        public AllCasoviWindow()
        {
            InitializeComponent();
            dgCasovi.ItemsSource = Data.Instance.Casovi;

        }

        private void miDodajCas_Click(object sender, RoutedEventArgs e)
        {
            Cas c = new Cas();
            AddEditCasWindow addEditCasWindow = new AddEditCasWindow(EStatus.DODAJ, c);
            addEditCasWindow.Show();
        }

        private void miIzmeniCas_Click(object sender, RoutedEventArgs e)
        {
            Cas c = (Cas)dgCasovi.SelectedItem;
            AddEditCasWindow addEditCasWindow = new AddEditCasWindow(EStatus.IZMENI, c);
            addEditCasWindow.Show();
        }

        private void miObrisiCas_Click(object sender, RoutedEventArgs e)
        {
            Cas c = (Cas)dgCasovi.SelectedItem;
            Data.Instance.ObrisiCas(c);
        }

        private void miVratiNaPocetnu_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            this.Hide();
            homeWindow.Show();
        }
    }
}
