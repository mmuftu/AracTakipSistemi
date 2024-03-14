using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AracTakipSistemi.DB
{
    public class MSSQLHelper
    {
        public static string connectionString;

        public MSSQLHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MasterDBConnectionString"].ConnectionString;
        }


        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return command.ExecuteNonQuery();
                }

            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static Kullanici Kullanıci_Getir(string username, string password)
        {
            SqlParameter[] SelectParameters = {
                new SqlParameter("@Isim", SqlDbType.NVarChar) { Value =username },
                new SqlParameter("@Sifre", SqlDbType.NVarChar) { Value = password } };
            DataTable Kullanicilar = DB.MSSQLHelper.ExecuteQuery("Select * from kullanici where Isim=@Isim and sifre=@Sifre and Aktif='1'", SelectParameters);
            Kullanici kullanici = null;
            kullanici = new Kullanici(0, "", "", "", "", "", false);

            if (Kullanicilar.Rows.Count != 0)
            {
                DataRow row = Kullanicilar.Rows[0];

                kullanici.id = (int)row["ID"];
                kullanici.isim = row["Isim"].ToString();
                kullanici.telefon = row["Telefon"].ToString();
                kullanici.eposta = row["eposta"].ToString();
                kullanici.sifre = row["Sifre"].ToString();
                kullanici.kullanici_Tipi_ID = row["Kullanici_Tipi_ID"].ToString();
                kullanici.aktif = (bool)row["Aktif"];
            }
            return kullanici;
        }

    }
}