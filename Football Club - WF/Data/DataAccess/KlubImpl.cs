using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Football_Club___WF.Util;
using Football_Club___WF.Data.DTO;

namespace Football_Club___WF.Data.DataAccess
{
    internal class KlubImpl
    {
        public static string SELECT = "SELECT * FROM KLUB";
        public static string UPDATE = "UPDATE KLUB SET NazivKluba = @NazivKluba, DatumOsnivanja = @DatumOsnivanja, Grad = @Grad, Stadion = @Stadion WHERE IDKluba = @IDKluba";

        public static Klub getKlub()
        {
            Klub klub = new Klub();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    klub.IDKluba = reader.GetInt32(0);
                    klub.NazivKluba = reader.GetString(1);
                    klub.DatumOsnivanja = reader.GetDateTime(2);
                    klub.Grad = reader.GetString(3);
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return klub;
        }

        public static void updateKlub(int IDKluba, string NazivKluba, DateTime DatumOsnivanja, string Grad, string Stadion)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDKluba", IDKluba);
                cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
                cmd.Parameters.AddWithValue("@DatumOsnivanja", DatumOsnivanja);
                cmd.Parameters.AddWithValue("@Grad", Grad);
                cmd.Parameters.AddWithValue("@Stadion", Stadion);


                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
