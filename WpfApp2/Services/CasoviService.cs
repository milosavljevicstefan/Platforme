using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    class CasoviService : ICasoviService
    {
        void ICasoviService.IzbrisiCas(string id)
        {
            Cas cas = Data.Instance.Casovi.ToList().Find(c => c.ID.Equals(id));
            if (cas == null)
            {
                throw new ArgumentNullException();
            }
            cas.Profesor.ListaCasovaKojeProfesorPredaje.Remove(cas);
            cas.Student.ListaCasova.Remove(cas);
            Data.Instance.Casovi.Remove(cas);
            Data.Instance.SacuvajEntitet("profesori.txt");
            Data.Instance.SacuvajEntitet("studenti.txt");
            Data.Instance.SacuvajEntitet("casovi.txt");

        }

        void ICasoviService.ProcitajCasove(string filename)
        {
            Data.Instance.Casovi = new ObservableCollection<Cas>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {

                    string[] casoIzFajla = line.Split(';');
                    Enum.TryParse(casoIzFajla[4], out EStatusCasa status);
                    Profesor profesor = Data.Instance.Profesori.ToList().Find(p => p.Korisnik.Email.Equals(casoIzFajla[1]));
                    Student student = new Student();
                    RegistrovaniKorisnik rk = new RegistrovaniKorisnik();
                    rk.Email = casoIzFajla[5];
                    student.Korisnik = rk;
                    DateTime dt = DateTime.ParseExact(casoIzFajla[2], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    Cas cas = new Cas
                    {
                        ID = casoIzFajla[0],
                        Profesor = profesor,
                        DatumIVremeOdrzavanja = dt,
                        Trajanje = Int32.Parse(casoIzFajla[3]),
                        StatusCasa = status,
                        Student = student

                    };
                    Data.Instance.Casovi.Add(cas);
                }
            }
        }

        void ICasoviService.SacuvajCas(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Cas cas in Data.Instance.Casovi)
                {
                    Student student = Data.Instance.Studenti.ToList().Find(s => s.Korisnik.Email.Equals(cas.Student.Korisnik.Email));
                    student.ListaCasova.Add(cas);
                    file.WriteLine(cas.CasZaUpisUFajl());
                }
            }
        }
    }
}
