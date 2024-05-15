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
    internal class AdministratorImpl
    {
        private static string SELECT = "SELECT * FROM OSOBA O INNER JOIN ADMINISTRATOR A ON A.IDOsobe = O.IDOsobe";
        private static string DELETE_FROM_ADMINISTRATOR = "DELETE FROM ADMINISTRATOR WHERE IDOsobe = @IDOsobe";
        private static string DELETE_FROM_OSOBA = "DELETE FROM OSOBA WHERE IDOsobe = @IDOsobe";


        public static List<Administrator> getAdministratori()
        {
            List<Administrator> igraci = new List<Administrator>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraci.Add(new Administrator()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        KorisnickoIme = reader.GetString(5),
                        Lozinka = reader.GetString(6)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return igraci;
        }

        /*public static void insertAdministrator(string Ime, string Prezime, string Nacionalnost, string KorisnickoIme, int Lozinka)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("dodaj_igraca", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIme", Ime);
                    cmd.Parameters.AddWithValue("@pPrezime", Prezime);
                    cmd.Parameters.AddWithValue("@pNacionalnost", Nacionalnost);
                    cmd.Parameters.AddWithValue("@pKorisnickoIme", KorisnickoIme);
                    cmd.Parameters.AddWithValue("@pLozinka", Lozinka);

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

        //Dodati proceduru, ako se bude negdje koristilo!!!
        public static void updateAdministrator(int IDOsobe, string Ime, string Prezime, string Nacionalnost, string KorisnickoIme, int Lozinka)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand("update_igrac_info", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIDOsobe", IDOsobe);
                cmd.Parameters.AddWithValue("@NovoIme", Ime);
                cmd.Parameters.AddWithValue("NovoPrezime", Prezime);
                cmd.Parameters.AddWithValue("@NovaNacionalnost", Nacionalnost);
                cmd.Parameters.AddWithValue("NovoKorisnickoIme", KorisnickoIme);
                cmd.Parameters.AddWithValue("@NovaLozinka", Lozinka);

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

        public static void deleteAdministrator(int IDOsobe)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = DELETE_FROM_ADMINISTRATOR;
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
        }*/

        public static void print()
        {
            foreach(Administrator administrator in getAdministratori())
            {
                Console.WriteLine("Ime: " + administrator.IDOsobe.Ime);
                Console.WriteLine("Prezime: " + administrator.IDOsobe.Prezime);
                Console.WriteLine("Nacionalnost: " + administrator.IDOsobe.Nacionalnost);
                Console.WriteLine("Korisnicko ime: " + administrator.KorisnickoIme);
                Console.WriteLine("Lozinka: " + administrator.Lozinka);
            }
        }
    }
}
