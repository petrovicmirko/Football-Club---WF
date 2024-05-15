using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Football_Club___WF.Data.DataAccess;
using Football_Club___WF.Data.DTO;
using Football_Club___WF.Util;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Football_Club___WF.Forms
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        public AdminPage(string username)
        {
            USERNAME = username;
            LANGUAGE = "sr-Latn";

            InitializeComponent();

            ChangeControlColors(this.Controls);

            AdminPagePanel.Visible = true;
            PlayersPanel.Visible = false;
            CoachesPanel.Visible = false;
            MatchesPanel.Visible = false;
            StatisticsPanel.Visible = false;
            AboutClubPanel.Visible = false;
            UsersPanel.Visible = false;

            SetLanguage("sr-Latn");
        }

        private string USERNAME;

        private string LANGUAGE;

        private Color BACK_COLOR;
        private Color BUTTON_COLOR;

        public string selectedPlayersID;
        public string selectedCoachID;
        public string selectedUsersID;

        public int selectedIDProtivnickogKluba;
        public int selectedIDTakmicenja;
        public int selectedIDSezone;

        public string selectedSeason;
        public string selectedCompetitionStatistics;

        public int currentSeason = 9;

        public string club;


        private void bLogout_Click(object sender, EventArgs e)
        {
            if(LANGUAGE.Equals("sr-Latn"))
            {
                DialogResult result = MessageBox.Show("Da li se stvarno želite odjaviti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SetLanguage("sr-Latn");
                    rbSerbian.Checked = true;

                    this.Hide();
                    this.Close();
                }
            }
            else if(LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show("Do you really want to logout?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SetLanguage("sr-Latn");
                    rbSerbian.Checked = true;

                    this.Hide();
                    this.Close();
                }
            }
        }

        private void FillGridPlayers()
        {
            dgvPregledIgraca.Rows.Clear();
            foreach (Igrac igrac in IgracImpl.getIgraci())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = igrac
                };
                row.CreateCells(dgvPregledIgraca, igrac.IDOsobe.IDOsobe, igrac.IDOsobe.Ime, igrac.IDOsobe.Prezime, igrac.IDOsobe.Nacionalnost, igrac.Pozicija, igrac.BrojDresa);
                dgvPregledIgraca.Rows.Add(row);
            }

            dgvPregledIgraca.ClearSelection();
        }

        private void FillGridCoaches()
        {
            dgvPregledTrenera.Rows.Clear();
            foreach (Trener trener in TrenerImpl.getTreneri())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = trener
                };
                row.CreateCells(dgvPregledTrenera, trener.IDOsobe.IDOsobe, trener.IDOsobe.Ime, trener.IDOsobe.Prezime, trener.IDOsobe.Nacionalnost, trener.Specijalizacija);
                dgvPregledTrenera.Rows.Add(row);
            }

            dgvPregledTrenera.ClearSelection();
        }

        private void bPlayers_Click(object sender, EventArgs e)
        {
            AddPlayerPanel.Visible = false;

            PlayersPanel.Visible = true;
            CoachesPanel.Visible = false;
            MatchesPanel.Visible = false;
            StatisticsPanel.Visible = false;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            FillGridPlayers();

            dgvPlayersGoalkeepers.Visible = false;
            dgvPlayersDefenders.Visible = false;
            dgvPlayersMidfielders.Visible = false;
            dgvPlayersAttackers.Visible = false;

            dgvPregledIgraca.Visible = true;

            bAddPlayer.Visible = true;
            bUpdatePlayer.Visible = true;
            bDeletePlayer.Visible = true;

            bNazadPlayers.Visible = false;
        }

        private void bCoaches_Click(object sender, EventArgs e)
        {
            AddCoachPanel.Visible = false;

            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = false;
            StatisticsPanel.Visible = false;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            FillGridCoaches();

            bAddCoach.Visible = true;
            bUpdateCoach.Visible = true;
            bDeleteCoach.Visible = true;
        }

        private void bMatches_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = false;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            AddMatchPanel.Visible = false;
            OpponentsPanel.Visible = false;

            bSeeDetails.Enabled = false;

            FillGridPlayedMatches();
            FillGridScheduledMatches();

            dgvScheduledMatches.Columns["TerminZakazane"].DefaultCellStyle.Format = "dd.MM.yy.   HH.mm";
            dgvPlayedMatches.Columns["TerminOdigrane"].DefaultCellStyle.Format = "dd.MM.yy.   HH.mm";

            dgvPlayedMatches.Visible = true;
            dgvScheduledMatches.Visible = false;

            bPlayedMatches.PerformClick();
        }

        private void bStatistics_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = true;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            cbSeasons.SelectedIndex = cbSeasons.Items.Count - 1;
            cbCompetitionsStatistics.SelectedIndex = cbCompetitionsStatistics.Items.Count - 1;

            bBySeason.PerformClick();
        }

        private void bAboutClub_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = true;
            AboutClubPanel.Visible = true;
            SettingsPanel.Visible = false;

            tbName.Visible = false;
            tbCity.Visible = false;
            dtpEstablished.Visible = false;
            tbStadium.Visible = false;

            bPotvrdiUpdateAboutClub.Visible = false;
            bOdustaniUpdateAboutClub.Visible = false;

            FillAboutClub();
        }
        private void bAddPlayer_Click(object sender, EventArgs e)
        {
            tbNamePlayer.Clear();
            tbLastnamePlayer.Clear();
            tbNationalityPlayer.Clear();
            cbPositionPlayer.Text = "golman";
            tbJerseyNumber.Clear();

            bPotvrdiAddPlayer.Visible = true;
            bPotvrdiUpdatePlayer.Visible = false;

            AddPlayerPanel.Visible = true;

            bAddPlayer.Visible = false;
            bUpdatePlayer.Visible = false;
            bDeletePlayer.Visible = false;
        }

        private void bUpdatePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvPregledIgraca.SelectedRows[0];

                tbNamePlayer.Text = selectedRow.Cells["Ime"].Value.ToString();
                tbLastnamePlayer.Text = selectedRow.Cells["Prezime"].Value.ToString();
                tbNationalityPlayer.Text = selectedRow.Cells["NacionalnostIgraca"].Value.ToString();
                cbPositionPlayer.Text = selectedRow.Cells["Pozicija"].Value.ToString();
                tbJerseyNumber.Text = selectedRow.Cells["BrojDresa"].Value.ToString();

                selectedPlayersID = selectedRow.Cells["IDIgraca"].Value.ToString();

                bPotvrdiAddPlayer.Visible = false;
                bPotvrdiUpdatePlayer.Visible = true;

                AddPlayerPanel.Visible = true;

                bAddPlayer.Visible = false;
                bUpdatePlayer.Visible = false;
                bDeletePlayer.Visible = false;
            }
            catch (Exception)
            {
                if(LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate selektovati željenog igrača!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You need to select player!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bDeletePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvPregledIgraca.SelectedRows[0];

                string Ime = selectedRow.Cells["Ime"].Value.ToString();
                string Prezime = selectedRow.Cells["Prezime"].Value.ToString();

                if(LANGUAGE.Equals("sr-Latn"))
                {
                    DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati igrača \n{Ime} {Prezime}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDIgraca = selectedRow.Cells["IDIgraca"].Value.ToString();

                        IgracImpl.deleteIgrac(Convert.ToInt32(IDIgraca));
                    }
                }
                else if(LANGUAGE.Equals("en"))
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the player \n{Ime} {Prezime}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDIgraca = selectedRow.Cells["IDIgraca"].Value.ToString();

                        IgracImpl.deleteIgrac(Convert.ToInt32(IDIgraca));
                    }
                }

                bPlayers.PerformClick();
            }
            catch (Exception)
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate selektovati igrača kog želite obrisati!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You need to select player!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bPotvrdiAddPlayer_Click(object sender, EventArgs e)
        {
            if (!tbNamePlayer.Text.Equals("") && !tbLastnamePlayer.Text.Equals("") && !tbNationalityPlayer.Text.Equals("") && !cbPositionPlayer.Text.Equals("") && !tbJerseyNumber.Text.Equals(""))
            {
                IgracImpl.insertIgrac(tbNamePlayer.Text, tbLastnamePlayer.Text, tbNationalityPlayer.Text, cbPositionPlayer.Text, int.Parse(tbJerseyNumber.Text));
                bPlayers.PerformClick();
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

        private void bPotvrdiUpdatePlayer_Click(object sender, EventArgs e)
        {
            if (!tbNamePlayer.Text.Equals("") && !tbLastnamePlayer.Text.Equals("") && !tbNationalityPlayer.Text.Equals("") && !cbPositionPlayer.Text.Equals("") && !tbJerseyNumber.Text.Equals(""))
            {
                IgracImpl.updateIgrac(Convert.ToInt32(selectedPlayersID), tbNamePlayer.Text, tbLastnamePlayer.Text, tbNationalityPlayer.Text, cbPositionPlayer.Text, Convert.ToInt32(tbJerseyNumber.Text));
                bPlayers.PerformClick();
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

        private void bAddCoach_Click(object sender, EventArgs e)
        {
            tbNameCoach.Clear();
            tbLastnameCoach.Clear();
            tbNationalityCoach.Clear();
            tbSpecializationCoach.Clear();

            bPotvrdiAddCoach.Visible = true;
            bPotvrdiUpdateCoach.Visible = false;

            AddCoachPanel.Visible = true;

            bAddCoach.Visible = false;
            bUpdateCoach.Visible = false;
            bDeleteCoach.Visible = false;
        }

        private void bUpdateCoach_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvPregledTrenera.SelectedRows[0];

                tbNameCoach.Text = selectedRow.Cells["ImeTrenera"].Value.ToString();
                tbLastnameCoach.Text = selectedRow.Cells["PrezimeTrenera"].Value.ToString();
                tbNationalityCoach.Text = selectedRow.Cells["NacionalnostTrenera"].Value.ToString();
                tbSpecializationCoach.Text = selectedRow.Cells["Specijalizacija"].Value.ToString();

                selectedCoachID = selectedRow.Cells["IDTrenera"].Value.ToString();

                bPotvrdiAddCoach.Visible = false;
                bPotvrdiUpdateCoach.Visible = true;

                AddCoachPanel.Visible = true;

                bAddCoach.Visible = false;
                bUpdateCoach.Visible = false;
                bDeleteCoach.Visible = false;
            }
            catch (Exception)
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate selektovati željenog trenera!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You need to select coach!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bDeleteCoach_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvPregledTrenera.SelectedRows[0];

                string Ime = selectedRow.Cells["ImeTrenera"].Value.ToString();
                string Prezime = selectedRow.Cells["PrezimeTrenera"].Value.ToString();

                if(LANGUAGE.Equals("sr-Latn"))
                {
                    DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati trenera: \n{Ime} {Prezime}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDTrenera = selectedRow.Cells["IDTrenera"].Value.ToString();

                        TrenerImpl.deleteTrener(Convert.ToInt32(IDTrenera));
                    }
                }
                else if(LANGUAGE.Equals("en"))
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the coach: \n{Ime} {Prezime}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDTrenera = selectedRow.Cells["IDTrenera"].Value.ToString();

                        TrenerImpl.deleteTrener(Convert.ToInt32(IDTrenera));
                    }
                }

                bCoaches.PerformClick();
            }
            catch (Exception)
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate selektovati trenera kog želite obrisati!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You need to select coach!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void bPotvrdiAddCoach_Click(object sender, EventArgs e)
        {
            if (!tbNameCoach.Text.Equals("") && !tbLastnameCoach.Text.Equals("") && !tbNationalityCoach.Text.Equals("") && !tbSpecializationCoach.Text.Equals(""))
            {
                TrenerImpl.insertTrener(tbNameCoach.Text, tbLastnameCoach.Text, tbNationalityCoach.Text, tbSpecializationCoach.Text);
                bCoaches.PerformClick();
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

        private void bPotvrdiUpdateCoach_Click(object sender, EventArgs e)
        {
            if (!tbNameCoach.Text.Equals("") && !tbLastnameCoach.Text.Equals("") && !tbNationalityCoach.Text.Equals("") && !tbSpecializationCoach.Text.Equals(""))
            {
                TrenerImpl.updateTrener(Convert.ToInt32(selectedCoachID), tbNameCoach.Text, tbLastnameCoach.Text, tbNationalityCoach.Text, tbSpecializationCoach.Text);
                bCoaches.PerformClick();
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

        private void bPlayedMatches_Click(object sender, EventArgs e)
        {
            AddMatchPanel.Visible = false;

            bAddMatchPlayed.Visible = true;
            bAddMatchScheduled.Visible = false;

            bDeletePlayedMatch.Visible = true;
            bDeleteScheduledMatch.Visible = false;

            bSeeDetails.Visible = true;
            bSeeDetails.Enabled = false;


            FillGridPlayedMatches();

            dgvPlayedMatches.Sort(dgvPlayedMatches.Columns["TerminOdigrane"], System.ComponentModel.ListSortDirection.Descending);

            dgvScheduledMatches.Visible = false;
            dgvPlayedMatches.Visible = true;
            bPlayedMatches.FlatStyle = FlatStyle.Popup;
            bScheduledMatches.FlatStyle = FlatStyle.System;
        }

        private void bScheduledMatches_Click(object sender, EventArgs e)
        {
            AddMatchPanel.Visible = false;

            bAddMatchPlayed.Visible = false;
            bAddMatchScheduled.Visible = true;

            bDeletePlayedMatch.Visible = false;
            bDeleteScheduledMatch.Visible = true;

            bSeeDetails.Visible = false;
            bSeeDetails.Enabled = false;

            bDeleteScheduledMatch.Enabled = false;

            FillGridScheduledMatches();

            dgvScheduledMatches.Sort(dgvScheduledMatches.Columns["TerminZakazane"], System.ComponentModel.ListSortDirection.Ascending);

            dgvPlayedMatches.Visible = false;
            dgvScheduledMatches.Visible = true;
            bScheduledMatches.FlatStyle = FlatStyle.Popup;
            bPlayedMatches.FlatStyle = FlatStyle.System;

            dgvScheduledMatches.ClearSelection();
        }
        public void FillGridPlayedMatches()
        {
            club = KlubImpl.getKlub().NazivKluba;

            string SELECT_VIEW_ODIGRANE = "SELECT * FROM odigrane_utakmice_info";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                dgvPlayedMatches.Rows.Clear();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_VIEW_ODIGRANE;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();

                    int IDUtakmice = reader.GetInt32(0);
                    string opponent = reader.GetString(1);
                    string homeOrAway = reader.GetString(3);
                    string game = "";

                    if (homeOrAway.Equals("Domaćin"))
                    {
                        game = club + " - " + opponent;
                    }
                    else
                    {
                        game = opponent + " - " + club;
                    }

                    if (UtakmicaImpl.isConfirmed(IDUtakmice))
                    {
                        row.CreateCells(dgvPlayedMatches, IDUtakmice, game, reader.GetString(2), opponent, homeOrAway, reader.GetDateTime(4));
                    }
                    else
                    {
                        row.CreateCells(dgvPlayedMatches, IDUtakmice, game, "  -  ", opponent, homeOrAway, reader.GetDateTime(4));
                    }

                    dgvPlayedMatches.Rows.Add(row);
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

            dgvPlayedMatches.ClearSelection();
        }

        private void FillGridScheduledMatches()
        {
            string SELECT_VIEW_ZAKAZANE = "SELECT * FROM zakazane_utakmice_info";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                dgvScheduledMatches.Rows.Clear();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_VIEW_ZAKAZANE;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvScheduledMatches, reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3));
                    dgvScheduledMatches.Rows.Add(row);
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

            dgvScheduledMatches.ClearSelection();
        }

        private void dgvPlayedMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlayedMatches.SelectedRows.Count > 0)
            {
                bDeletePlayedMatch.Enabled = true;
                bSeeDetails.Enabled = true;
            }
            else
            {
                bDeletePlayedMatch.Enabled = false;
                bSeeDetails.Enabled = false;
            }
        }

        private void dgvScheduledMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScheduledMatches.SelectedRows.Count > 0)
            {
                bDeleteScheduledMatch.Enabled = true;
            }
            else
            {
                bDeleteScheduledMatch.Enabled = false;
            }
        }

        private void bSeeDetails_Click(object sender, EventArgs e)
        {
            bool isConfirmed = false;

            DataGridViewRow selectedRow = dgvPlayedMatches.SelectedRows[0];

            int IDUtakmice = Convert.ToInt32(selectedRow.Cells["IDUtakmiceOdigrane"].Value.ToString());
            string protivnik = selectedRow.Cells["ProtivnikOdigrane"].Value.ToString();
            string rezultat = selectedRow.Cells["Rezultat"].Value.ToString();
            string domacinIliGost = selectedRow.Cells["DomacinIliGostOdigrane"].Value.ToString();

            if (UtakmicaImpl.isConfirmed(IDUtakmice))
            {
                isConfirmed = true;
                new Game(IDUtakmice, protivnik, rezultat, domacinIliGost, isConfirmed, USERNAME, LANGUAGE).ShowDialog();
            }
            else
            {
                if(LANGUAGE.Equals("sr-Latn"))
                {
                    DialogResult result = MessageBox.Show("Utakmica nije potvrđena!\nDa li želite da potvrdite utakmicu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        isConfirmed = false;
                        new Game(IDUtakmice, protivnik, rezultat, domacinIliGost, isConfirmed, USERNAME, LANGUAGE).ShowDialog();
                    }
                }
                else if(LANGUAGE.Equals("en"))
                {
                    DialogResult result = MessageBox.Show("The match is not confirmed!\nDo you want to confirm the match?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        isConfirmed = false;
                        new Game(IDUtakmice, protivnik, rezultat, domacinIliGost, isConfirmed, USERNAME, LANGUAGE).ShowDialog();
                    }
                }

                bPlayedMatches.PerformClick();
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value < DateTime.Now)
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Najraniji datum za zakazivanje utakmice je sutrašnji datum!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("The earliest date to schedule a match is tomorrow!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void mtbTime_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbOpponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOpponents.SelectedItem != null)
            {
                ProtivnickiKlub selectedProtivnickiKLub = (ProtivnickiKlub)cbOpponents.SelectedItem;
                selectedIDProtivnickogKluba = selectedProtivnickiKLub.IDProtivnickogKluba;
            }
        }

        private void cbCompetitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCompetitionsAddMatch.SelectedItem != null)
            {
                Takmicenje selectedTakmicenje = (Takmicenje)cbCompetitionsAddMatch.SelectedItem;
                selectedIDTakmicenja = selectedTakmicenje.IDTakmicenja;
            }
        }

        public void LoadDataIntoCBOpponents()
        {
            cbOpponents.Items.Clear();
            cbOpponents.DisplayMember = "NazivProtivnickogKluba";
            cbOpponents.ValueMember = "IDProtivnickogKluba";
            foreach (ProtivnickiKlub protivnickiKlub in ProtivnickiKlubImpl.getProtivnickiKlubovi())
            {
                cbOpponents.Items.Add(protivnickiKlub);
            }
        }

        public void LoadDataIntoCBCompetitionsAddMatch()
        {
            cbCompetitionsAddMatch.Items.Clear();
            cbCompetitionsAddMatch.DisplayMember = "NazivTakmicenja";
            cbCompetitionsAddMatch.ValueMember = "IDTakmicenja";
            foreach (Takmicenje takmicenje in TakmicenjeImpl.getTakmicenja())
            {
                cbCompetitionsAddMatch.Items.Add(takmicenje);
            }
        }

        public static bool IsValidTimeFormat(string input)
        {
            if (DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return true;
            }
            return false;
        }

        private void bPotvrdiAddMatch_Click(object sender, EventArgs e)
        {
            if (IsValidTimeFormat(mtbTime.Text) && selectedIDProtivnickogKluba != 0 &&
                selectedIDTakmicenja != 0 && !cbOpponents.Text.Equals("") && !cbCompetitionsAddMatch.Text.Equals("") && !tbPhase.Text.Equals(""))
            {
                DateTime dateTime = dtpDate.Value.Date;
                DateTime resultDateTime = new DateTime();

                if (TimeSpan.TryParse(mtbTime.Text, out TimeSpan timeSpan))
                {
                    resultDateTime = dateTime.Add(timeSpan);
                }

                UtakmicaImpl.insertUtakmica(resultDateTime, rbHost.Checked, 0, 0, tbPhase.Text, false, selectedIDProtivnickogKluba, selectedIDTakmicenja, currentSeason);

                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Uspješno ste dodali utakmicu!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You have successfully added a match!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dtpDate.Value = dtpDate.MinDate;
                mtbTime.Text = "";
                cbOpponents.Text = "";
                cbCompetitionsAddMatch.Text = "";
                tbPhase.Text = "";
                rbHost.Checked = true;
                rbGuest.Checked = false;

                bScheduledMatches.PerformClick();
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

        private void tbNamePlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbLastnamePlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbNationalityPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbJerseyNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbNameCoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbLastnameCoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbNationalityCoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbSpecializationCoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void bNazadPlayer_Click(object sender, EventArgs e)
        {
            bPlayers.PerformClick();
        }

        private void bNazadCoach_Click(object sender, EventArgs e)
        {
            bCoaches.PerformClick();
        }

        private void dgvPregledIgraca_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPregledIgraca.SelectedRows.Count > 0)
            {
                bUpdatePlayer.Enabled = true;
                bDeletePlayer.Enabled = true;
            }
            else
            {
                bUpdatePlayer.Enabled = false;
                bDeletePlayer.Enabled = false;
            }
        }

        private void dgvPregledTrenera_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPregledTrenera.SelectedRows.Count > 0)
            {
                bUpdateCoach.Enabled = true;
                bDeleteCoach.Enabled = true;
            }
            else
            {
                bUpdateCoach.Enabled = false;
                bDeleteCoach.Enabled = false;
            }
        }

        private void bDeletePlayedMatch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvPlayedMatches.SelectedRows[0];

                string Utakmica = selectedRow.Cells["Utakmica"].Value.ToString();
                string Rezultat = selectedRow.Cells["Rezultat"].Value.ToString();

                if (LANGUAGE.Equals("sr-Latn"))
                {
                    DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati utakmicu: \n{Utakmica} ({Rezultat})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDUtakmice = selectedRow.Cells["IDUtakmiceOdigrane"].Value.ToString();

                        UtakmicaImpl.deleteUtakmica(Convert.ToInt32(IDUtakmice));
                    }
                }
                else if (LANGUAGE.Equals("en"))
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the match: \n{Utakmica} ({Rezultat})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDUtakmice = selectedRow.Cells["IDUtakmiceOdigrane"].Value.ToString();

                        UtakmicaImpl.deleteUtakmica(Convert.ToInt32(IDUtakmice));
                    }
                }

                bPlayedMatches.PerformClick();
            }
            catch (Exception)
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate selektovati utakmicu koju želite obrisati!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You need to select match!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void bDeleteScheduledMatch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgvScheduledMatches.SelectedRows[0];

                string Protivnik = selectedRow.Cells["ProtivnikZakazane"].Value.ToString();
                DateTime dateTime = Convert.ToDateTime(selectedRow.Cells["TerminZakazane"].Value);

                if (LANGUAGE.Equals("sr-Latn"))
                {
                    DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati utakmicu protiv: \n{Protivnik}  [{dateTime.ToString("dd.MM.yy   HH.mm")}]?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDUtakmice = selectedRow.Cells["IDUtakmiceZakazane"].Value.ToString();

                        UtakmicaImpl.deleteUtakmica(Convert.ToInt32(IDUtakmice));
                    }
                }
                else if (LANGUAGE.Equals("en"))
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete match against: \n{Protivnik}  [{dateTime.ToString("dd.MM.yy   HH.mm")}]?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string IDUtakmice = selectedRow.Cells["IDUtakmiceZakazane"].Value.ToString();

                        UtakmicaImpl.deleteUtakmica(Convert.ToInt32(IDUtakmice));
                    }
                }

                bScheduledMatches.PerformClick();
            }
            catch (Exception)
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate selektovati utakmicu koju želite obrisati!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("You need to select match!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bAddMatchPlayed_Click(object sender, EventArgs e)
        {
            LoadDataIntoCBOpponents();
            LoadDataIntoCBCompetitionsAddMatch();

            cbOpponents.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCompetitionsAddMatch.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpDate.MinDate = DateTime.Now.AddDays(1);

            AddMatchPanel.Visible = true;

            bNazadAddMatchPlayed.Visible = true;
            bNazadAddMatchScheduled.Visible = false;
        }

        private void bAddMatchScheduled_Click(object sender, EventArgs e)
        {
            LoadDataIntoCBOpponents();
            LoadDataIntoCBCompetitionsAddMatch();

            dtpDate.MinDate = DateTime.Now.AddDays(1);

            AddMatchPanel.Visible = true;

            bNazadAddMatchPlayed.Visible = false;
            bNazadAddMatchScheduled.Visible = true;
        }

        private void bNazadAddMatchPlayed_Click(object sender, EventArgs e)
        {
            bMatches.PerformClick();
        }

        private void bNazadAddMatchScheduled_Click(object sender, EventArgs e)
        {
            bMatches.PerformClick();
            bScheduledMatches.PerformClick();
        }

        private void bBySeason_Click(object sender, EventArgs e)
        {
            bBySeason.FlatStyle = FlatStyle.Popup;
            bByCompetition.FlatStyle = FlatStyle.System;

            bUpdateSeasonSuccess.Visible = true;
            bUpdateSeasonSuccess.Enabled = false;
            bUpdateCompetitionSuccess.Visible = false;
            bUpdateCompetitionSuccess.Enabled = false;

            dgvResultsBySeason.Visible = true;
            dgvResultsByCompetition.Visible = false;

            cbSeasons.Visible = true;
            cbCompetitionsStatistics.Visible = false;

            lbIzaberiSezonu.Visible = true;
            lbIzaberiTakmicenje.Visible = false;

            LoadDataIntoCBSeasons();

            cbSeasons.SelectedIndex = cbSeasons.Items.Count - 1;

            UpdateSuccessPanel.Visible = false;
            SeasonPanel.Visible = false;
            CompetitionPanel.Visible = false;

            cbSeasons.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void bByCompetition_Click(object sender, EventArgs e)
        {
            bByCompetition.FlatStyle = FlatStyle.Popup;
            bBySeason.FlatStyle = FlatStyle.System;

            bUpdateSeasonSuccess.Visible = false;
            bUpdateSeasonSuccess.Enabled = false;
            bUpdateCompetitionSuccess.Visible = true;
            bUpdateCompetitionSuccess.Enabled = false;

            dgvResultsBySeason.Visible = false;
            dgvResultsByCompetition.Visible = true;

            cbSeasons.Visible = false;
            cbCompetitionsStatistics.Visible = true;

            lbIzaberiSezonu.Visible = false;
            lbIzaberiTakmicenje.Visible = true;

            LoadDataIntoCBCompetitionsStatistics();

            cbCompetitionsStatistics.SelectedIndex = cbCompetitionsStatistics.Items.Count - 1;

            UpdateSuccessPanel.Visible = false;

            cbCompetitionsStatistics.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void FillBySeason(string Sezona)
        {
            string SELECT_REZULTATI_PO_SEZONI = "SELECT IDSezone, IDTakmicenja, Takmicenje, Uspjeh FROM TAKMICENJA_PO_SEZONAMA_INFO WHERE Sezona = '";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                dgvResultsBySeason.Rows.Clear();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_REZULTATI_PO_SEZONI + Sezona + "';";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvResultsBySeason, reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
                    dgvResultsBySeason.Rows.Add(row);
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

            dgvResultsBySeason.ClearSelection();
        }

        public void FillByCompetition(string Takmicenje)
        {
            string SELECT_REZULTATI_PO_TAKMICENJU = "SELECT IDSezone, IDTakmicenja, Sezona, Uspjeh FROM TAKMICENJA_PO_SEZONAMA_INFO WHERE Takmicenje = '";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                dgvResultsByCompetition.Rows.Clear();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_REZULTATI_PO_TAKMICENJU + Takmicenje + "';";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvResultsByCompetition, reader.GetInt32(0), reader.GetInt32(1),reader.GetString(2), reader.GetString(3));
                    dgvResultsByCompetition.Rows.Add(row);
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

            dgvResultsByCompetition.ClearSelection();
        }

        public void LoadDataIntoCBSeasons()
        {
            cbSeasons.Items.Clear();
            cbSeasons.DisplayMember = "NazivSezone";
            cbSeasons.ValueMember = "IDSezone";
            foreach (Sezona sezona in SezonaImpl.getSezone())
            {
                cbSeasons.Items.Add(sezona);
            }
        }

        private void cbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeasons.SelectedItem != null)
            {
                selectedSeason = cbSeasons.Text;
            }
            FillBySeason(selectedSeason);
        }

        public void LoadDataIntoCBCompetitionsStatistics()
        {
            cbCompetitionsStatistics.Items.Clear();
            cbCompetitionsStatistics.DisplayMember = "NazivTakmicenja";
            cbCompetitionsStatistics.ValueMember = "IDTakmicenja";
            foreach (Takmicenje takmicenje in TakmicenjeImpl.getTakmicenja())
            {
                cbCompetitionsStatistics.Items.Add(takmicenje);
            }
        }

        private void cbCompetitionsStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCompetitionsStatistics.SelectedItem != null)
            {
                selectedCompetitionStatistics = cbCompetitionsStatistics.Text;
            }
            FillByCompetition(selectedCompetitionStatistics);
        }

        private void bAddSeason_Click(object sender, EventArgs e)
        {
            tbSeason.Text = "";
            lbErrorAddSeason.Visible = false;

            AddSeasonPanel.Visible = true;

            bPotvrdiAddSeason.Visible = true;
            bPotvrdiAddSeason.Enabled = false;
            bPotvrdiUpdateSeason.Visible = false;
        }


        private void bUpdateSeason_Click(object sender, EventArgs e)
        {
            lbErrorAddSeason.Visible = false;

            AddSeasonPanel.Visible = true;

            DataGridViewRow selectedRow = dgvSeasons.SelectedRows[0];

            tbSeason.Text = selectedRow.Cells["Sezona"].Value.ToString();

            selectedIDSezone = Convert.ToInt32(selectedRow.Cells["IDSezone"].Value.ToString());

            bPotvrdiAddSeason.Visible = false;
            bPotvrdiUpdateSeason.Visible = true;
        }

        private void bDeleteSeason_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvSeasons.SelectedRows[0];

            string sezona = selectedRow.Cells["Sezona"].Value.ToString();

            if (LANGUAGE.Equals("sr-Latn"))
            {
                DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati sezonu: \n{sezona}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedIDSezone = Convert.ToInt32(selectedRow.Cells["IDSezone"].Value.ToString());

                    SezonaImpl.deleteSezona(selectedIDSezone);
                }
            }
            else if (LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the season: \n{sezona}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedIDSezone = Convert.ToInt32(selectedRow.Cells["IDSezone"].Value.ToString());

                    SezonaImpl.deleteSezona(selectedIDSezone);
                }
            }

            bSeasons.PerformClick();
        }

        private void bAddCompetition_Click(object sender, EventArgs e)
        {
            tbCompetition.Text = "";

            AddCompetitionPanel.Visible = true;

            bPotvrdiAddCompetition.Visible = true;
            bPotvrdiUpdateCompetition.Visible = false;
        }

        private void bUpdateCompetition_Click(object sender, EventArgs e)
        {
            AddCompetitionPanel.Visible = true;

            DataGridViewRow selectedRow = dgvCompetitions.SelectedRows[0];

            tbCompetition.Text = selectedRow.Cells["Takmicenje"].Value.ToString();

            selectedIDTakmicenja = Convert.ToInt32(selectedRow.Cells["IDTakmicenja"].Value.ToString());

            bPotvrdiAddCompetition.Visible = false;
            bPotvrdiUpdateCompetition.Visible = true;
        }

        private void bDeleteCompetition_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvCompetitions.SelectedRows[0];

            string takmicenje = selectedRow.Cells["Takmicenje"].Value.ToString();

            if (LANGUAGE.Equals("sr-Latn"))
            {
                DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati takmicenje: \n{takmicenje}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedIDTakmicenja = Convert.ToInt32(selectedRow.Cells["IDTakmicenja"].Value.ToString());

                    TakmicenjeImpl.deleteTakmicenje(selectedIDTakmicenja);
                }
            }
            else if (LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the competition: \n{takmicenje}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedIDTakmicenja = Convert.ToInt32(selectedRow.Cells["IDTakmicenja"].Value.ToString());

                    TakmicenjeImpl.deleteTakmicenje(selectedIDTakmicenja);
                }
            }

            bCompetitions.PerformClick();
        }

        private void FillGridSeasons()
        {
            dgvSeasons.Rows.Clear();
            foreach (Sezona sezona in SezonaImpl.getSezone())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = sezona
                };
                row.CreateCells(dgvSeasons, sezona.IDSezone, sezona.NazivSezone);
                dgvSeasons.Rows.Add(row);
            }

            dgvSeasons.ClearSelection();
        }

        private void bSeasons_Click(object sender, EventArgs e)
        {
            SeasonPanel.Visible = true;
            AddSeasonPanel.Visible = false;

            FillGridSeasons();
            LoadDataIntoCBCurrentSeason();

            cbCurrentSeason.DropDownStyle = ComboBoxStyle.DropDownList;

            cbCurrentSeason.SelectedIndex = cbCurrentSeason.Items.Count - 1;
        }

        private void dgvSeasons_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeasons.SelectedRows.Count > 0)
            {
                bUpdateSeason.Enabled = true;
                bDeleteSeason.Enabled = true;
            }
            else
            {
                bUpdateSeason.Enabled = false;
                bDeleteSeason.Enabled = false;
            }
        }

        private void bNazadSeason_Click(object sender, EventArgs e)
        {
            bBySeason.PerformClick();
        }

        private void tbSeason_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^\d{2}/\d{2}$";

            if (!Regex.IsMatch(tbSeason.Text, pattern))
            {
                lbErrorAddSeason.Visible = true;

                if (LANGUAGE.Equals("sr-Latn"))
                {
                    lbErrorAddSeason.Text = "Sezona mora biti u formatu: 'YY/YY'.";
                }
                else if (LANGUAGE.Equals("en"))
                {
                    lbErrorAddSeason.Text = "Season format must be: 'YY/YY'.";
                }

                bPotvrdiAddSeason.Enabled = false;
                bPotvrdiUpdateSeason.Enabled = false;
            }
            else
            {
                lbErrorAddSeason.Text = "";
                bPotvrdiAddSeason.Enabled = true;
                bPotvrdiUpdateSeason.Enabled = true;
            }
        }

        private void bPotvrdiAddSeason_Click(object sender, EventArgs e)
        {
            if (!tbSeason.Text.Equals(""))
            {
                SezonaImpl.insertSezona(tbSeason.Text);
                bSeasons.PerformClick();
            }
            else
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate popuniti polje!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("Field must be filled!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            tbSeason.Text = "";
            lbErrorAddSeason.Visible = false;
        }

        private void bPotvrdiUpdateSeason_Click(object sender, EventArgs e)
        {
            if (!tbSeason.Text.Equals(""))
            {
                SezonaImpl.updateSezona(selectedIDSezone, tbSeason.Text);
                bSeasons.PerformClick();
            }
            else
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate popuniti polje!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("Field must be filled!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            tbSeason.Text = "";
            lbErrorAddSeason.Visible = false;
        }

        private void cbCurrentSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrentSeason.SelectedItem != null)
            {
                Sezona selectedSezona = (Sezona)cbCurrentSeason.SelectedItem;
                currentSeason = selectedSezona.IDSezone;
            }
        }

        public void LoadDataIntoCBCurrentSeason()
        {
            cbCurrentSeason.Items.Clear();
            cbCurrentSeason.DisplayMember = "NazivSezone";
            cbCurrentSeason.ValueMember = "IDSezone";
            foreach (Sezona sezona in SezonaImpl.getSezone())
            {
                cbCurrentSeason.Items.Add(sezona);
            }
        }

        private void bCompetitions_Click(object sender, EventArgs e)
        {
            CompetitionPanel.Visible = true;
            AddCompetitionPanel.Visible = false;

            FillGridCompetitions();
        }

        private void dgvCompetitions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompetitions.SelectedRows.Count > 0)
            {
                bUpdateCompetition.Enabled = true;
                bDeleteCompetition.Enabled = true;
            }
            else
            {
                bUpdateCompetition.Enabled = false;
                bDeleteCompetition.Enabled = false;
            }
        }

        private void bNazadCompetition_Click(object sender, EventArgs e)
        {
            bBySeason.PerformClick();
        }

        private void FillGridCompetitions()
        {
            dgvCompetitions.Rows.Clear();
            foreach (Takmicenje takmicenje in TakmicenjeImpl.getTakmicenja())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = takmicenje
                };
                row.CreateCells(dgvCompetitions, takmicenje.IDTakmicenja, takmicenje.NazivTakmicenja);
                dgvCompetitions.Rows.Add(row);
            }

            dgvCompetitions.ClearSelection();
        }

        private void bPotvrdiAddCompetition_Click(object sender, EventArgs e)
        {
            if (!tbCompetition.Text.Equals(""))
            {
                TakmicenjeImpl.insertTakmicenje(tbCompetition.Text);
                bCompetitions.PerformClick();
            }
            else
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate popuniti polje!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("Field must be filled!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            tbCompetition.Text = "";
        }
        private void bPotvrdiUpdateCompetition_Click(object sender, EventArgs e)
        {
            if (!tbCompetition.Text.Equals(""))
            {
                TakmicenjeImpl.updateTakmicenje(selectedIDTakmicenja, tbCompetition.Text);
                bCompetitions.PerformClick();
            }
            else
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Morate popuniti polje!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("Field must be filled!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            tbCompetition.Text = "";
        }

        private void tbCompetition_TextChanged(object sender, EventArgs e)
        {
            if (tbCompetition.Text.Equals(""))
            {
                bPotvrdiAddSeason.Enabled = false;
                bPotvrdiUpdateSeason.Enabled = false;
            }
            else
            {
                bPotvrdiAddSeason.Enabled = true;
                bPotvrdiUpdateSeason.Enabled = true;
            }
        }

        private void bUpdateSeasonSuccess_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvResultsBySeason.SelectedRows[0];

            selectedIDSezone = Convert.ToInt32(selectedRow.Cells["IDSezoneBySeason"].Value.ToString());
            selectedIDTakmicenja = Convert.ToInt32(selectedRow.Cells["IDTakmicenjaBySeason"].Value.ToString());
            tbUpdateSuccess.Text = selectedRow.Cells["UspjehBySeason"].Value.ToString();

            bPotvrdiSuccessBySeason.Visible = true;
            bPotvrdiSuccessByCompetition.Visible = false;
            bOdustaniBySeason.Visible = true;
            bOdustaniByCompetition.Visible = false;

            bPotvrdiSuccessBySeason.Enabled = false;

            dgvResultsBySeason.Visible = false;
            dgvResultsByCompetition.Visible = false;
            UpdateSuccessPanel.Visible = true;
        }

        private void bUpdateCompetitionSuccess_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvResultsByCompetition.SelectedRows[0];

            selectedIDSezone = Convert.ToInt32(selectedRow.Cells["IDSezoneByCompetition"].Value.ToString());
            selectedIDTakmicenja = Convert.ToInt32(selectedRow.Cells["IDTakmicenjaByCompetition"].Value.ToString());
            tbUpdateSuccess.Text = selectedRow.Cells["UspjehByCompetition"].Value.ToString();

            bPotvrdiSuccessBySeason.Visible = false;
            bPotvrdiSuccessByCompetition.Visible = true;
            bOdustaniBySeason.Visible = false;
            bOdustaniByCompetition.Visible = true;

            bPotvrdiSuccessByCompetition.Enabled = false;

            dgvResultsBySeason.Visible = false;
            dgvResultsByCompetition.Visible = false;
            UpdateSuccessPanel.Visible = true;
        }

        private void dgvResultsByCompetition_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultsByCompetition.SelectedRows.Count > 0)
            {
                bUpdateCompetitionSuccess.Enabled = true;
            }
            else
            {
                bUpdateCompetitionSuccess.Enabled = false;
                tbUpdateSuccess.Text = "";
            }
        }

        private void dgvResultsBySeason_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultsBySeason.SelectedRows.Count > 0)
            {
                bUpdateSeasonSuccess.Enabled = true;
            }
            else
            {
                bUpdateSeasonSuccess.Enabled = false;
                tbUpdateSuccess.Text = "";
            }
        }

        private void bPotvrdiSuccessBySeason_Click(object sender, EventArgs e)
        {
            TakmicenjeSezonaImpl.updateTakmicenjeSezona(selectedIDTakmicenja, selectedIDSezone, tbUpdateSuccess.Text);

            UpdateSuccessPanel.Visible = false;
            tbUpdateSuccess.Text = "";

            bBySeason.PerformClick();
        }

        private void bPotvrdiSuccessByCompetition_Click(object sender, EventArgs e)
        {
            TakmicenjeSezonaImpl.updateTakmicenjeSezona(selectedIDTakmicenja, selectedIDSezone, tbUpdateSuccess.Text);

            UpdateSuccessPanel.Visible = false;
            tbUpdateSuccess.Text = "";

            bByCompetition.PerformClick();
        }

        private void tbUpdateSuccess_TextChanged(object sender, EventArgs e)
        {
            if (tbUpdateSuccess.Text.Equals(""))
            {
                bPotvrdiSuccessBySeason.Enabled = false;
                bPotvrdiSuccessByCompetition.Enabled = false;
            }
            else
            {
                bPotvrdiSuccessBySeason.Enabled = true;
                bPotvrdiSuccessByCompetition.Enabled = true;
            }
        }

        private void bUpdateAboutClub_Click(object sender, EventArgs e)
        {
            tbName.Visible = true;
            tbCity.Visible = true;
            dtpEstablished.Visible = true;
            tbStadium.Visible = true;

            DateTime date = DateTime.ParseExact(lbEstablished.Text, "dd.MM.yyyy.", System.Globalization.CultureInfo.InvariantCulture);

            tbName.Text = lbName.Text;
            tbCity.Text = lbCity.Text;
            dtpEstablished.Value = date;
            tbStadium.Text = lbStadium.Text;

            bPotvrdiUpdateAboutClub.Visible = true;
            bOdustaniUpdateAboutClub.Visible = true;
        }

        private void FillAboutClub()
        {
            string SELECT = "SELECT * FROM KLUB";
            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lbName.Text = reader.GetString(1);
                    DateTime date = reader.GetDateTime(2);
                    lbEstablished.Text = date.ToString("dd.MM.yyyy.");
                    lbCity.Text = reader.GetString(3);
                    lbStadium.Text = reader.GetString(4);
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void bPotvrdiUpdateAboutClub_Click(object sender, EventArgs e)
        {
            if (!tbName.Text.Equals("") && !tbCity.Text.Equals("") && !tbStadium.Text.Equals(""))
            {
                DateTime dateTime = dtpEstablished.Value.Date;


                KlubImpl.updateKlub(1, tbName.Text, dateTime, tbCity.Text, tbStadium.Text);

                bAboutClub.PerformClick();
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

        private void bOdustaniBySeason_Click(object sender, EventArgs e)
        {
            bBySeason.PerformClick();
        }

        private void bOdustaniByCompetition_Click(object sender, EventArgs e)
        {
            bByCompetition.PerformClick();
        }

        private void bOdustaniAddSeason_Click(object sender, EventArgs e)
        {
            bSeasons.PerformClick();
        }

        private void bOdustaniAddCompetition_Click(object sender, EventArgs e)
        {
            bCompetitions.PerformClick();
        }

        private void bOpponents_Click(object sender, EventArgs e)
        {
            OpponentsPanel.Visible = true;

            FillGridOpponents();

            AddOpponentPanel.Visible = false;

            bUpdateOpponent.Enabled = false;
            bDeleteOpponent.Enabled = false;
        }

        private void FillGridOpponents()
        {
            dgvOpponents.Rows.Clear();
            foreach (ProtivnickiKlub protivnickiKlub in ProtivnickiKlubImpl.getProtivnickiKlubovi())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = protivnickiKlub
                };
                row.CreateCells(dgvOpponents, protivnickiKlub.IDProtivnickogKluba, protivnickiKlub.NazivProtivnickogKluba, protivnickiKlub.Mjesto);
                dgvOpponents.Rows.Add(row);
            }

            dgvOpponents.ClearSelection();
        }

        private void bAddOpponent_Click(object sender, EventArgs e)
        {
            tbNameOpponent.Text = "";
            tbCityOpponent.Text = "";

            bPotvrdiAddOpponent.Visible = true;
            //bPotvrdiAddOpponent.Enabled = false;
            bPotvrdiUpdateOpponent.Visible = false;

            AddOpponentPanel.Visible = true;
        }

        private void bUpdateOpponent_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvOpponents.SelectedRows[0];

            tbNameOpponent.Text = selectedRow.Cells["NazivProtivnickogKluba"].Value.ToString();
            tbCityOpponent.Text = selectedRow.Cells["Mjesto"].Value.ToString();

            selectedIDProtivnickogKluba = Convert.ToInt32(selectedRow.Cells["IDProtivnickogKluba"].Value.ToString());

            bPotvrdiAddOpponent.Visible = false;
            bPotvrdiUpdateOpponent.Visible = true;

            AddOpponentPanel.Visible = true;
        }

        private void bDeleteOpponent_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvOpponents.SelectedRows[0];

            string protivnik = selectedRow.Cells["NazivProtivnickogKluba"].Value.ToString();
            string mjesto = selectedRow.Cells["Mjesto"].Value.ToString();

            if (LANGUAGE.Equals("sr-Latn"))
            {
                DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati protivnika: \n{protivnik} {mjesto}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedIDProtivnickogKluba = Convert.ToInt32(selectedRow.Cells["IDProtivnickogKluba"].Value.ToString());

                    ProtivnickiKlubImpl.deleteProtivnickiKlub(selectedIDProtivnickogKluba);
                }
            }
            else if (LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the opponent: \n{protivnik} {mjesto}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedIDProtivnickogKluba = Convert.ToInt32(selectedRow.Cells["IDProtivnickogKluba"].Value.ToString());

                    ProtivnickiKlubImpl.deleteProtivnickiKlub(selectedIDProtivnickogKluba);
                }
            }
            bOpponents.PerformClick();
        }

        private void bNazadOpponents_Click(object sender, EventArgs e)
        {
            LoadDataIntoCBOpponents();

            OpponentsPanel.Visible = false;
        }

        private void dgvOpponents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOpponents.SelectedRows.Count > 0)
            {
                bUpdateOpponent.Enabled = true;
                bDeleteOpponent.Enabled = true;
            }
            else
            {
                bUpdateOpponent.Enabled = false;
                bDeleteOpponent.Enabled = false;
            }
        }

        private void bPotvrdiAddOpponent_Click(object sender, EventArgs e)
        {
            if (!tbNameOpponent.Text.Equals("") && !tbCityOpponent.Text.Equals(""))
            {
                ProtivnickiKlubImpl.insertProtivnickiKlub(tbNameOpponent.Text, tbCityOpponent.Text);
                bOpponents.PerformClick();
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

            tbNameOpponent.Text = "";
            tbCityOpponent.Text = "";
        }

        private void bPotvrdiUpdateOpponent_Click(object sender, EventArgs e)
        {
            if (!tbNameOpponent.Text.Equals("") && !tbCityOpponent.Text.Equals(""))
            {
                ProtivnickiKlubImpl.updateProtivnickiKlub(selectedIDProtivnickogKluba, tbNameOpponent.Text, tbCityOpponent.Text);
                bOpponents.PerformClick();
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

            tbNameOpponent.Text = ""; 
            tbCityOpponent.Text = "";
        }

        private void bNazadAddOpponent_Click(object sender, EventArgs e)
        {
            AddOpponentPanel.Visible = false;
        }

        private void bOdustaniUpdateAboutClub_Click(object sender, EventArgs e)
        {
            bAboutClub.PerformClick();
        }

        private void bUsers_Click(object sender, EventArgs e)
        {
            UsersPanel.Visible = true;
            UpdateUserPanel.Visible = false;

            FillGridUsers();
        }

        private void bNazadUsers_Click(object sender, EventArgs e)
        {
            UsersPanel.Visible = false;
        }

        private void bUpdateUser_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            tbNameUpdate.Text = selectedRow.Cells["ImeKorisnika"].Value.ToString();
            tbLastnameUpdate.Text = selectedRow.Cells["PrezimeKorisnika"].Value.ToString();
            tbUsernameUpdate.Text = selectedRow.Cells["KorisnickoIme"].Value.ToString();

            selectedUsersID = selectedRow.Cells["IDKorisnika"].Value.ToString();

            UpdateUserPanel.Visible = true;
        }

        private void bDeleteUser_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

            string Ime = selectedRow.Cells["ImeKorisnika"].Value.ToString();
            string Prezime = selectedRow.Cells["PrezimeKorisnika"].Value.ToString();
            string KorisnickoIme = selectedRow.Cells["KorisnickoIme"].Value.ToString();

            if (LANGUAGE.Equals("sr-Latn"))
            {
                DialogResult result = MessageBox.Show($"Da li ste sigurni da želite obrisati korisnika \n{Ime} {Prezime} ({KorisnickoIme})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string IDKorisnika = selectedRow.Cells["IDKorisnika"].Value.ToString();

                    KorisnikImpl.deleteKorisnik(Convert.ToInt32(IDKorisnika));
                }
            }
            else if (LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the user \n{Ime} {Prezime} ({KorisnickoIme})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string IDKorisnika = selectedRow.Cells["IDKorisnika"].Value.ToString();

                    KorisnikImpl.deleteKorisnik(Convert.ToInt32(IDKorisnika));
                }
            }

            bUsers.PerformClick();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                bUpdateUser.Enabled = true;
                bDeleteUser.Enabled = true;
            }
            else
            {
                bUpdateUser.Enabled = false;
                bDeleteUser.Enabled = false;
            }
        }

        private void FillGridUsers()
        {
            dgvUsers.Rows.Clear();
            foreach (Korisnik korisnik in KorisnikImpl.getKorisnici())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = korisnik
                };
                if(korisnik.Uloga.Equals(false))
                {
                    row.CreateCells(dgvUsers, korisnik.IDOsobe.IDOsobe, korisnik.IDOsobe.Ime, korisnik.IDOsobe.Prezime, korisnik.KorisnickoIme);
                    dgvUsers.Rows.Add(row);
                }
            }

            dgvUsers.ClearSelection();
        }

        private void bPotvrdiUpdateUser_Click(object sender, EventArgs e)
        {
            if (!tbNameUpdate.Text.Equals("") && !tbLastnameUpdate.Text.Equals("") && !tbUsernameUpdate.Text.Equals(""))
            {
                if(!KorisnikImpl.IsUsernameExists(tbUsernameUpdate.Text))
                {
                    KorisnikImpl.updateKorisnik(Convert.ToInt32(selectedUsersID), tbNameUpdate.Text, tbLastnameUpdate.Text, tbUsernameUpdate.Text);
                    bUsers.PerformClick();
                }
                else
                {
                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Korisničko ime već postoji!\nPokušajte drugo korisničko ime.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("Username already exists!\nTry another username.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    tbUsernameUpdate.Text = "";
                    tbUsernameUpdate.Focus();
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

        private void bOdustaniUpdateUser_Click(object sender, EventArgs e)
        {
            bUsers.PerformClick();
        }

        private void bLogoutUsers_Click(object sender, EventArgs e)
        {
            if (LANGUAGE.Equals("sr-Latn"))
            {
                DialogResult result = MessageBox.Show("Da li se stvarno želite odjaviti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    this.Close();
                }
            }
            else if (LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show("Do you really want to logout?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    this.Close();
                }
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
                    if (control.Name != "UsersPanel" && control.Name != "UpdateUserPanel")
                    {
                        control.BackColor = BACK_COLOR;
                    }


                }
                else if (control is DataGridView)
                {
                    if (control.Name != "dgvUsers")
                    {
                        DataGridView dataGridView = (DataGridView)control;
                        dataGridView.BackgroundColor = BACK_COLOR;
                    }
                }
                else if (control is Button)
                {
                    if (control.Name != "bLogoutUsers" && control.Name != "bUsers" && control.Name != "bLogout" && control.Name != "bUpdateUser" && control.Name != "bDeleteUser" && control.Name != "bNazadUsers" && control.Name != "bOdustaniUpdateUser" && control.Name != "bPotvrdiUpdateUser")
                    {
                        Button button = (Button)control;
                        button.BackColor = BUTTON_COLOR;
                    }
                }
                else if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)control;
                    radioButton.BackColor = BACK_COLOR;
                }

                if (control.HasChildren)
                {
                    ChangeControlColors(control.Controls);
                }
            }
        }

        private void pbSettings_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = true;
            AboutClubPanel.Visible = true;
            SettingsPanel.Visible = true;

            if (KorisnikImpl.GetThemeForUsername(USERNAME) == 1)
            {
                rbDefaultTheme.Checked = true;
            }
            else if (KorisnikImpl.GetThemeForUsername(USERNAME) == 2)
            {
                rbBlueTheme.Checked = true;
            }
            else if (KorisnikImpl.GetThemeForUsername(USERNAME) == 3)
            {
                rbRedTheme.Checked = true;
            }
        }

        private void rbDefaultTheme_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikImpl.ChangeTheme(USERNAME, 1);
            ChangeControlColors(this.Controls);
        }

        private void rbBlueTheme_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikImpl.ChangeTheme(USERNAME, 2);
            ChangeControlColors(this.Controls);
        }

        private void rbRedTheme_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikImpl.ChangeTheme(USERNAME, 3);
            ChangeControlColors(this.Controls);
        }

        private void pbSettings_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pbSettings_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void SetLanguage(string lang)
        {
            LANGUAGE = lang;
            
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(AdminPage));
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

        private void rbSerbian_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSerbian.Checked)
            {
                SetLanguage("sr-Latn");
            }
        }

        private void rbEnglish_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnglish.Checked)
            {
                SetLanguage("en");
            }
        }

        private void tbNameUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbLastnameUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbUsernameUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void bPlayersGoalkeepers_Click(object sender, EventArgs e)
        {
            bAddPlayer.Visible = false;
            bUpdatePlayer.Visible = false;
            bDeletePlayer.Visible = false;

            bNazadPlayers.Visible = true;

            dgvPregledIgraca.Visible = false;

            dgvPlayersGoalkeepers.Visible = true;
            dgvPlayersDefenders.Visible = false;
            dgvPlayersMidfielders.Visible = false;
            dgvPlayersAttackers.Visible = false;

            FillGridPlayersGoalkeepers();
        }

        private void bPlayersDefenders_Click(object sender, EventArgs e)
        {
            bAddPlayer.Visible = false;
            bUpdatePlayer.Visible = false;
            bDeletePlayer.Visible = false;

            bNazadPlayers.Visible = true;

            dgvPregledIgraca.Visible = false;

            dgvPlayersGoalkeepers.Visible = false;
            dgvPlayersDefenders.Visible = true;
            dgvPlayersMidfielders.Visible = false;
            dgvPlayersAttackers.Visible = false;

            FillGridPlayersDefenders();
        }

        private void bPlayersMidfielders_Click(object sender, EventArgs e)
        {
            bAddPlayer.Visible = false;
            bUpdatePlayer.Visible = false;
            bDeletePlayer.Visible = false;

            bNazadPlayers.Visible = true;

            dgvPregledIgraca.Visible = false;

            dgvPlayersGoalkeepers.Visible = false;
            dgvPlayersDefenders.Visible = false;
            dgvPlayersMidfielders.Visible = true;
            dgvPlayersAttackers.Visible = false;

            FillGridPlayersMidfielders();
        }

        private void bPlayersAttackers_Click(object sender, EventArgs e)
        {
            bAddPlayer.Visible = false;
            bUpdatePlayer.Visible = false;
            bDeletePlayer.Visible = false;

            bNazadPlayers.Visible = true;

            dgvPregledIgraca.Visible = false;

            dgvPlayersGoalkeepers.Visible = false;
            dgvPlayersDefenders.Visible = false;
            dgvPlayersMidfielders.Visible = false;
            dgvPlayersAttackers.Visible = true;

            FillGridPlayersAttackers();
        }

        private void bNazadPlayers_Click(object sender, EventArgs e)
        {
            bPlayers.PerformClick();
        }

        private void FillGridPlayersGoalkeepers()
        {
            dgvPlayersGoalkeepers.Rows.Clear();
            foreach (Igrac igrac in IgracImpl.getGoalkeepers())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = igrac
                };
                row.CreateCells(dgvPlayersGoalkeepers,igrac.IDOsobe.Ime + " " + igrac.IDOsobe.Prezime, igrac.BrojDresa);
                dgvPlayersGoalkeepers.Rows.Add(row);
            }

            dgvPlayersGoalkeepers.ClearSelection();
        }

        private void FillGridPlayersDefenders()
        {
            dgvPlayersDefenders.Rows.Clear();
            foreach (Igrac igrac in IgracImpl.getDefenders())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = igrac
                };
                row.CreateCells(dgvPlayersDefenders, igrac.IDOsobe.Ime + " " + igrac.IDOsobe.Prezime, igrac.BrojDresa);
                dgvPlayersDefenders.Rows.Add(row);
            }

            dgvPlayersDefenders.ClearSelection();
        }

        private void FillGridPlayersMidfielders()
        {
            dgvPlayersMidfielders.Rows.Clear();
            foreach (Igrac igrac in IgracImpl.getMidfielders())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = igrac
                };
                row.CreateCells(dgvPlayersMidfielders, igrac.IDOsobe.Ime + " " + igrac.IDOsobe.Prezime, igrac.BrojDresa);
                dgvPlayersMidfielders.Rows.Add(row);
            }

            dgvPlayersMidfielders.ClearSelection();
        }

        private void FillGridPlayersAttackers()
        {
            dgvPlayersAttackers.Rows.Clear();
            foreach (Igrac igrac in IgracImpl.getAttackers())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = igrac
                };
                row.CreateCells(dgvPlayersAttackers, igrac.IDOsobe.Ime + " " + igrac.IDOsobe.Prezime, igrac.BrojDresa);
                dgvPlayersAttackers.Rows.Add(row);
            }

            dgvPlayersAttackers.ClearSelection();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvUsers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPregledIgraca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPregledIgraca.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPregledTrenera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPregledTrenera.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayedMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPlayedMatches.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvScheduledMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvScheduledMatches.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvResultsBySeason_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvResultsBySeason.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvResultsByCompetition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvResultsByCompetition.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvSeasons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSeasons.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvCompetitions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvCompetitions.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvOpponents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvOpponents.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersGoalkeepers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPlayersGoalkeepers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersDefenders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPlayersDefenders.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersMidfielders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPlayersMidfielders.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersAttackers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPlayersAttackers.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
