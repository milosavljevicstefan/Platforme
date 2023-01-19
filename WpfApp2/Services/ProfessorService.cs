using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
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
            Data.Instance.ObrisiKorisnika(profesor.Korisnik.Email);

        }

        public void ReadUsers()
        {
            Data.Instance.Profesori = new ObservableCollection<Profesor>();
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from profesor p
left join profesor_jezik pj on p.korisnik_email = pj.profesor_email";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "profesor");

                foreach (DataRow dataRow in ds.Tables["profesor"].Rows)
                {
                    Profesor profesor = Data.Instance.Profesori.ToList().Find(x => x.Korisnik.Email == dataRow["profesor_email"].ToString());
                    Skola skola = Data.Instance.Skole.ToList().Find(x => x.ID == dataRow["skola_id"].ToString());
                    RegistrovaniKorisnik korisnik = Data.Instance.Korisnici.ToList().Find(x => x.Email == dataRow["korisnik_email"].ToString());
                    if (profesor == null)
                    {
                        profesor = new Profesor
                        {
                            Korisnik = korisnik,
                            Skola = skola,
                            ListaCasovaKojeProfesorPredaje = new List<Cas>(),
                            ListaJezikaKojeProfesorPredaje = new List<string>()
                            
                        };
                        profesor.ListaJezikaKojeProfesorPredaje.Add(dataRow["jezik"].ToString());
                        Data.Instance.Profesori.Add(profesor);
                    }
                    else
                    {
                        profesor.ListaJezikaKojeProfesorPredaje.Add(dataRow["jezik"].ToString());
                    }
                    
                }
            }
        }

        public void SaveUsers(Object obj)
        {
            Profesor profesor = obj as Profesor;

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from profesor";
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "profesor");
                DataRow newRow = ds.Tables["profesor"].NewRow();
                newRow["korisnik_email"] = profesor.Korisnik.Email;
                newRow["skola_id"] = profesor.Skola.ID;
                ds.Tables["profesor"].Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["profesor"]);

                //profesor_jezik
                string jezikProfesorString = "select * from profesor_jezik";
                DataSet ds2 = new DataSet();
                SqlDataAdapter dataAdapterr = new SqlDataAdapter(jezikProfesorString, conn);
                dataAdapterr.Fill(ds2, "profesor_jezik");
                foreach (String jezik in profesor.ListaJezikaKojeProfesorPredaje)
                {
                    DataRow row = ds2.Tables["profesor_jezik"].NewRow();
                    row["profesor_email"] = profesor.Korisnik.Email;
                    row["jezik"] = jezik.ToUpper();
                    ds2.Tables["profesor_jezik"].Rows.Add(row);
                }
                SqlCommandBuilder commandBuilderr = new SqlCommandBuilder(dataAdapterr);
                dataAdapterr.Update(ds2.Tables["profesor_jezik"]);

                //profesor_cas
                string casProfesorString = "select * from profesor_cas";
                DataSet ds3 = new DataSet();
                SqlDataAdapter dataAdapterrr = new SqlDataAdapter(casProfesorString, conn);
                dataAdapterrr.Fill(ds3, "profesor_cas");
                foreach (Cas cas in profesor.ListaCasovaKojeProfesorPredaje)
                {
                    DataRow row = ds3.Tables["profesor_cas"].NewRow();
                    row["profesor_email"] = profesor.Korisnik.Email;
                    long.TryParse(cas.ID, out long id);
                    row["cas_id"] = id;
                    ds3.Tables["profesor_cas"].Rows.Add(row);
                }
                SqlCommandBuilder commandBuilderrr = new SqlCommandBuilder(dataAdapterrr);
                dataAdapterrr.Update(ds3.Tables["profesor_cas"]);
            }
        }
    }
}