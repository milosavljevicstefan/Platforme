using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    internal class AdresaService : IAdresaService
    {
        void IAdresaService.IzbrisiAdresu(string id)
        {
            Adresa adresa = Data.Instance.Adrese.ToList().Find(a => a.ID.Equals(id));
            if (adresa == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.Adrese.Remove(adresa);
            Data.Instance.SacuvajEntitet("adrese.txt");

            
        }

        void IAdresaService.ProcitajAdrese(string filename)
        {
            Data.Instance.Adrese = new ObservableCollection<Adresa>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] adresaIzFajla = line.Split(';');


                    Adresa adresa = new Adresa
                    {
                        ID = adresaIzFajla[0],
                        Ulica = adresaIzFajla[1],
                        Broj = adresaIzFajla[2],
                        Grad = adresaIzFajla[3],
                        Drzava = adresaIzFajla[4]
                    };

                    Data.Instance.Adrese.Add(adresa);
                }
            }
        }

        void IAdresaService.SacuvajAdrese(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Adresa adresa in Data.Instance.Adrese)
                {
                    file.WriteLine(adresa.AdresaZaUpisUFajl());
                }
            }
        }
    }
}
