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
    internal class AdresaService : IAdresaService
    {
        void IAdresaService.IzbrisiAdresu(string id)
        {
            Adresa adresa = Data.Instance.Adrese.ToList().Find(a => a.ID.Equals(id));
            if (adresa == null)
            {
                throw new ArgumentNullException();
            }
            Data.Instance.Adrese.Remove(adresa);
            try
            {
                const string query = @"DELETE FROM adresa WHERE adresa.Id = @ID;";
                using (SqlConnection con = new SqlConnection(Data.CONNECTION_STRING))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = adresa.ID;
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

        void IAdresaService.ProcitajAdrese()
        {
            Data.Instance.Adrese = new ObservableCollection<Adresa>();

            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();
                DataSet ds = new DataSet();

                string selectedUser = @"select * from adresa";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectedUser, conn);
                dataAdapter.Fill(ds, "adresa");

                foreach (DataRow dataRow in ds.Tables["adresa"].Rows)
                {
                    
                    Adresa adresa = new Adresa
                    {
                        ID = dataRow["id"].ToString(),
                        Ulica = dataRow["ulica"].ToString(),
                        Broj = dataRow["broj"].ToString(),
                        Grad = dataRow["grad"].ToString(),
                        Drzava = dataRow["drzava"].ToString(),


                    };
                    Data.Instance.Adrese.Add(adresa);
                }
            }
        }

        void IAdresaService.SacuvajAdrese(Object obj)
        {
            Adresa adresa = obj as Adresa;
            using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
            {
                conn.Open();

                string users = "select * from adresa";
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(users, conn);
                dataAdapter.Fill(ds, "adresa");
                DataRow newRow = ds.Tables["adresa"].NewRow();
                newRow["id"] = adresa.ID;
                newRow["ulica"] = adresa.Ulica;
                newRow["broj"] = adresa.Broj;
                newRow["grad"] = adresa.Grad;
                newRow["Drzava"] = adresa.Drzava;

                ds.Tables["adresa"].Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds.Tables["adresa"]);
            }
        }
    }
}
