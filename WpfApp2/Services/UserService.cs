using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.MyExceptions;

namespace WpfApp2.Services
{
    class UserService : IUserService
    {
        public void SaveUsers(Object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from registrovani_korisnik";
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "registrovani_korisnik");
                DataRow newRow = ds.Tables["registrovani_korisnik"].NewRow();
                newRow["ime"] = korisnik.Ime;
                newRow["prezime"] = korisnik.Prezime;
                int.TryParse(korisnik.JMBG, out int jmbg);
                newRow["jmbg"] = jmbg;
                newRow["pol"] = korisnik.Pol.ToString();
                newRow["adresa_id"] = korisnik.Adresa.ID;
                newRow["email"] = korisnik.Email;
                newRow["lozinka"] = korisnik.Lozinka;
                newRow["tip"] = korisnik.TipKorisnika.ToString();
                newRow["aktivan"] = korisnik.Aktivan;

                ds.Tables["registrovani_korisnik"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["registrovani_korisnik"]);
            }
        }

        public void ReadUsers()
        {
            Data.Instance.Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from registrovani_korisnik";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "registrovani_korisnik");

                foreach (DataRow dataRow in ds.Tables["registrovani_korisnik"].Rows)
                {
                    Enum.TryParse(dataRow["pol"].ToString(), out EPol statusPol);
                    Enum.TryParse(dataRow["tip"].ToString(), out ETipKorisnika status);
                    Adresa adresa = Data.Instance.Adrese.ToList().Find(x => x.ID == dataRow["adresa_id"].ToString());
                    RegistrovaniKorisnik korisnik = new RegistrovaniKorisnik
                    {
                        Ime = dataRow["ime"].ToString(),
                        Prezime = dataRow["prezime"].ToString(),
                        JMBG = dataRow["jmbg"].ToString(),
                        Pol = statusPol,
                        Adresa = adresa,
                        Email = dataRow["email"].ToString(),
                        Lozinka = dataRow["lozinka"].ToString(),
                        TipKorisnika = status,
                        Aktivan = (bool)dataRow["aktivan"]
                    };
                    Data.Instance.Korisnici.Add(korisnik);
                }
            }
        }

        public void DeleteUser(string email)
        {
            RegistrovaniKorisnik registrovaniKorisnik = Data.Instance.Korisnici.ToList().Find(k => k.Email.Contains(email));
            if (registrovaniKorisnik == null)
            {
                //Console.WriteLine($"Ne postoji taj korisnik sa email adresom {email}" );
                //Ako ne pronadjem korisnika bacam izuzetak
                throw new UserNotFoundException($"Ne postoji taj korisnik sa email adresom {email}");
            }
            registrovaniKorisnik.Aktivan = false;
            this.DeactivateUser(registrovaniKorisnik);
        }

        private void DeactivateUser(RegistrovaniKorisnik registrovaniKorisnik)
        {
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update registrovani_korisnik
                                        set Aktivan = @Aktivan
                                        where Email = @Email";
                command.Parameters.Add(new SqlParameter("Aktivan", registrovaniKorisnik.Aktivan));
                command.Parameters.Add(new SqlParameter("Email", registrovaniKorisnik.Email));

                command.ExecuteNonQuery();
            }
        }
    }
}
