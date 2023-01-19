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
using System.Windows;

namespace WpfApp2.Services
{
    class SkolaService : ISkolaService
    {
        public void IzmeniSkolu(object obj)
        {
            Skola sk = obj as Skola;
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE skola SET id = @id, naziv = @naziv, adresa_id = @adresa_id Where id = @id";

                int.TryParse(sk.ID, out int id);
                int.TryParse(sk.Adresa.ID, out int adresa_id);


                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("naziv", sk.Naziv));
                command.Parameters.Add(new SqlParameter("adresa_id", adresa_id));

                command.ExecuteNonQuery();
            }
        }

        void ISkolaService.IzbrisiAdresu(int id)
        {
            Skola skola = Data.Instance.Skole.ToList().Find(s => s.ID.Equals(id.ToString()));
            if (skola == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.Skole.Remove(skola);
            try
            {
                const string query = @"DELETE FROM skola WHERE skola.Id = @ID;";
                using (SqlConnection con = new SqlConnection(Data.CONNECTION_STRING))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = skola.ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Row deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred:\r\n" + ex.Message);
            }
        }

        void ISkolaService.ProcitajSkolu()
        {
            Data.Instance.Skole = new ObservableCollection<Skola>();
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"use skola
                                        select * from skola
                                        left join skola_jezik on skola.id = skola_jezik.skola_id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "adresa");

                foreach (DataRow dataRow in ds.Tables["adresa"].Rows)
                {
                    Skola skola = Data.Instance.Skole.ToList().Find(x => x.ID == dataRow["id"].ToString());
                    Adresa adresa = Data.Instance.Adrese.ToList().Find(x => x.ID == dataRow["adresa_id"].ToString());
                    if (skola == null)
                    {
                        skola = new Skola
                        {
                            ID = dataRow["id"].ToString(),
                            Naziv = dataRow["naziv"].ToString(),
                            Adresa = adresa,
                            ListaJezikaKojeJeMogucePolagati = new List<string>()
                        };
                        skola.ListaJezikaKojeJeMogucePolagati.Add(dataRow["jezik"].ToString());
                        Data.Instance.Skole.Add(skola);
                    } 
                    else
                    {
                        skola.ListaJezikaKojeJeMogucePolagati.Add(dataRow["jezik"].ToString());
                    }
                    
                }
            }

        }

        void ISkolaService.SacuvajSkolu(Object obj)
        {
            Skola skola = obj as Skola;

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                string skolaString = "select * from skola";
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(skolaString, conn);
                dataAdapter.Fill(ds, "skola");
                DataRow newRow = ds.Tables["skola"].NewRow();
                newRow["id"] = skola.ID;
                newRow["naziv"] = skola.Naziv;
                newRow["adresa_id"] = skola.Adresa.ID;
                ds.Tables["skola"].Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["skola"]);



                string skolaJezikString = "select * from skola_jezik";
                
                foreach (string jezik in skola.ListaJezikaKojeJeMogucePolagati)
                {
                    DataSet dsJezik = new DataSet();
                    SqlDataAdapter dataAdapterJezik = new SqlDataAdapter(skolaJezikString, conn);
                    dataAdapterJezik.Fill(dsJezik, "skola_jezik");
                    DataRow newRoww = dsJezik.Tables["skola_jezik"].NewRow();
                    newRoww["skola_id"] = skola.ID;
                    newRoww["jezik"] = jezik;
                    dsJezik.Tables["skola_jezik"].Rows.Add(newRoww);
                    SqlCommandBuilder commandBuilderr = new SqlCommandBuilder(dataAdapterJezik);
                    dataAdapterJezik.Update(dsJezik.Tables["skola_jezik"]);
                }
                



            }
        }
    }
}
