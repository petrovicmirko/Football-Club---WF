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
    internal class UtakmicaImpl
    {
        public static string SELECT = "SELECT * FROM UTAKMICA";
        public static string INSERT = "INSERT INTO UTAKMICA (DatumVrijeme, Domacin, BrojDatihGolova, BrojPrimljenihGolova, FazaKolo, StatusUtakmice, IDProtivnickogKluba, IDTakmicenja, IDSezone) VALUES (@DatumVrijeme, @Domacin, @BrojDatihGolova, @BrojPrimljenihGolova, @FazaKolo, @StatusUtakmice, @IDProtivnickogKluba, @IDTakmicenja, @IDSezone)";
        public static string UPDATE = "UPDATE UTAKMICA SET DatumVrijeme = @DatumVrijeme, Domacin = @Domacin, BrojDatihGolova = @BrojDatihGolova, BrojPrimljenihGolova = @BrojPrimljenihGolova, FazaKolo = @FazaKolo, StatusUtakmice = @StatusUtakmice, IDProtivnickogKluba = @IDProtivnickogKluba, IDTakmicenja = @IDTakmicenja, IDSezone = @IDSezone WHERE IDUtakmice = @IDUtakmice";
        public static string DELETE = "DELETE FROM UTAKMICA WHERE IDUtakmice = @IDUtakmice";
        public static string UPDATE_RESULT = "UPDATE UTAKMICA SET BrojDatihGolova = @BrojDatihGolova, BrojPrimljenihGolova = @BrojPrimljenihGolova, StatusUtakmice = @StatusUtakmice WHERE IDUtakmice = @IDUtakmice";

        public static List<Utakmica> getUtakmice()
        {
            List<Utakmica> utakmice = new List<Utakmica>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    utakmice.Add(new Utakmica()
                    {
                        IDUtakmice = reader.GetInt32(0),
                        DatumVrijeme = reader.GetDateTime(1),
                        Domacin = reader.GetBoolean(2),
                        BrojDatihGolova = reader.GetInt32(3),
                        BrojPrimljenihGolova = reader.GetInt32(4),
                        FazaKolo = reader.GetString(5),
                        StatusUtakmice = reader.GetBoolean(6),
                        IDProtivnickogKluba = reader.GetInt32(7),
                        IDTakmicenja = reader.GetInt32(8),
                        IDSezone = reader.GetInt32(9)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return utakmice;
        }

        public static void insertUtakmica(DateTime DatumVrijeme, bool Domacin, int BrojDatihGolova, int BrojPrimljenihGolova, string FazaKolo, bool StatusUtakmice, int IDProtivnickogKluba, int IDTakmicenja, int IDSezone)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@DatumVrijeme", DatumVrijeme);
                cmd.Parameters.AddWithValue("@Domacin", Domacin);
                cmd.Parameters.AddWithValue("@BrojDatihGolova", BrojDatihGolova);
                cmd.Parameters.AddWithValue("@BrojPrimljenihGolova", BrojPrimljenihGolova);
                cmd.Parameters.AddWithValue("@FazaKolo", FazaKolo);
                cmd.Parameters.AddWithValue("@StatusUtakmice", StatusUtakmice);
                cmd.Parameters.AddWithValue("@IDProtivnickogKluba", IDProtivnickogKluba);
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
                cmd.Parameters.AddWithValue("@IDSezone", IDSezone);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
            }
        }

        public static void updateUtakmica(int IDUtakmice, DateTime DatumVrijeme, bool Domacin, int BrojDatihGolova, int BrojPrimljenihGolova, string FazaKolo, bool StatusUtakmice, int IDProtivnickogKluba, int IDTakmicenja, int IDSezone)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);
                cmd.Parameters.AddWithValue("@DatumVrijeme", DatumVrijeme);
                cmd.Parameters.AddWithValue("@Domacin", Domacin);
                cmd.Parameters.AddWithValue("@BrojDatihGolova", BrojDatihGolova);
                cmd.Parameters.AddWithValue("@BrojPrimljenihGolova", BrojPrimljenihGolova);
                cmd.Parameters.AddWithValue("@FazaKolo", FazaKolo);
                cmd.Parameters.AddWithValue("@StatusUtakmice", StatusUtakmice);
                cmd.Parameters.AddWithValue("@IDProtivnickogKluba", IDProtivnickogKluba);
                cmd.Parameters.AddWithValue("@IDTakmicenja", IDTakmicenja);
                cmd.Parameters.AddWithValue("@IDSezone", IDSezone);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
            }
        }

        public static void deleteUtakmica(int IDUtakmice)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);
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

        public static void changeResult(int IDUtakmice, int BrojDatihGolova, int BrojPrimljenihGolova, bool StatusUtakmice)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_RESULT;
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);
                cmd.Parameters.AddWithValue("@BrojDatihGolova", BrojDatihGolova);
                cmd.Parameters.AddWithValue("@BrojPrimljenihGolova", BrojPrimljenihGolova);
                cmd.Parameters.AddWithValue("@StatusUtakmice", StatusUtakmice);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool isConfirmed(int IDUtakmice)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT StatusUtakmice FROM UTAKMICA WHERE IDUtakmice = @IDUtakmice";
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string confirmed = reader["StatusUtakmice"].ToString();

                        if(confirmed.Equals("1"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        reader.Close();

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
