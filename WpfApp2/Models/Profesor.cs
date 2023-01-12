using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    [Serializable]
    public class Profesor
    {
        private RegistrovaniKorisnik _korisnik;

        public RegistrovaniKorisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }
        private Skola _skola;
        public Skola Skola
        {
            get { return _skola; }
            set { _skola = value; }
        }
        public List<string> _listaJezikaKojeProfesorPredaje;
        public List<string> ListaJezikaKojeProfesorPredaje
        {
            get { return _listaJezikaKojeProfesorPredaje; }
            set { _listaJezikaKojeProfesorPredaje = value; }
        }
        public List<Cas> _listaCasovaKojeProfesorPredaje;
        public List<Cas> ListaCasovaKojeProfesorPredaje
        {
            get { return _listaCasovaKojeProfesorPredaje; }
            set { _listaCasovaKojeProfesorPredaje = value; }
        }


        public override string ToString()
        {
            return "Ja sam profesor i moje ime je:" + _korisnik.Ime + ", a moj email je :" + _korisnik.Email;
        }

        public string ProfesorZaUpisUFajl()
        {
            string retVal = "";
            for (int i = 0; i < ListaJezikaKojeProfesorPredaje.Count; i++)
            {
                string deoListe = ListaJezikaKojeProfesorPredaje[i];
                if (retVal.Equals(""))
                {
                    retVal = deoListe;
                }
                else
                {
                    retVal = retVal + "," + deoListe;
                }
                
            }
            string retValDrugi = "";
            foreach (Cas c in ListaCasovaKojeProfesorPredaje)
            {
                string deoListe = c.ID;
                if (retValDrugi.Equals(""))
                {
                    retValDrugi = deoListe;
                } else
                {
                    retValDrugi = retValDrugi + "," + deoListe;
                }
                
            }
            return Korisnik.Email + ";" + Skola.ID + ";" + retVal + ";" + retValDrugi; //cyvamo jedinstveni identifikator profesora (email/JMBG/sifru)
        }
    }
}
