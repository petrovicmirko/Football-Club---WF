using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Football_Club___WF.Data.DataAccess;
using Football_Club___WF.Util;
using System.Globalization;

namespace Football_Club___WF.Forms
{
    public partial class Game : Form
    {
        private string USERNAME;

        private string LANGUAGE;

        private Color BACK_COLOR;
        private Color BUTTON_COLOR;

        private int selectedIDUtakmice;
        private int selectedIDIgraca;

        private int goalsScored;
        private int goalsConceded;
        private int goalsScoredPlayer;

        private string opponent = "";
        private string homeOrAway = "";

        private string club;

        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public Game()
        {
            InitializeComponent();
        }
        
        public Game(int IDUtakmice, string opponent, string result, string homeOrAway, bool isConfirmed, string username, string language)
        {
            USERNAME = username;

            LANGUAGE = language;

            InitializeComponent();

            SetLanguage(language);

            this.opponent = opponent;
            this.homeOrAway = homeOrAway;

            selectedIDUtakmice = IDUtakmice;

            ChangeControlColors(this.Controls);

            string[] goals = result.Split('-');

            string hostGoals = goals[0].Trim();
            string guestGoals = goals[1].Trim();
            
            lbHostGoals.Text = hostGoals;
            lbGuestGoals.Text = guestGoals;

            club = KlubImpl.getKlub().NazivKluba;

            if (homeOrAway.Equals("Domaćin"))
            {
                lbHost.Text = club;
                lbGuest.Text = opponent;
                this.Name = $"{club} - {opponent} ({result})";
                this.Text = $"{club} - {opponent} ({result})";
            }
            else
            {
                lbHost.Text = opponent;
                lbGuest.Text = club;
                this.Name = $"{opponent} - {club} ({result})";
                this.Text = $"{opponent} - {club} ({result})";
            }

            if(isConfirmed)
            {
                GamePanel.Visible = true;
                AddResultPanel.Visible = false;
            }
            else
            {
                GamePanel.Visible = true;
                AddResultPanel.Visible = true;
                AddPlayerOnMatchPanel.Visible = false;

                if (homeOrAway.Equals("Domaćin"))
                {
                    this.Text = $"{club} - {opponent} ( - )";
                }
                else
                {
                    this.Text = $"{opponent} - {club} ( - )";
                }
            }

            FillGridPlayersOnMatch(IDUtakmice);
        }

        private void tbGoalsScored_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbGoalsConceded_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bPotvrdiResult_Click(object sender, EventArgs e)
        {
            if(tbGoalsScored.Text.Equals("") || tbGoalsConceded.Text.Equals(""))
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate unijeti rezultat utakmice!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You must enter the match result!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                goalsScored = Convert.ToInt32(tbGoalsScored.Text);
                goalsConceded = Convert.ToInt32(tbGoalsConceded.Text);

                LoadPlayer();

                AddPlayerOnMatchPanel.Visible = true;
            }
        }

        private void LoadPlayer()
        {
            string SELECT = "SELECT O.IDOsobe, Ime, Prezime FROM OSOBA O INNER JOIN IGRAC I ON I.IDOsobe = O.IDOsobe";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DisplayPlayerData();
                }
                else
                {
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Nema više igrača u bazi podataka.");
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("There are no more players in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DisplayPlayerData()
        {
            selectedIDIgraca = reader.GetInt32(0);
            string Ime = reader.GetString(1);
            string Prezime = reader.GetString(2);

            lbPlayer.Text = Ime + " " + Prezime;
            
            bPotvrdiPlayerOnMatch.Enabled = true;
        }

        private void bBackPlayerOnMatch_Click(object sender, EventArgs e)
        {
            AddPlayerOnMatchPanel.Visible = false;

            cbPlayed.Checked = true;
            tbMinutesPlayed.Text = "";
            tbYellowCard.Text = "";
            tbRedCard.Text = "";
            tbGoal.Text = "";
            tbAssist.Text = "";

            IgracNaUtakmiciImpl.deleteIgraciNaUtakmici(selectedIDUtakmice);
        }

        private void bPotvrdiPlayerOnMatch_Click(object sender, EventArgs e)
        {
            if (!tbMinutesPlayed.Text.Equals("") && !tbGoal.Text.Equals("") && !tbAssist.Text.Equals("") && !tbYellowCard.Text.Equals("") && !tbRedCard.Text.Equals(""))
            {
                int minutesPlayed = Convert.ToInt32(tbMinutesPlayed.Text);
                int goals = Convert.ToInt32(tbGoal.Text);
                int assists = Convert.ToInt32(tbAssist.Text);
                int yellowCard = Convert.ToInt32(tbYellowCard.Text);
                int redCard = Convert.ToInt32(tbRedCard.Text);

                IgracNaUtakmiciImpl.insertIgracNaUtakmici(selectedIDIgraca, selectedIDUtakmice, cbPlayed.Checked, minutesPlayed, goals, assists, yellowCard, redCard);

                try
                {
                    if (reader.Read())
                    {
                        DisplayPlayerData();
                        cbPlayed.Checked = true;

                        tbMinutesPlayed.Text = "";
                        tbYellowCard.Text = "";
                        tbRedCard.Text = "";
                        tbGoal.Text = "";
                        tbAssist.Text = "";

                        goalsScoredPlayer = 0;
                    }
                    else
                    {
                        if (LANGUAGE.Equals("sr-Latn"))
                        {
                            MessageBox.Show("Unijeli ste podatke za sve igrače.");
                        }
                        else if (LANGUAGE.Equals("en"))
                        {
                            MessageBox.Show("You have entered data for all players.");
                        }

                        bPotvrdiPlayerOnMatch.Enabled = false;
                        UtakmicaImpl.changeResult(selectedIDUtakmice, goalsScored, goalsConceded, true);
                        AddPlayerOnMatchPanel.Visible = false;
                        AddResultPanel.Visible = false;

                        if (homeOrAway.Equals("Domaćin"))
                        {
                            lbHostGoals.Text = tbGoalsScored.Text;
                            lbGuestGoals.Text = tbGoalsConceded.Text;

                            lbHost.Text = club;
                            lbGuest.Text = opponent;
                            this.Name = $"{club} - {opponent} ({tbGoalsScored.Text} - {tbGoalsConceded.Text})";
                            this.Text = $"{club} - {opponent} ({tbGoalsScored.Text} - {tbGoalsConceded.Text})";
                        }
                        else
                        {
                            lbHostGoals.Text = tbGoalsConceded.Text;
                            lbGuestGoals.Text = tbGoalsScored.Text;

                            lbHost.Text = opponent;
                            lbGuest.Text = club;
                            this.Name = $"{opponent} - {club} ({tbGoalsConceded.Text} - {tbGoalsScored.Text})";
                            this.Text = $"{opponent} - {club} ({tbGoalsConceded.Text} - {tbGoalsScored.Text})";
                        }
                        FillGridPlayersOnMatch(selectedIDUtakmice);
                    }
                }
                catch (Exception ex)
                {
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Greška prilikom čitanja iz baze podataka: " + ex.Message);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("Error reading from database: " + ex.Message);
                    }
                }
            }
            else
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate popuniti sva polja!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("All fields must be filled!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbPlayed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPlayed.Checked)
            {
                tbMinutesPlayed.Text = "";
                tbYellowCard.Text = "";
                tbRedCard.Text = "";
                tbAssist.Text = "";
                tbGoal.Text = "";

                tbMinutesPlayed.Enabled = true;
                tbYellowCard.Enabled = true;
                tbRedCard.Enabled = true;
                tbAssist.Enabled = true;
                tbGoal.Enabled = true;
            }
            else
            {
                tbMinutesPlayed.Text = "0";
                tbYellowCard.Text = "0";
                tbRedCard.Text = "0";
                tbAssist.Text = "0";
                tbGoal.Text = "0";

                tbMinutesPlayed.Enabled = false;
                tbYellowCard.Enabled = false;
                tbRedCard.Enabled = false;
                tbAssist.Enabled = false;
                tbGoal.Enabled = false;
            }
        }

        private void tbMinutesPlayed_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 3 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbYellowCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 1 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbRedCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 1 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbGoal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbAssist_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0' && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }

            if (textBox != null && textBox.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbMinutesPlayed_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(tbMinutesPlayed.Text, out int value))
            {
                if (value > 120)
                {
                    tbMinutesPlayed.Text = "";
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Minutaža mora biti najviše 120 minuta!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("The minutes played must be a maximum of 120 minutes!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    tbMinutesPlayed.Focus();
                }
            }
        }


        private void tbYellowCard_Leave(object sender, EventArgs e)
        {
            if(int.TryParse(tbYellowCard.Text, out int value))
            {
                if (value > 2)
                {
                    tbYellowCard.Text = "";
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Igrač najviše može dobiti dva žuta kartona!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("A player can receive a maximum of two yellow cards!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    tbYellowCard.Focus();
                }
            }
        }

        private void tbRedCard_Leave(object sender, EventArgs e)
        {
            if(int.TryParse(tbRedCard.Text, out int value))
            {
                if (value > 1)
                {
                    tbRedCard.Text = "";
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Igrač može dobiti samo jedan crveni karton!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("A player can only receive one red card!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    tbRedCard.Focus();
                }
            }
        }

        private void tbGoal_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(tbGoal.Text, out goalsScoredPlayer))
            {
                if (goalsScoredPlayer > goalsScored)
                {
                    tbGoal.Text = "";
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Broj postignutnih golova mora biti manji!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("The number of goals must be less!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    tbGoal.Focus();
                }
            }
        }

        private void tbAssist_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(tbAssist.Text, out int assists))
            {
                if (assists > (goalsScored - goalsScoredPlayer))
                {
                    tbAssist.Text = "";
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Broj asistencija mora biti manji!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("The number of assists must be less!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    tbAssist.Focus();
                }
            }
        }

        private void FillGridPlayersOnMatch(int IDUtakmice)
        {
            string SELECT = "SELECT * FROM igrac_na_utakmici_info WHERE IDUtakmice = @IDUtakmice";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                string player;
                string played;

                dgvPlayersOnMatch.Rows.Clear();

                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                cmd.Parameters.AddWithValue("@IDUtakmice", IDUtakmice);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    player = reader.GetString(2) + " " + reader.GetString(3);
                    if(reader.GetBoolean(4))
                    {
                        played = "Da";
                    }
                    else
                    {
                        played = "Ne";
                    }

                    row.CreateCells(dgvPlayersOnMatch, reader.GetInt32(0), reader.GetInt32(1), player, played, reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
                    dgvPlayersOnMatch.Rows.Add(row);
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
        }

        private void ChangeControlColors(Control.ControlCollection controls)
        {
            if (KorisnikImpl.GetThemeForUsername(USERNAME) == 1)
            {
                BACK_COLOR = ColorTranslator.FromHtml("#32CD32");
                BUTTON_COLOR = ColorTranslator.FromHtml("#98FB98");
            }
            else if (KorisnikImpl.GetThemeForUsername(USERNAME) == 2)
            {
                BACK_COLOR = ColorTranslator.FromHtml("#6984BF");
                BUTTON_COLOR = ColorTranslator.FromHtml("#87CEEB");
            }
            else if (KorisnikImpl.GetThemeForUsername(USERNAME) == 3)
            {
                BACK_COLOR = ColorTranslator.FromHtml("#B32E2E");
                BUTTON_COLOR = ColorTranslator.FromHtml("#F08080");
            }

            foreach (Control control in controls)
            {
                if (control is Panel)
                {
                    control.BackColor = BACK_COLOR;
                }
                else if (control is DataGridView)
                {
                    DataGridView dataGridView = (DataGridView)control;
                    dataGridView.BackgroundColor = BACK_COLOR;
                }
                else if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = BUTTON_COLOR;
                }
                else if(control is CheckBox)
                {
                    control.BackColor = BACK_COLOR;
                }

                if (control.HasChildren)
                {
                    ChangeControlColors(control.Controls);
                }
            }
        }

        private void SetLanguage(string lang)
        {
            LANGUAGE = lang;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(Game));
            resources.ApplyResources(this, "$this");
            ApplyResourceToControls(this.Controls, resources);
        }

        private void ApplyResourceToControls(Control.ControlCollection controls, ComponentResourceManager resources)
        {
            foreach (Control control in controls)
            {
                if (control is DataGridView dataGridView)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        column.HeaderText = resources.GetString(column.Name);
                    }
                }
                else
                {
                    resources.ApplyResources(control, control.Name);
                    if (control.Controls.Count > 0)
                    {
                        ApplyResourceToControls(control.Controls, resources);
                    }
                }
            }
        }

        private void dgvPlayersOnMatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPlayersOnMatch.Rows[e.RowIndex].Selected = true;
            }
        }

        private void Game_Shown(object sender, EventArgs e)
        {
            dgvPlayersOnMatch.ClearSelection();
        }
    }
}
