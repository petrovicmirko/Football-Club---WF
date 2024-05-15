using System;
using System.Globalization;
using System.Resources;
using System.Reflection;
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

namespace Football_Club___WF.Forms
{
    public partial class HomePage : Form
    {
        private static Color BACK_COLOR;
        private static Color BUTTON_COLOR;

        private string username;

        private string LANGUAGE;

        public HomePage()
        {
            LANGUAGE = "sr-Latn";

            InitializeComponent();

            LoginPanel.Visible = true;
            RegistrationPanel.Visible = false;
            HomePagePanel.Visible = false;  
            PlayersPanel.Visible = false;

            SetLanguage("sr-Latn");
        }

        public string selectedSeason;
        public string selectedCompetition;

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

                    PlayersPanel.Visible = false;
                    HomePagePanel.Visible = false;
                }
            }
            else if(LANGUAGE.Equals("en"))
            {
                DialogResult result = MessageBox.Show("Do you really want to logout?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SetLanguage("sr-Latn");
                    rbSerbian.Checked = true;

                    PlayersPanel.Visible = false;
                    HomePagePanel.Visible = false;
                }
            }
            
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            List<Korisnik> korisnici = KorisnikImpl.getKorisnici();
            bool flag = false;

            foreach (Korisnik korisnik in korisnici)
            {
                if (tbKorisnickoIme.Text.Equals(korisnik.KorisnickoIme))
                {
                    tbKorisnickoIme.Text = korisnik.KorisnickoIme;
                    flag = true;
                    if (tbLozinka.Text.Equals(korisnik.Lozinka))
                    {
                        tbKorisnickoIme.Text = "";
                        tbLozinka.Text = "";
                        if(korisnik.Uloga == true)
                        {
                            new AdminPage(korisnik.KorisnickoIme).ShowDialog();
                            break;
                        }
                        else
                        {
                            username = korisnik.KorisnickoIme;
                            ChangeControlColors(this.Controls);
                            HomePagePanel.Visible = true; 
                        }
                    }
                    else
                    {
                        /*
                        if (LANGUAGE.Equals("sr-Latn"))
                        {
                            MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (LANGUAGE.Equals("en"))
                        {
                            MessageBox.Show("Wrong username or password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }*/

                        MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        tbKorisnickoIme.Text = "";
                        tbLozinka.Text = "";
                        tbKorisnickoIme.Focus();
                    }
                }
            }
            if (!flag)
            {
                /*
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("Wrong username or password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

                MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbKorisnickoIme.Text = "";
                tbLozinka.Text = "";
                tbKorisnickoIme.Focus();
            }
        }

        private void HomePage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                bLogin.PerformClick();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = true;
            RegistrationPanel.Visible = false;
            HomePagePanel.Visible = false;

            tbName.Text = "";
            tbLastname.Text = "";
            tbUsername.Text = "";
            tbPassword.Text = "";
        }

        private void bIgraci_Click(object sender, EventArgs e)
        {
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

            bNazadPlayers.Visible = false;
        }

        private void bTreneri_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = false;
            StatisticsPanel.Visible = false;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            FillGridCoaches();
        }

        private void bUtakmice_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = false;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            FillGridPlayedMatches();
            FillGridScheduledMatches();

            bSeeDetails.Enabled = false;

            dgvScheduledMatches.Columns["TerminZakazane"].DefaultCellStyle.Format = "dd.MM.yy.   HH.mm";
            dgvPlayedMatches.Columns["TerminOdigrane"].DefaultCellStyle.Format = "dd.MM.yy.   HH.mm";

            dgvPlayedMatches.Visible = true;
            dgvScheduledMatches.Visible = false;

            bPlayedMatches.PerformClick();
        }

        private void bStatistika_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = true;
            AboutClubPanel.Visible = false;
            SettingsPanel.Visible = false;

            cbSeasons.SelectedIndex = cbSeasons.Items.Count - 1;
            cbCompetitions.SelectedIndex = cbCompetitions.Items.Count - 1;

            bBySeason.PerformClick();
        }

        private void bKlub_Click(object sender, EventArgs e)
        {
            PlayersPanel.Visible = true;
            CoachesPanel.Visible = true;
            MatchesPanel.Visible = true;
            StatisticsPanel.Visible = true;
            AboutClubPanel.Visible = true;
            SettingsPanel.Visible = false;

            FillAboutClub();
        }

        private void bPlayedMatches_Click(object sender, EventArgs e)
        {
            dgvPlayedMatches.Visible = true;
            dgvScheduledMatches.Visible = false;
            bPlayedMatches.FlatStyle = FlatStyle.Popup;
            bScheduledMatches.FlatStyle = FlatStyle.System;

            bSeeDetails.Visible = true;

            FillGridPlayedMatches();

            dgvPlayedMatches.Sort(dgvPlayedMatches.Columns["TerminOdigrane"], System.ComponentModel.ListSortDirection.Descending);
            
            bSeeDetails.Enabled = false;
        }

        private void bScheduledMatches_Click(object sender, EventArgs e)
        {
            dgvPlayedMatches.Visible = false;
            dgvScheduledMatches.Visible = true;
            bScheduledMatches.FlatStyle = FlatStyle.Popup;
            bPlayedMatches.FlatStyle = FlatStyle.System;

            bSeeDetails.Visible = false;

            FillGridScheduledMatches();

            dgvScheduledMatches.Sort(dgvScheduledMatches.Columns["TerminZakazane"], System.ComponentModel.ListSortDirection.Ascending);

            dgvScheduledMatches.ClearSelection();
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

        private void FillGridPlayedMatches()
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
                    lbNazivKluba.Text = reader.GetString(1);
                    DateTime datum = reader.GetDateTime(2);
                    lbDatumOsnivanja.Text = datum.ToString("dd.MM.yyyy.");
                    lbGrad.Text = reader.GetString(3);
                    lbStadion.Text = reader.GetString(4);
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void bByCompetition_Click(object sender, EventArgs e)
        {
            bByCompetition.FlatStyle = FlatStyle.Popup;
            bBySeason.FlatStyle = FlatStyle.System;

            dgvRezultatiPoSezoni.Visible = false;
            dgvRezultatiPoTakmicenju.Visible = true;

            cbSeasons.Visible = false;
            cbCompetitions.Visible = true;

            lbIzaberiSezonu.Visible = false;
            lbIzaberiTakmicenje.Visible = true;

            LoadDataIntoCBCompetitions();

            cbCompetitions.SelectedIndex = cbCompetitions.Items.Count - 1;

            cbCompetitions.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void bBySeason_Click(object sender, EventArgs e)
        {
            bBySeason.FlatStyle = FlatStyle.Popup;
            bByCompetition.FlatStyle = FlatStyle.System;

            dgvRezultatiPoSezoni.Visible = true;
            dgvRezultatiPoTakmicenju.Visible = false;

            cbSeasons.Visible = true;
            cbCompetitions.Visible = false;

            lbIzaberiSezonu.Visible = true;
            lbIzaberiTakmicenje.Visible = false;

            LoadDataIntoCBSeasons();

            cbSeasons.SelectedIndex = cbSeasons.Items.Count - 1;

            cbSeasons.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void FillBySeason(string Sezona)
        {
            string SELECT_REZULTATI_PO_SEZONI = "SELECT Takmicenje, Uspjeh FROM TAKMICENJA_PO_SEZONAMA_INFO WHERE Sezona = '";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                dgvRezultatiPoSezoni.Rows.Clear();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_REZULTATI_PO_SEZONI + Sezona + "';";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvRezultatiPoSezoni, reader.GetString(0), reader.GetString(1));
                    dgvRezultatiPoSezoni.Rows.Add(row);
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

            dgvRezultatiPoSezoni.ClearSelection();
        }
        public void FillByCompetition(string Takmicenje)
        {
            string SELECT_REZULTATI_PO_TAKMICENJU = "SELECT Sezona, Uspjeh FROM TAKMICENJA_PO_SEZONAMA_INFO WHERE Takmicenje = '";

            MySqlConnection conn = new MySqlConnection(MyConnection.connectionString);
            conn.Open();
            try
            {
                dgvRezultatiPoTakmicenju.Rows.Clear();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_REZULTATI_PO_TAKMICENJU + Takmicenje + "';";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvRezultatiPoTakmicenju, reader.GetString(0), reader.GetString(1));
                    dgvRezultatiPoTakmicenju.Rows.Add(row);
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

            dgvRezultatiPoTakmicenju.ClearSelection();
        }

        public void LoadDataIntoCBSeasons()
        {
            cbSeasons.Items.Clear();
            cbSeasons.DisplayMember = "NazivSezone";
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
        public void LoadDataIntoCBCompetitions()
        {
            cbCompetitions.Items.Clear();
            cbCompetitions.DisplayMember = "NazivTakmicenja";
            foreach (Takmicenje takmicenje in TakmicenjeImpl.getTakmicenja())
            {
                cbCompetitions.Items.Add(takmicenje);
            }
        }

        private void cbCompetitions_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (cbCompetitions.SelectedItem != null)
            {
                selectedCompetition = cbCompetitions.Text;
            }
            FillByCompetition(selectedCompetition);
        }

        private void bCreateNewAccount_Click(object sender, EventArgs e)
        {
            tbKorisnickoIme.Text = "";
            tbLozinka.Text = "";

            RegistrationPanel.Visible = true;
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void bPotvrdiRegistration_Click(object sender, EventArgs e)
        {
            if (!tbName.Text.Equals("") && !tbLastname.Text.Equals("") && !tbUsername.Text.Equals("") && !tbPassword.Text.Equals(""))
            {
                if(!KorisnikImpl.IsUsernameExists(tbUsername.Text))
                {
                    KorisnikImpl.insertKorisnik(tbName.Text, tbLastname.Text, "-", tbUsername.Text, tbPassword.Text, false, 1);

                    if (LANGUAGE.Equals("sr-Latn"))
                    {
                        MessageBox.Show("Uspješno ste se registrovali!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (LANGUAGE.Equals("en"))
                    {
                        MessageBox.Show("You have successfully registered!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    

                    tbName.Text = "";
                    tbLastname.Text = "";
                    tbUsername.Text = "";
                    tbPassword.Text = "";

                    RegistrationPanel.Visible = false;
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
                    
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    tbUsername.Focus();
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

        private void ChangeControlColors(Control.ControlCollection controls)
        {
            if(KorisnikImpl.GetThemeForUsername(username) == 1)
            {
                BACK_COLOR = ColorTranslator.FromHtml("#32CD32");
                BUTTON_COLOR = ColorTranslator.FromHtml("#98FB98");
            }
            else if(KorisnikImpl.GetThemeForUsername(username) == 2)
            {
                BACK_COLOR = ColorTranslator.FromHtml("#6984BF");
                BUTTON_COLOR = ColorTranslator.FromHtml("#87CEEB");
            }
            else if(KorisnikImpl.GetThemeForUsername(username) == 3)
            {
                BACK_COLOR = ColorTranslator.FromHtml("#B32E2E");
                BUTTON_COLOR = ColorTranslator.FromHtml("#F08080");
            }

            foreach (Control control in controls)
            {
                if (control is Panel)
                {
                    if(control.Name != "LoginPanel" && control.Name != "RegistrationPanel")
                    {
                        control.BackColor = BACK_COLOR;
                    }

                    
                }
                else if (control is DataGridView)
                {
                    DataGridView dataGridView = (DataGridView)control;
                    dataGridView.BackgroundColor = BACK_COLOR;
                }
                else if (control is Button)
                {
                    if(control.Name != "bLogin" && control.Name != "bCreateNewAccount" && control.Name != "bCancel" && control.Name != "bPotvrdiRegistration")
                    {
                        Button button = (Button)control;
                        button.BackColor = BUTTON_COLOR;
                    }

                    if(control.Name == "bLogout")
                    {
                        Button button = (Button)control;
                        button.BackColor = Color.Gray;
                    }
                }
                else if(control is RadioButton)
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

            if (KorisnikImpl.GetThemeForUsername(username) == 1)
            {
                rbDefaultTheme.Checked = true;
            }
            else if (KorisnikImpl.GetThemeForUsername(username) == 2)
            {
                rbBlueTheme.Checked = true;
            }
            else if(KorisnikImpl.GetThemeForUsername(username) == 3)
            {
                rbRedTheme.Checked = true;
            }
        }

        private void pbSettings_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pbSettings_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void rbDefaultTheme_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikImpl.ChangeTheme(username, 1);
            ChangeControlColors(this.Controls);
        }

        private void rbBlueTheme_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikImpl.ChangeTheme(username, 2);
            ChangeControlColors(this.Controls);
        }

        private void rbRedTheme_CheckedChanged(object sender, EventArgs e)
        {
            KorisnikImpl.ChangeTheme(username, 3);
            ChangeControlColors(this.Controls);
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

        private void SetLanguage(string lang)
        {
            LANGUAGE = lang;
            
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(HomePage));
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
                new Game(IDUtakmice, protivnik, rezultat, domacinIliGost, isConfirmed, username, LANGUAGE).ShowDialog();
            }
            else
            {
                if (LANGUAGE.Equals("sr-Latn"))
                {
                    MessageBox.Show("Utakmica nije potvrđena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (LANGUAGE.Equals("en"))
                {
                    MessageBox.Show("The match is not confirmed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                bPlayedMatches.PerformClick();
            }
        }

        private void dgvPlayedMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlayedMatches.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPlayedMatches.SelectedRows[0];
                string value = selectedRow.Cells["Rezultat"].Value.ToString();

                if(!value.Equals("  -  "))
                {
                    bSeeDetails.Enabled = true;
                }
                else
                {
                    bSeeDetails.Enabled = false;
                }
                
            }
            else
            {
                bSeeDetails.Enabled = false;
            }
        }

        private void bPlayersGoalkeepers_Click(object sender, EventArgs e)
        {
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
            bIgraci.PerformClick();
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
                row.CreateCells(dgvPlayersGoalkeepers, igrac.IDOsobe.Ime + " " + igrac.IDOsobe.Prezime, igrac.BrojDresa);
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

        private void dgvRezultatiPoTakmicenju_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvRezultatiPoTakmicenju.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvRezultatiPoSezoni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvRezultatiPoSezoni.Rows[e.RowIndex].Selected = true;
            }
        }
        
        private void dgvPlayersGoalkeepers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlayersGoalkeepers.ClearSelection();

            if (e.RowIndex >= 0)
            {
                dgvPlayersGoalkeepers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersDefenders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlayersDefenders.ClearSelection();

            if (e.RowIndex >= 0)
            {
                dgvPlayersDefenders.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersMidfielders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlayersMidfielders.ClearSelection();

            if (e.RowIndex >= 0)
            {
                dgvPlayersMidfielders.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvPlayersAttackers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlayersAttackers.ClearSelection();

            if (e.RowIndex >= 0)
            {
                dgvPlayersAttackers.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
