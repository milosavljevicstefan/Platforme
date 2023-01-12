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
    class StudentService : IUserService
    {
        void IUserService.DeleteUser(string email)
        {
            Student student = Data.Instance.Studenti.ToList().Find((s) => s.Korisnik.Email == email);
            if (student == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.Korisnici.Remove(student.Korisnik);
            Data.Instance.Studenti.Remove(student);
            Data.Instance.SacuvajEntitet("korisnici.txt");
            Data.Instance.SacuvajEntitet("studenti.txt");
        }

        void IUserService.ReadUsers(string filename)
        {
            Data.Instance.CitanjeEntiteta("casovi.txt");
            Data.Instance.Studenti = new ObservableCollection<Student>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] studentIzFajla = line.Split(';');

                    RegistrovaniKorisnik registrovaniKorisnik = Data.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(studentIzFajla[0]));
                    string[] nizCasova = studentIzFajla[1].Split(',');

                    List<Cas> listaCasova = new List<Cas>();
                    for (int i = 0; i < nizCasova.Length; i++)
                    {
                        Cas cas = Data.Instance.Casovi.ToList().Find(c => c.ID.Equals(nizCasova[i]));
                        listaCasova.Add(cas);

                    }

                    Student student = new Student
                    {
                        Korisnik = registrovaniKorisnik,
                        ListaCasova = listaCasova
                    };

                    Data.Instance.Studenti.Add(student);
                }
                //ovo samo priliko inicijalizacije
                Data.Instance.NalepiStudenteNaCasove();
                Data.Instance.NalepiCasoveNaProfesora();
            }
        }

        void IUserService.SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Student student in Data.Instance.Studenti)
                {
                    file.WriteLine(student.StudentZaUpisFAjl());
                }
            }
        }
    }
}
