using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    [Serializable]
    public class Student
    {
        private RegistrovaniKorisnik _korisnik;

        public RegistrovaniKorisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }
        public List<Cas> _listaCasova;
        public List<Cas> ListaCasova
        {
            get { return _listaCasova; }
            set { _listaCasova = value; }
        }
        public override string ToString()
        {
            return "Ja sam " + Korisnik.Ime + "moj mail je:" + Korisnik.Email;
        }
        public string StudentZaUpisFAjl()
        {
            string retVal = "";
            for (int i = 0; i < ListaCasova.Count; i++)
            {
                string deoListe = ListaCasova[i].ID.ToString();
                if (retVal.Equals(""))
                {
                    retVal = deoListe;
                } else
                {
                    retVal = retVal + "," + deoListe;

                }
            }
            return Korisnik.Email + ";" + retVal; //cyvamo
        }
    }
}
