using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WpfApp2.Services;

namespace WpfApp2.Models
{
    sealed class Data
    {
        private static readonly Data instance = new Data();
        public static readonly string CONNECTION_STRING = "Data Source=DESKTOP-PLV0TBA;Initial Catalog=skola;Integrated Security=True";
        private IUserService userService;
        private IUserService professorService;
        private IAdresaService adresaService;
        private ISkolaService skolaService;
        private IUserService studentService;
        private ICasoviService casoviService;

        static Data() { }

        private Data()
        {
            userService = new UserService();
            professorService = new ProfessorService();
            adresaService = new AdresaService();
            skolaService = new SkolaService();
            studentService = new StudentService();
            casoviService = new CasoviService();
        }

        public static Data Instance
        {
            get
            {
                return instance;
            }
        }

        public ObservableCollection<RegistrovaniKorisnik> Korisnici { get; set; }
        public ObservableCollection<Profesor> Profesori { get; set; }
        public ObservableCollection<Adresa> Adrese { get; set; }
        public ObservableCollection<Skola> Skole { get; set; }
        public ObservableCollection<Student> Studenti { get; set; }
        public ObservableCollection<Cas> Casovi { get; set; }

        public void SacuvajEntitet(Object obj)
        {
            if (obj is RegistrovaniKorisnik)
            {
                userService.SaveUsers(obj);
            }
            else if (obj is Profesor)
            {
                professorService.SaveUsers(obj);
            }
            else if (obj is Adresa)
            {
                adresaService.SacuvajAdrese(obj);
            }
            else if (obj is Cas)
            {
                casoviService.SacuvajCas(obj);
            }
            else if (obj is Student)
            {
                studentService.SaveUsers(obj);
            }
            else if (obj is Skola)
            {
                skolaService.SacuvajSkolu(obj);
            }

        }

        public void CitanjeEntiteta(string filename)
        {
            switch (filename)
            {
                case "korisnici.txt": userService.ReadUsers(); break;

                case "profesori.txt": professorService.ReadUsers(); break;

                case "adrese.txt": adresaService.ProcitajAdrese(); break;

                case "skole.txt": skolaService.ProcitajSkolu(); break;

                case "studenti.txt": studentService.ReadUsers(); break;

                case "casovi.txt": casoviService.ProcitajCasove(); break;

                default: Console.WriteLine("Nije uspelo citanje entiteta, nije prosao switch"); break;
            }
        }
        public void ObrisiKorisnika(string email)
        {
            userService.DeleteUser(email);
        }
        public void ObrisiProfesora(Profesor p)
        {
            professorService.DeleteUser(p.Korisnik.Email);
        }

        public void ObrisiCas(Cas c)
        {
            casoviService.IzbrisiCas(c.ID);

        }

        public void ObrisiStudenta(Student a)
        {
            studentService.DeleteUser(a.Korisnik.Email);
        }

        public void ObrisiAdresu(string id)
        {
            adresaService.IzbrisiAdresu(id);
        }

        internal void NalepiCasoveNaProfesore()
        {
            foreach (Cas c in Data.instance.Casovi)
            {
                Data.Instance.Profesori.ToList().Find(x => x.Korisnik.Email.Equals(c.Profesor.Korisnik.Email)).ListaCasovaKojeProfesorPredaje.Add(c);
            }
        }

        internal void NalepiCasoveNaStudente()
        {
            foreach (Cas c in Data.instance.Casovi)
            {
                Data.Instance.Studenti.ToList().Find(x => x.Korisnik.Email.Equals(c.Student.Korisnik.Email)).ListaCasova.Add(c);
            }
        }

        internal void UpdateEntitet(Object obj)
        {
            if (obj is RegistrovaniKorisnik)
            {
                userService.UpdateUser(obj);
            }
            else if (obj is Profesor)
            {
                professorService.UpdateUser(obj);
            }
            else if (obj is Adresa)
            {
                adresaService.IzmeniAdresu(obj);
            }
            else if (obj is Cas)
            {
                casoviService.IzmeniCas(obj);
            }
            else if (obj is Student)
            {
                studentService.UpdateUser(obj);
            }
            else if (obj is Skola)
            {
                skolaService.IzmeniSkolu(obj);
            }
        }
    }
}
