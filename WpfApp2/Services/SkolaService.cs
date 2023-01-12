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
    class SkolaService : ISkolaService
    {
        void ISkolaService.IzbrisiAdresu(int id)
        {
            Skola skola = Data.Instance.Skole.ToList().Find(s => s.ID.Equals(id));
            if (skola == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.Skole.Remove(skola);
        }

        void ISkolaService.ProcitajSkolu(string filename)
        {
            Data.Instance.Skole = new ObservableCollection<Skola>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] skolaIzFajla = line.Split(';');
                    string[] listaJezika = skolaIzFajla[3].Split(',');
                    List<string> listaJezikaLista = new List<string>();
                    for (int i = 0; i < listaJezika.Length; i++)
                    {
                        listaJezikaLista.Add(listaJezika[i]);
                    }
                    Adresa a = Data.Instance.Adrese.ToList().Find(x => x.ID.Equals(skolaIzFajla[2]));

                    Skola skola = new Skola
                    {
                        ID = skolaIzFajla[0],
                        Naziv = skolaIzFajla[1],
                        Adresa = a,
                        ListaJezikaKojeJeMogucePolagati = listaJezikaLista
                    };

                    Data.Instance.Skole.Add(skola);

                }
            }

        }

        void ISkolaService.SacuvajSkolu(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Skola skola in Data.Instance.Skole)
                {
                    file.WriteLine(skola.SkolaZaUpisUFajl());
                }
            }
        }
    }
}
