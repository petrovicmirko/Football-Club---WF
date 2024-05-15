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
    internal class KorisnikImpl
    {
        private static string SELECT = "SELECT * FROM OSOBA O INNER JOIN KORISNIK K ON K.IDOsobe = O.IDOsobe";
        private static string DELETE_FROM_KORISNIK = "DELETE FROM KORISNIK WHERE IDOsobe = @IDOsobe";
        private static string DELETE_FROM_OSOBA = "DELETE FROM OSOBA WHERE IDOsobe = @IDOsobe";


        public static List<Korisnik> getKorisnici()
        {
            List<Korisnik> korisnici = new List<Korisnik>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    korisnici.Add(new Korisnik()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        KorisnickoIme = reader.GetString(5),
                        Lozinka = reader.GetString(6),
                        Uloga = reader.GetBoolean(7)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return korisnici;
        }

        public static void insertKorisnik(string Ime, string Prezime, string Nacionalnost, string KorisnickoIme, string Lozinka, bool Uloga, int Tema)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("dodaj_korisnika", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIme", Ime);
                    cmd.Parameters.AddWithValue("@pPrezime", Prezime);
                    cmd.Parameters.AddWithValue("@pNacionalnost", Nacionalnost);
                    cmd.Parameters.AddWithValue("@pKorisnickoIme", KorisnickoIme);
                    cmd.Parameters.AddWithValue("@pLozinka", Lozinka);
                    cmd.Parameters.AddWithValue("@pUloga", Uloga);
                    cmd.Parameters.AddWithValue("@pTema", Tema);

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

        public static void updateKorisnik(int IDKorisnika, string Ime, string Prezime, string KorisnickoIme)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand("update_korisnik_info", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIDOsobe", IDKorisnika);
                cmd.Parameters.AddWithValue("@NovoIme", Ime);
                cmd.Parameters.AddWithValue("NovoPrezime", Prezime);
                cmd.Parameters.AddWithValue("NovoKorisnickoIme", KorisnickoIme);

                cmd.ExecuteNonQuery();
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

        public static void deleteKorisnik(int IDOsobe)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = DELETE_FROM_KORISNIK;
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

        public static bool IsUsernameExists(string username)
        {
            bool exists = false;

            string query = "SELECT KorisnickoIme FROM KORISNIK WHERE KorisnickoIme = @Username";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Username", username);
                MySqlDataReader reader = cmd.ExecuteReader();

                exists = reader.HasRows;

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

            return exists;
        }
        public static int GetThemeForUsername(string username)
        {
            int theme = 1;

            string query = "SELECT Tema FROM KORISNIK WHERE KorisnickoIme = @Username";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Username", username);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    theme = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return theme;
        }

        public static void ChangeTheme(string username, int theme)
        {
            string query = "UPDATE KORISNIK SET Tema = @Tema WHERE KorisnickoIme = @KorisnickoIme";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@KorisnickoIme", username);
                cmd.Parameters.AddWithValue("@Tema", theme);

                cmd.ExecuteNonQuery();
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
    }
}
