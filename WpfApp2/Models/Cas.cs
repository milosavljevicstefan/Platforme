using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    [Serializable]
    public class Cas
    {
        public string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Profesor _profesor;
        public Profesor Profesor
        {
            get { return _profesor; }
            set { _profesor = value; }
        }
        private DateTime _datumOdrzavanja;
        public DateTime DatumIVremeOdrzavanja
        {
            get { return _datumOdrzavanja; }
            set { _datumOdrzavanja = value; }
        }
        private int _trajanje;
        public int Trajanje
        {
            get { return _trajanje; }
            set { _trajanje = value; }
        }
        private EStatusCasa _statusCasa;
        public EStatusCasa StatusCasa
        {
            get { return _statusCasa; }
            set { _statusCasa = value; }
        }
        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { _student = value; }
        }
        public override string ToString()
        {
            return "Cas: " + ID;
        }

        public string CasZaUpisUFajl()
        {
            return ID + ";" + Profesor.Korisnik.Email + ";" + DatumIVremeOdrzavanja.ToString("dd/MM/yyyy HH:mm") + ";" + Trajanje + ";" + StatusCasa + ";" + Student.Korisnik.Email;
        }
    }
}
