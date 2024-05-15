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
    internal class IgracImpl
    {
        private static string SELECT = "SELECT * FROM OSOBA O INNER JOIN IGRAC I ON I.IDOsobe = O.IDOsobe";
        private static string DELETE_FROM_IGRAC = "DELETE FROM IGRAC WHERE IDOsobe = @IDOsobe";
        private static string DELETE_FROM_OSOBA = "DELETE FROM OSOBA WHERE IDOsobe = @IDOsobe";
        private static string DELETE_FROM_I_NA_UT = "DELETE FROM I_NA_UT WHERE IDOsobe = @IDOsobe";


        public static List<Igrac> getIgraci()
        {
            List<Igrac> igraci = new List<Igrac>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraci.Add(new Igrac()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        Pozicija = reader.GetString(5),
                        BrojDresa = reader.GetInt32(6)
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

        public static void insertIgrac(string Ime, string Prezime, string Nacionalnost, string Pozicija, int BrojDresa)
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
                    cmd.Parameters.AddWithValue("@pPozicija", Pozicija);
                    cmd.Parameters.AddWithValue("@pBrojDresa", BrojDresa);

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

        public static void updateIgrac(int IDOsobe, string Ime, string Prezime, string Nacionalnost, string Pozicija, int BrojDresa)
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
                cmd.Parameters.AddWithValue("NovaPozicija", Pozicija);
                cmd.Parameters.AddWithValue("@NoviBrojDresa", BrojDresa);

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

        public static void deleteIgrac(int IDOsobe)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            using (MySqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = DELETE_FROM_I_NA_UT;
                    cmd1.Parameters.AddWithValue("@IDOsobe", IDOsobe);
                    cmd1.ExecuteNonQuery();

                    MySqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = DELETE_FROM_IGRAC;
                    cmd2.Parameters.AddWithValue("@IDOsobe", IDOsobe);
                    cmd2.ExecuteNonQuery();

                    MySqlCommand cmd3 = conn.CreateCommand();
                    cmd3.CommandText = DELETE_FROM_OSOBA;
                    cmd3.Parameters.AddWithValue("@IDOsobe", IDOsobe);
                    cmd3.ExecuteNonQuery();

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

        public static List<Igrac> getGoalkeepers()
        {
            string SELECT = "SELECT * FROM OSOBA o JOIN IGRAC i ON o.IDOsobe = i.IDOsobe WHERE i.Pozicija = 'golman'";

            List<Igrac> igraci = new List<Igrac>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraci.Add(new Igrac()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        Pozicija = reader.GetString(5),
                        BrojDresa = reader.GetInt32(6)
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

        public static List<Igrac> getDefenders()
        {
            string SELECT = "SELECT * FROM OSOBA o JOIN IGRAC i ON o.IDOsobe = i.IDOsobe WHERE i.Pozicija = 'odbrana'";

            List<Igrac> igraci = new List<Igrac>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraci.Add(new Igrac()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        Pozicija = reader.GetString(5),
                        BrojDresa = reader.GetInt32(6)
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

        public static List<Igrac> getMidfielders()
        {
            string SELECT = "SELECT * FROM OSOBA o JOIN IGRAC i ON o.IDOsobe = i.IDOsobe WHERE i.Pozicija = 'vezni'";

            List<Igrac> igraci = new List<Igrac>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraci.Add(new Igrac()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        Pozicija = reader.GetString(5),
                        BrojDresa = reader.GetInt32(6)
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

        public static List<Igrac> getAttackers()
        {
            string SELECT = "SELECT * FROM OSOBA o JOIN IGRAC i ON o.IDOsobe = i.IDOsobe WHERE i.Pozicija = 'napad'";

            List<Igrac> igraci = new List<Igrac>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraci.Add(new Igrac()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        Pozicija = reader.GetString(5),
                        BrojDresa = reader.GetInt32(6)
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
    }
}
