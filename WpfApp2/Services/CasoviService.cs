using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                const string query = @"DELETE FROM cas WHERE cas.Id = @ID;";
                using (SqlConnection con = new SqlConnection(Data.CONNECTION_STRING))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = cas.ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Row deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred:\r\n" + ex.Message);
            }
            Data.Instance.SacuvajEntitet(cas.Profesor);
            Data.Instance.SacuvajEntitet(cas.Student);

        }

        void ICasoviService.ProcitajCasove()
        {
            Data.Instance.Casovi = new ObservableCollection<Cas>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from cas";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "cas");

                foreach (DataRow dataRow in ds.Tables["cas"].Rows)
                {
                    string[] split = dataRow["datum_odrzavanja"].ToString().Split(' ');
                    string datumIVreme = split[0] + " " + dataRow["vreme_pocetka"].ToString();
                    DateTime.TryParse(datumIVreme, out DateTime datumVremeOdrzavanja);
                    Profesor profesor = Data.Instance.Profesori.ToList().Find(x => x.Korisnik.Email == dataRow["profesor_email"].ToString());
                    Student student = Data.Instance.Studenti.ToList().Find(x => x.Korisnik.Email == dataRow["student_email"].ToString());
                    EStatusCasa.TryParse(dataRow["status_casa"].ToString(), out EStatusCasa status);

                    Cas cas = new Cas
                    {
                        ID = dataRow["id"].ToString(),
                        Profesor = profesor,
                        Student = student,
                        DatumIVremeOdrzavanja = datumVremeOdrzavanja,
                        Trajanje = (int)dataRow["trajanje"],
                        StatusCasa = status
                    };

                    Data.Instance.Casovi.Add(cas);
                }
            }
        }

        void ICasoviService.SacuvajCas(Object obj)
        {
            Cas cas = obj as Cas;
            Profesor prof = cas.Profesor;
            prof.ListaCasovaKojeProfesorPredaje.Add(cas);
            Student stud = cas.Student;
            stud.ListaCasova.Add(cas);
            Data.Instance.SacuvajEntitet(prof);
            Data.Instance.SacuvajEntitet(stud);
            if (cas != null)
            {
                using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
                {
                    conn.Open();

                    string skolaString = "select * from cas";
                    DataSet ds = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(skolaString, conn);
                    dataAdapter.Fill(ds, "cas");
                    DataRow newRow = ds.Tables["cas"].NewRow();
                    newRow["id"] = cas.ID;
                    newRow["profesor_email"] = cas.Profesor.Korisnik.Email;
                    newRow["datum_odrzavanja"] = cas.DatumIVremeOdrzavanja.Date;
                    newRow["vreme_pocetka"] = cas.DatumIVremeOdrzavanja.TimeOfDay;
                    newRow["trajanje"] = cas.Trajanje;
                    newRow["status_casa"] = cas.StatusCasa.ToString();
                    newRow["student_email"] = cas.Student.Korisnik.Email;
                    ds.Tables["cas"].Rows.Add(newRow);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(ds.Tables["cas"]);

                }
            }
            
        }
    }
}
