using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Football_Club___WF.Data.DTO;
using Football_Club___WF.Util;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Club___WF.Data.DataAccess
{
    internal class OsobaImpl
    {
        private static string SELECT = "SELECT * FROM OSOBA";
        private static string INSERT = "INSERT INTO OSOBA (Ime, Prezime, Nacionalnost) values (@Ime, @Prezime, @Nacionalnost)";

        public List<Osoba> getOsobe()
        {
            List<Osoba> osobe = new List<Osoba>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    osobe.Add(new Osoba()
                    {
                        IDOsobe = reader.GetInt32(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                        Nacionalnost = reader.GetString(3)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return osobe;
        }

        public static void insertOsoba(string Ime, string Prezime, string Nacionalnost)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@Ime", Ime);
                cmd.Parameters.AddWithValue("@Prezime", Prezime);
                cmd.Parameters.AddWithValue("@Nacionalnost", Nacionalnost);

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

        public void print()
        {
            foreach (Osoba osoba in getOsobe())
            {
                Console.WriteLine("IDOsobe: " + osoba.IDOsobe);
                Console.WriteLine("Ime: " + osoba.Ime);
                Console.WriteLine("Prezime: " + osoba.Prezime);
                Console.WriteLine("Nacionalnost: " + osoba.Nacionalnost);
            }
        }
    }
}
