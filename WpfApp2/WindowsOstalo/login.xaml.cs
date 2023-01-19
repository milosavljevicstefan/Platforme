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
using WpfApp2.WindowsStudent;

namespace WpfApp2.WindowsOstalo
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void logovanje_Click(object sender, RoutedEventArgs e)
        {
            string jmbg = jmbgInput.Text;
            string lozinka = lozinkaInput.Text;
            RegistrovaniKorisnik ulogovan = Data.Instance.Login(jmbg, lozinka);
            if (ulogovan != null)
            {
                string rola = ulogovan.TipKorisnika.ToString();
                switch (rola)
                {
                    case "ADMINISTRATOR":HomeWindow home = new HomeWindow();home.Show();this.Close(); this.Close(); break;
                    case "STUDENT": StudentWindowMain studentHome = new StudentWindowMain(ulogovan);studentHome.Show(); this.Close(); break;
                    case "PROFESOR":;break;
                    default:
                        Console.WriteLine("Nije uspelo citanje entiteta, nije prosao switch rola");break;
                }
            }
        }

        

        private void register_Click(object sender, RoutedEventArgs e)
        {
            registracija reg = new registracija();
            reg.Show();
        }
    }
}
