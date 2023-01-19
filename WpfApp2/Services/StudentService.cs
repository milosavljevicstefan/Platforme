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
    class StudentService : IUserService
    {
        public void UpdateUser(object obj)
        {
            Student student = obj as Student;
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "delete student_cas where student_email = @email";
                command.Parameters.Add(new SqlParameter("email", student.Korisnik.Email));
                command.ExecuteNonQuery();
                foreach (Cas c in student.ListaCasova)
                {
                    int.TryParse(c.ID, out int casId); 
                    SqlCommand commandd = conn.CreateCommand();
                    commandd.CommandText += " insert into student_cas values (@email, @cas_id)";
                    commandd.Parameters.Add(new SqlParameter("cas_id", casId));
                    commandd.Parameters.Add(new SqlParameter("email", student.Korisnik.Email));
                    commandd.ExecuteNonQuery();

                };
            }
        }

        void IUserService.DeleteUser(string email)
        {
            Student student = Data.Instance.Studenti.ToList().Find((s) => s.Korisnik.Email == email);
            if (student == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.ObrisiKorisnika(student.Korisnik.Email);
        }

        void IUserService.ReadUsers()
        {
            Data.Instance.Studenti = new ObservableCollection<Student>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from student";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "student");

                foreach (DataRow dataRow in ds.Tables["student"].Rows)
                {
                    RegistrovaniKorisnik korisnik = Data.Instance.Korisnici.ToList().Find((s) => s.Email == dataRow["korisnik_email"].ToString());
                    Student student = new Student
                    {
                        Korisnik = korisnik,
                        ListaCasova = new List<Cas>()
                    };
                    Data.Instance.Studenti.Add(student);
                }
            }
        }

        void IUserService.SaveUsers(Object obj)
        {
            Student student = obj as Student;
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                string studentString = "select * from student";
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(studentString, conn);
                dataAdapter.Fill(ds, "student");
                DataRow newRow = ds.Tables["student"].NewRow();
                newRow["korisnik_email"] = student.Korisnik.Email;
                ds.Tables["student"].Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["student"]);

                string studentCasString = "select * from student_cas";
                DataSet dsCas = new DataSet();
                SqlDataAdapter dataAdapterJezik = new SqlDataAdapter(studentCasString, conn);
                dataAdapterJezik.Fill(dsCas, "student_cas");

                foreach (Cas cas in student.ListaCasova)
                {
                    DataRow newRoww = dsCas.Tables["student_cas"].NewRow();
                    newRoww["student_email"] = student.Korisnik.Email;
                    newRoww["cas_id"] = cas.ID;
                    dsCas.Tables["student_cas"].Rows.Add(newRow);
                }
                SqlCommandBuilder commandBuilderr = new SqlCommandBuilder(dataAdapterJezik);
                dataAdapterJezik.Update(dsCas.Tables["student_cas"]);

            }
        }
    }
}
