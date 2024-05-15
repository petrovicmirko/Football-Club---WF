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
    internal class IgracNaUtakmiciImpl
    {
        private static string SELECT = "SELECT * FROM I_NA_UT O INNER JOIN IGRAC I ON I.IDOsobe = O.IDOsobe";
        private static string INSERT = "INSERT INTO I_NA_UT (IDOsobe, IDUtakmice, UProtokolu, MinutaUIgri, Golovi, Asistencije, ZutiKarton, CrveniKarton) values (@IDOsobe, @IDUtakmice, @UProtokolu, @MinutaUIgri, @Golovi, @Asistencije, @ZutiKarton, @CrveniKarton)";
        private static string UPDATE = "UPDATE I_NA_UT SET UProtokolu = @UProtokolu, MinutaUIgri = @MinutaUIgri, Golovi = @Golovi, Asistencije = @Asistencije, ZutiKarton = @ZutiKarton, CrveniKarton = @CrveniKarton WHERE IDIgraca = @IDIgraca AND IDUtakmice = @IDUtakmice";
        private static string DELETE = "DELETE FROM I_NA_UT WHERE IDUtakmice = @IDUtakmice";

        public static List<IgracNaUtakmici> getIgraciNaUtakmici()
        {
            List<IgracNaUtakmici> igraciNaUtakmici = new List<IgracNaUtakmici>();

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    igraciNaUtakmici.Add(new IgracNaUtakmici()
                    {
                        IDOsobe = new Osoba()
                        {
                            IDOsobe = reader.GetInt32(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Nacionalnost = reader.GetString(3),
                        },
                        UProtokolu = reader.GetBoolean(5),
                        MinutaUIgri = reader.GetInt32(6),
                        Golovi = reader.GetInt32(7),
                        Asistencije = reader.GetInt32(8),
                        ZutiKarton = reader.GetInt32(9),
                        CrveniKarton = reader.GetInt32(10)
                    });
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return igraciNaUtakmici;
        }

        public static void insertIgracNaUtakmici(int IDIgraca, int IDUtakmice, bool UProtokolu, int MinutaUIgri, int Golovi, int Asistencije, int ZutiKarton, int CrveniKarton)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@IDOsobe", IDIgraca);
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);
                cmd.Parameters.AddWithValue("@UProtokolu", UProtokolu);
                cmd.Parameters.AddWithValue("@MinutaUIgri", MinutaUIgri);
                cmd.Parameters.AddWithValue("@Golovi", Golovi);
                cmd.Parameters.AddWithValue("@Asistencije", Asistencije);
                cmd.Parameters.AddWithValue("@ZutiKarton", ZutiKarton);
                cmd.Parameters.AddWithValue("@CrveniKarton", CrveniKarton);

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

        public static void updateIgracNaUtakmici(int IDIgraca, int IDUtakmice, bool UProtokolu, int MinutaUIgri, int Golovi, int Asistencije, int ZutiKarton, int CrveniKarton)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IDOsobe", IDIgraca);
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);
                cmd.Parameters.AddWithValue("@UProtokolu", UProtokolu);
                cmd.Parameters.AddWithValue("@MinutaUIgri", MinutaUIgri);
                cmd.Parameters.AddWithValue("@Golovi", Golovi);
                cmd.Parameters.AddWithValue("@Asistencije", Asistencije);
                cmd.Parameters.AddWithValue("@ZutiKarton", ZutiKarton);
                cmd.Parameters.AddWithValue("@CrveniKarton", CrveniKarton);

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

        public static void deleteIgraciNaUtakmici(int IDUtakmice)
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
    }
}
