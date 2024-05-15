using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Football_Club___WF.Util;
using Football_Club___WF.Data.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Club___WF.Data.DataAccess
{
    internal class TakmicenjeSezonaImpl
    {
        public static string SELECT = "SELECT * FROM TAKMICENJE_SEZONA";
        public static string INSERT = "INSERT INTO TAKMICENJE_SEZONA (IDTakmicenja, IDSezone, Uspjeh) values (@IDTakmicenja, @IDSezone, @Uspjeh)";
        public static string UPDATE = "UPDATE TAKMICENJE_SEZONA SET Uspjeh = @Uspjeh WHERE IDTakmicenja = @IDTakmicenja AND IDSezone = @IDSezone";
        public static string DELETE = "DELETE FROM TAKMICENJE_SEZONA WHERE IDTakmicenja = @IDTakmicenja AND IDSezone = @IDSezone";

        public List<TakmicenjeSezona> getTakmicenjeSezona()
        {
            List<TakmicenjeSezona> takmicenjeSezone = new List<TakmicenjeSezona>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    takmicenjeSezone.Add(new TakmicenjeSezona()
                    {
                        IDTakmicenja = reader.GetInt32(0),
                        IDSezone = reader.GetInt32(1),
                        Uspjeh = reader.GetString(2)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return takmicenjeSezone;
        }

        public static void insertTakmicenjeSezona(int IDTakmicenja, int IDSezone, String Uspjeh)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
                cmd.Parameters.AddWithValue("@IDSezone", IDSezone);
                cmd.Parameters.AddWithValue("@Uspjeh", Uspjeh);

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

        public static void updateTakmicenjeSezona(int IDTakmicenja, int IDSezone, string Uspjeh)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
                cmd.Parameters.AddWithValue("@IDSezone", IDSezone);
                cmd.Parameters.AddWithValue("@Uspjeh", Uspjeh);

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

        public static void deleteTakmicenjeSezona(int IDTakmicenja, int IDSezone)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
                cmd.Parameters.AddWithValue("@IDSezone", IDSezone);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void print()
        {
            foreach (TakmicenjeSezona takmicenjeSezona in getTakmicenjeSezona())
            {
                Console.WriteLine("IDTakmicenja: " + takmicenjeSezona.IDTakmicenja);
                Console.WriteLine("IDSezone: " + takmicenjeSezona.IDSezone);
                Console.WriteLine("Uspjeh: " + takmicenjeSezona.Uspjeh);
            }
        }
    }
}
