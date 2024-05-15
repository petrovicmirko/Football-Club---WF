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
    internal class TrenerImpl
    {
        private static string SELECT = "SELECT * FROM OSOBA O INNER JOIN TRENER T ON T.IDOsobe = O.IDOsobe";
        private static string DELETE_FROM_TRENER = "DELETE FROM TRENER WHERE IDOsobe = @IDOsobe";
        private static string DELETE_FROM_OSOBA = "DELETE FROM OSOBA WHERE IDOsobe = @IDOsobe";

        public static List<Trener> getTreneri()
        {
            List<Trener> treneri = new List<Trener>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    treneri.Add(new Trener()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        Specijalizacija = reader.GetString(5),
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return treneri;
        }

        public static void insertTrener(string Ime, string Prezime, string Nacionalnost, string Specijalizacija)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("dodaj_trenera", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIme", Ime);
                    cmd.Parameters.AddWithValue("@pPrezime", Prezime);
                    cmd.Parameters.AddWithValue("@pNacionalnost", Nacionalnost);
                    cmd.Parameters.AddWithValue("@pSpecijalizacija", Specijalizacija);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void updateTrener(int IDOsobe, string Ime, string Prezime, string Nacionalnost, string Specijalizacija)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand("update_trener_info", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIDOsobe", IDOsobe);
                cmd.Parameters.AddWithValue("@NovoIme", Ime);
                cmd.Parameters.AddWithValue("NovoPrezime", Prezime);
                cmd.Parameters.AddWithValue("@NovaNacionalnost", Nacionalnost);
                cmd.Parameters.AddWithValue("NovaSpecijalizacija", Specijalizacija);

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

        public static void deleteTrener(int IDOsobe)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = DELETE_FROM_TRENER;
                    cmd1.Parameters.AddWithValue("@IDOsobe", IDOsobe);
                    cmd1.ExecuteNonQuery();

                    MySqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = DELETE_FROM_OSOBA;
                    cmd2.Parameters.AddWithValue("@IDOsobe", IDOsobe);
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void print()
        {
            foreach (Trener trener in getTreneri())
            {
                Console.WriteLine("Ime: " + trener.IDOsobe.Ime);
                Console.WriteLine("Prezime: " + trener.IDOsobe.Prezime);
                Console.WriteLine("Nacionalnost: " + trener.IDOsobe.Nacionalnost);
                Console.WriteLine("Specijalizacija: " + trener.Specijalizacija);
            }
        }
    }
}
