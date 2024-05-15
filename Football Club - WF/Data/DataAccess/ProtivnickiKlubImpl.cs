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
    internal class ProtivnickiKlubImpl
    {
        public static string SELECT = "SELECT * FROM PROTIVNICKI_KLUB";
        public static string INSERT = "INSERT INTO PROTIVNICKI_KLUB (NazivProtivnickogKluba, Mjesto) values (@NazivProtivnickogKluba, @Mjesto)";
        public static string UPDATE = "UPDATE PROTIVNICKI_KLUB SET NazivProtivnickogKluba = @NazivProtivnickogKluba, Mjesto = @Mjesto WHERE IDProtivnickogKluba = @IDProtivnickogKluba";
        public static string DELETE = "DELETE FROM PROTIVNICKI_KLUB WHERE IDProtivnickogKluba = @IDProtivnickogKluba";


        public static List<ProtivnickiKlub> getProtivnickiKlubovi()
        {
            List<ProtivnickiKlub> protivnickiKlubovi = new List<ProtivnickiKlub>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    protivnickiKlubovi.Add(new ProtivnickiKlub()
                    {
                        IDProtivnickogKluba = reader.GetInt32(0),
                        NazivProtivnickogKluba = reader.GetString(1),
                        Mjesto = reader.GetString(2)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return protivnickiKlubovi;
        }

        public static void insertProtivnickiKlub(string NazivProtivnickogKluba, string Mjesto)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@NazivProtivnickogKluba", NazivProtivnickogKluba);
                cmd.Parameters.AddWithValue("@Mjesto", Mjesto);

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

        public static void updateProtivnickiKlub(int IDProtivnickogKluba, string NazivProtivnickogKluba, string Mjesto)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDProtivnickogKluba", IDProtivnickogKluba);
                cmd.Parameters.AddWithValue("@NazivProtivnickogKluba", NazivProtivnickogKluba);
                cmd.Parameters.AddWithValue("@Mjesto", Mjesto);

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

        public static void deleteProtivnickiKlub(int IDProtivnickogKluba)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IDProtivnickogKluba", IDProtivnickogKluba);
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
            foreach (ProtivnickiKlub protivnickiKlub in getProtivnickiKlubovi())
            {
                Console.WriteLine("IDProtivnickogKluba: " + protivnickiKlub.IDProtivnickogKluba);
                Console.WriteLine("NazivProtivnickogKluba: " + protivnickiKlub.NazivProtivnickogKluba);
                Console.WriteLine("Mjesto: " + protivnickiKlub.Mjesto);
            }
        }*/
    }
}
