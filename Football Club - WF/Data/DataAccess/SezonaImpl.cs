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
    internal class SezonaImpl
    {
        public static string SELECT = "SELECT * FROM SEZONA ORDER BY NazivSezone ASC";
        public static string INSERT = "INSERT INTO SEZONA (NazivSezone) values (@NazivSezone)";
        public static string UPDATE = "UPDATE SEZONA SET NazivSezone = @NazivSezone WHERE IDSezone = @IDSezone";
        public static string DELETE = "DELETE FROM SEZONA WHERE IDSezone = @IDSezone";

        public static List<Sezona> getSezone()
        {
            List<Sezona> sezone = new List<Sezona>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sezone.Add(new Sezona()
                    {
                        IDSezone = reader.GetInt32(0),
                        NazivSezone = reader.GetString(1)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return sezone;
        }

        public static void insertSezona(string NazivSezone)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@NazivSezone", NazivSezone);

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

        public static void updateSezona(int IDSezone, string NazivSezone)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDSezone", IDSezone);
                cmd.Parameters.AddWithValue("@NazivSezone", NazivSezone);

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

        public static void deleteSezona(int IDSezone)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
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

        /*public void print()
        {
            foreach (Sezona sezona in getSezone())
            {
                Console.WriteLine("IDSezone: " + sezona.IDSezone);
                Console.WriteLine("NazivSezone: " + sezona.NazivSezone);
            }
        }*/
    }
}
