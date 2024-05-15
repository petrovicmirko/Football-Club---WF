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
    internal class TakmicenjeImpl
    {
        public static string SELECT = "SELECT * FROM TAKMICENJE";
        public static string INSERT = "INSERT INTO TAKMICENJE (NazivTakmicenja) values (@NazivTakmicenja)";
        public static string UPDATE = "UPDATE TAKMICENJE SET NazivTakmicenja = @NazivTakmicenja WHERE IDTakmicenja = @IDTakmicenja";
        public static string DELETE = "DELETE FROM TAKMICENJE WHERE IDTakmicenja = @IDTakmicenja";

        public static List<Takmicenje> getTakmicenja()
        {
            List<Takmicenje> takmicenja = new List<Takmicenje>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    takmicenja.Add(new Takmicenje()
                    {
                        IDTakmicenja = reader.GetInt32(0),
                        NazivTakmicenja = reader.GetString(1)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return takmicenja;
        }

        public static void insertTakmicenje(string NazivTakmicenja)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@NazivTakmicenja", NazivTakmicenja);

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

        public static void updateTakmicenje(int IDTakmicenja, string NazivTakmicenja)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
                cmd.Parameters.AddWithValue("@NazivTakmicenja", NazivTakmicenja);

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

        public static void deleteTakmicenje(int IDTakmicenja)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
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

        /*public void print()
        {
            foreach (Takmicenje takmicenje in getTakmicenja())
            {
                Console.WriteLine("IDTakmicenja: " + takmicenje.IDTakmicenja);
                Console.WriteLine("NazivTakmicenja: " + takmicenje.NazivTakmicenja);
            }
        }*/
    }
}
