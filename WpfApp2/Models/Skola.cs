using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    [Serializable]
    public class Skola
    {
        public string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string _naziv;
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        public Adresa _adresa;
        public Adresa Adresa
        {
            get { return _adresa; }
            set { _adresa = value; }
        }

        public List<string> _listaJezikaKojeJeMogucePolagati;
        public List<string> ListaJezikaKojeJeMogucePolagati
        {
            get { return _listaJezikaKojeJeMogucePolagati; }
            set { _listaJezikaKojeJeMogucePolagati = value; }
        }
        public override string ToString()
        {
            return Naziv;
        }

        public string SkolaZaUpisUFajl()
        {
            string retVal = "";
            for (int i = 0; i < ListaJezikaKojeJeMogucePolagati.Count; i++)
            {
                string deoListe = ListaJezikaKojeJeMogucePolagati[i];
                retVal = retVal + "," + deoListe;

            }
            return ID + ";" + Naziv + ";" + Adresa.ID + ";" + retVal ;
        }
    }
}
