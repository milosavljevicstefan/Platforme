using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Models
{
    [Serializable]
    internal class Skola
    {
        public string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
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

        public List<EJezik> _jezici;

        public List<EJezik> Jezici
        {
            get { return _jezici; }
            set { _jezici = value; }
        }

        public override string ToString()
        {
            return "Sifra: " + Sifra + " naziv: " + Naziv + " adresa: " + Adresa + " lista jezika: " + Jezici ;
        }
    }
}
