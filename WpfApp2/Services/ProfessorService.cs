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
    class ProfessorService : IUserService
    {
        public void DeleteUser(string email)
        {
            Profesor profesor = Data.Instance.Profesori.ToList().Find(p => p.Korisnik.Email == email);
            if (profesor == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.Korisnici.Remove(Data.Instance.Korisnici.ToList().Find(x => x.Email.Equals(profesor.Korisnik.Email)));
            Data.Instance.Profesori.Remove(profesor);
            Data.Instance.SacuvajEntitet("korisnici.txt");
            Data.Instance.SacuvajEntitet("profesori.txt");

        }

        public void ReadUsers()
        {
            /*Data.Instance.CitanjeEntiteta("skole.txt");
            Data.Instance.Profesori = new ObservableCollection<Profesor>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] profesorIzFajla = line.Split(';');

                    RegistrovaniKorisnik registrovaniKorisnik = Data.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(profesorIzFajla[0]));
                    Skola skola = Data.Instance.Skole.ToList().Find(s => s.ID == profesorIzFajla[1]);
                    string[] nizJezika = profesorIzFajla[2].Split(',');
                    List<string> lista = new List<string>();
                    foreach (string s in nizJezika)
                    {
                        lista.Add(s);
                    }
                    string[] nizCasova = profesorIzFajla[3].Split(',');
                     ///List<Cas> listaCasova = new List<Cas>();
                     // foreach (string s in nizCasova)
                    // {
                    //     Cas cas = new Cas();
                    //    cas.ID = s;
                    //    listaCasova.Add(cas);
                    // }


                    Profesor profesor = new Profesor
                    {
                        Korisnik = registrovaniKorisnik,
                        Skola = skola,
                        ListaJezikaKojeProfesorPredaje = lista,
                        ListaCasovaKojeProfesorPredaje = new List<Cas>()
                    };
                    Data.Instance.Profesori.Add(profesor);
                }
            }*/
        }

        public void SaveUsers(Object obj)
        {
            /*using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Profesor profesor in Data.Instance.Profesori)
                {
                    
                    file.WriteLine(profesor.ProfesorZaUpisUFajl());
                }

            }*/
        }
    }
}