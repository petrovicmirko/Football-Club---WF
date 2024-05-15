namespace Football_Club___WF.Forms
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddResultPanel = new System.Windows.Forms.Panel();
            this.AddPlayerOnMatchPanel = new System.Windows.Forms.Panel();
            this.bPotvrdiPlayerOnMatch = new System.Windows.Forms.Button();
            this.tbGoal = new System.Windows.Forms.TextBox();
            this.tbAssist = new System.Windows.Forms.TextBox();
            this.tbRedCard = new System.Windows.Forms.TextBox();
            this.tbYellowCard = new System.Windows.Forms.TextBox();
            this.tbMinutesPlayed = new System.Windows.Forms.TextBox();
            this.cbPlayed = new System.Windows.Forms.CheckBox();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.lbAssists = new System.Windows.Forms.Label();
            this.lbGoals = new System.Windows.Forms.Label();
            this.lbRedCard = new System.Windows.Forms.Label();
            this.lbYellowCard = new System.Windows.Forms.Label();
            this.lbMinutesPlayed = new System.Windows.Forms.Label();
            this.lbInProtocol = new System.Windows.Forms.Label();
            this.bOdustaniPlayerOnMatch = new System.Windows.Forms.Button();
            this.lbPlayerName = new System.Windows.Forms.Label();
            this.bPotvrdiResult = new System.Windows.Forms.Button();
            this.lbScoredGoals = new System.Windows.Forms.Label();
            this.tbGoalsConceded = new System.Windows.Forms.TextBox();
            this.lbResultFirst = new System.Windows.Forms.Label();
            this.lbConcededGoals = new System.Windows.Forms.Label();
            this.tbGoalsScored = new System.Windows.Forms.TextBox();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.lbGuestGoals = new System.Windows.Forms.Label();
            this.lbHostGoals = new System.Windows.Forms.Label();
            this.lbGuest = new System.Windows.Forms.Label();
            this.lbHost = new System.Windows.Forms.Label();
            this.dgvPlayersOnMatch = new System.Windows.Forms.DataGridView();
            this.IDIgraca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUtakmice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igrac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UProtokolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minutaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZutiKarton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrveniKarton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asistencije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golovi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddResultPanel.SuspendLayout();
            this.AddPlayerOnMatchPanel.SuspendLayout();
            this.GamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersOnMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // AddResultPanel
            // 
            resources.ApplyResources(this.AddResultPanel, "AddResultPanel");
            this.AddResultPanel.Controls.Add(this.AddPlayerOnMatchPanel);
            this.AddResultPanel.Controls.Add(this.bPotvrdiResult);
            this.AddResultPanel.Controls.Add(this.lbScoredGoals);
            this.AddResultPanel.Controls.Add(this.tbGoalsConceded);
            this.AddResultPanel.Controls.Add(this.lbResultFirst);
            this.AddResultPanel.Controls.Add(this.lbConcededGoals);
            this.AddResultPanel.Controls.Add(this.tbGoalsScored);
            this.AddResultPanel.Name = "AddResultPanel";
            // 
            // AddPlayerOnMatchPanel
            // 
            this.AddPlayerOnMatchPanel.Controls.Add(this.bPotvrdiPlayerOnMatch);
            this.AddPlayerOnMatchPanel.Controls.Add(this.tbGoal);
            this.AddPlayerOnMatchPanel.Controls.Add(this.tbAssist);
            this.AddPlayerOnMatchPanel.Controls.Add(this.tbRedCard);
            this.AddPlayerOnMatchPanel.Controls.Add(this.tbYellowCard);
            this.AddPlayerOnMatchPanel.Controls.Add(this.tbMinutesPlayed);
            this.AddPlayerOnMatchPanel.Controls.Add(this.cbPlayed);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbPlayer);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbAssists);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbGoals);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbRedCard);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbYellowCard);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbMinutesPlayed);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbInProtocol);
            this.AddPlayerOnMatchPanel.Controls.Add(this.bOdustaniPlayerOnMatch);
            this.AddPlayerOnMatchPanel.Controls.Add(this.lbPlayerName);
            resources.ApplyResources(this.AddPlayerOnMatchPanel, "AddPlayerOnMatchPanel");
            this.AddPlayerOnMatchPanel.Name = "AddPlayerOnMatchPanel";
            // 
            // bPotvrdiPlayerOnMatch
            // 
            this.bPotvrdiPlayerOnMatch.BackColor = System.Drawing.Color.SeaGreen;
            this.bPotvrdiPlayerOnMatch.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.bPotvrdiPlayerOnMatch, "bPotvrdiPlayerOnMatch");
            this.bPotvrdiPlayerOnMatch.Name = "bPotvrdiPlayerOnMatch";
            this.bPotvrdiPlayerOnMatch.UseVisualStyleBackColor = false;
            this.bPotvrdiPlayerOnMatch.Click += new System.EventHandler(this.bPotvrdiPlayerOnMatch_Click);
            // 
            // tbGoal
            // 
            resources.ApplyResources(this.tbGoal, "tbGoal");
            this.tbGoal.Name = "tbGoal";
            this.tbGoal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGoal_KeyPress);
            this.tbGoal.Leave += new System.EventHandler(this.tbGoal_Leave);
            // 
            // tbAssist
            // 
            resources.ApplyResources(this.tbAssist, "tbAssist");
            this.tbAssist.Name = "tbAssist";
            this.tbAssist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAssist_KeyPress);
            this.tbAssist.Leave += new System.EventHandler(this.tbAssist_Leave);
            // 
            // tbRedCard
            // 
            resources.ApplyResources(this.tbRedCard, "tbRedCard");
            this.tbRedCard.Name = "tbRedCard";
            this.tbRedCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRedCard_KeyPress);
            this.tbRedCard.Leave += new System.EventHandler(this.tbRedCard_Leave);
            // 
            // tbYellowCard
            // 
            resources.ApplyResources(this.tbYellowCard, "tbYellowCard");
            this.tbYellowCard.Name = "tbYellowCard";
            this.tbYellowCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbYellowCard_KeyPress);
            this.tbYellowCard.Leave += new System.EventHandler(this.tbYellowCard_Leave);
            // 
            // tbMinutesPlayed
            // 
            resources.ApplyResources(this.tbMinutesPlayed, "tbMinutesPlayed");
            this.tbMinutesPlayed.Name = "tbMinutesPlayed";
            this.tbMinutesPlayed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMinutesPlayed_KeyPress);
            this.tbMinutesPlayed.Leave += new System.EventHandler(this.tbMinutesPlayed_Leave);
            // 
            // cbPlayed
            // 
            resources.ApplyResources(this.cbPlayed, "cbPlayed");
            this.cbPlayed.BackColor = System.Drawing.Color.LimeGreen;
            this.cbPlayed.Checked = true;
            this.cbPlayed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPlayed.Name = "cbPlayed";
            this.cbPlayed.UseVisualStyleBackColor = false;
            this.cbPlayed.CheckedChanged += new System.EventHandler(this.cbPlayed_CheckedChanged);
            // 
            // lbPlayer
            // 
            resources.ApplyResources(this.lbPlayer, "lbPlayer");
            this.lbPlayer.Name = "lbPlayer";
            // 
            // lbAssists
            // 
            resources.ApplyResources(this.lbAssists, "lbAssists");
            this.lbAssists.Name = "lbAssists";
            // 
            // lbGoals
            // 
            resources.ApplyResources(this.lbGoals, "lbGoals");
            this.lbGoals.Name = "lbGoals";
            // 
            // lbRedCard
            // 
            resources.ApplyResources(this.lbRedCard, "lbRedCard");
            this.lbRedCard.Name = "lbRedCard";
            // 
            // lbYellowCard
            // 
            resources.ApplyResources(this.lbYellowCard, "lbYellowCard");
            this.lbYellowCard.Name = "lbYellowCard";
            // 
            // lbMinutesPlayed
            // 
            resources.ApplyResources(this.lbMinutesPlayed, "lbMinutesPlayed");
            this.lbMinutesPlayed.Name = "lbMinutesPlayed";
            // 
            // lbInProtocol
            // 
            resources.ApplyResources(this.lbInProtocol, "lbInProtocol");
            this.lbInProtocol.Name = "lbInProtocol";
            // 
            // bOdustaniPlayerOnMatch
            // 
            this.bOdustaniPlayerOnMatch.BackColor = System.Drawing.Color.SeaGreen;
            this.bOdustaniPlayerOnMatch.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.bOdustaniPlayerOnMatch, "bOdustaniPlayerOnMatch");
            this.bOdustaniPlayerOnMatch.Name = "bOdustaniPlayerOnMatch";
            this.bOdustaniPlayerOnMatch.UseVisualStyleBackColor = false;
            this.bOdustaniPlayerOnMatch.Click += new System.EventHandler(this.bBackPlayerOnMatch_Click);
            // 
            // lbPlayerName
            // 
            resources.ApplyResources(this.lbPlayerName, "lbPlayerName");
            this.lbPlayerName.Name = "lbPlayerName";
            // 
            // bPotvrdiResult
            // 
            this.bPotvrdiResult.BackColor = System.Drawing.Color.SeaGreen;
            this.bPotvrdiResult.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.bPotvrdiResult, "bPotvrdiResult");
            this.bPotvrdiResult.Name = "bPotvrdiResult";
            this.bPotvrdiResult.UseVisualStyleBackColor = false;
            this.bPotvrdiResult.Click += new System.EventHandler(this.bPotvrdiResult_Click);
            // 
            // lbScoredGoals
            // 
            resources.ApplyResources(this.lbScoredGoals, "lbScoredGoals");
            this.lbScoredGoals.Name = "lbScoredGoals";
            // 
            // tbGoalsConceded
            // 
            resources.ApplyResources(this.tbGoalsConceded, "tbGoalsConceded");
            this.tbGoalsConceded.Name = "tbGoalsConceded";
            this.tbGoalsConceded.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGoalsConceded_KeyPress);
            // 
            // lbResultFirst
            // 
            resources.ApplyResources(this.lbResultFirst, "lbResultFirst");
            this.lbResultFirst.Name = "lbResultFirst";
            // 
            // lbConcededGoals
            // 
            resources.ApplyResources(this.lbConcededGoals, "lbConcededGoals");
            this.lbConcededGoals.Name = "lbConcededGoals";
            // 
            // tbGoalsScored
            // 
            resources.ApplyResources(this.tbGoalsScored, "tbGoalsScored");
            this.tbGoalsScored.Name = "tbGoalsScored";
            this.tbGoalsScored.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGoalsScored_KeyPress);
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.AddResultPanel);
            this.GamePanel.Controls.Add(this.lbGuestGoals);
            this.GamePanel.Controls.Add(this.lbHostGoals);
            this.GamePanel.Controls.Add(this.lbGuest);
            this.GamePanel.Controls.Add(this.lbHost);
            this.GamePanel.Controls.Add(this.dgvPlayersOnMatch);
            resources.ApplyResources(this.GamePanel, "GamePanel");
            this.GamePanel.Name = "GamePanel";
            // 
            // lbGuestGoals
            // 
            resources.ApplyResources(this.lbGuestGoals, "lbGuestGoals");
            this.lbGuestGoals.Name = "lbGuestGoals";
            // 
            // lbHostGoals
            // 
            resources.ApplyResources(this.lbHostGoals, "lbHostGoals");
            this.lbHostGoals.Name = "lbHostGoals";
            // 
            // lbGuest
            // 
            resources.ApplyResources(this.lbGuest, "lbGuest");
            this.lbGuest.Name = "lbGuest";
            // 
            // lbHost
            // 
            resources.ApplyResources(this.lbHost, "lbHost");
            this.lbHost.Name = "lbHost";
            // 
            // dgvPlayersOnMatch
            // 
            this.dgvPlayersOnMatch.AllowUserToAddRows = false;
            this.dgvPlayersOnMatch.AllowUserToDeleteRows = false;
            this.dgvPlayersOnMatch.AllowUserToResizeColumns = false;
            this.dgvPlayersOnMatch.AllowUserToResizeRows = false;
            this.dgvPlayersOnMatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayersOnMatch.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.dgvPlayersOnMatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayersOnMatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlayersOnMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayersOnMatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDIgraca,
            this.IDUtakmice,
            this.Igrac,
            this.UProtokolu,
            this.Minutaza,
            this.ZutiKarton,
            this.CrveniKarton,
            this.Asistencije,
            this.Golovi});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlayersOnMatch.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dgvPlayersOnMatch, "dgvPlayersOnMatch");
            this.dgvPlayersOnMatch.MultiSelect = false;
            this.dgvPlayersOnMatch.Name = "dgvPlayersOnMatch";
            this.dgvPlayersOnMatch.ReadOnly = true;
            this.dgvPlayersOnMatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayersOnMatch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayersOnMatch_CellClick);
            // 
            // IDIgraca
            // 
            resources.ApplyResources(this.IDIgraca, "IDIgraca");
            this.IDIgraca.Name = "IDIgraca";
            this.IDIgraca.ReadOnly = true;
            // 
            // IDUtakmice
            // 
            resources.ApplyResources(this.IDUtakmice, "IDUtakmice");
            this.IDUtakmice.Name = "IDUtakmice";
            this.IDUtakmice.ReadOnly = true;
            // 
            // Igrac
            // 
            resources.ApplyResources(this.Igrac, "Igrac");
            this.Igrac.Name = "Igrac";
            this.Igrac.ReadOnly = true;
            // 
            // UProtokolu
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UProtokolu.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.UProtokolu, "UProtokolu");
            this.UProtokolu.Name = "UProtokolu";
            this.UProtokolu.ReadOnly = true;
            // 
            // Minutaza
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Minutaza.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Minutaza, "Minutaza");
            this.Minutaza.Name = "Minutaza";
            this.Minutaza.ReadOnly = true;
            // 
            // ZutiKarton
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ZutiKarton.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.ZutiKarton, "ZutiKarton");
            this.ZutiKarton.Name = "ZutiKarton";
            this.ZutiKarton.ReadOnly = true;
            // 
            // CrveniKarton
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CrveniKarton.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.CrveniKarton, "CrveniKarton");
            this.CrveniKarton.Name = "CrveniKarton";
            this.CrveniKarton.ReadOnly = true;
            // 
            // Asistencije
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Asistencije.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.Asistencije, "Asistencije");
            this.Asistencije.Name = "Asistencije";
            this.Asistencije.ReadOnly = true;
            // 
            // Golovi
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Golovi.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.Golovi, "Golovi");
            this.Golovi.Name = "Golovi";
            this.Golovi.ReadOnly = true;
            // 
            // Game
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.Controls.Add(this.GamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.ShowIcon = false;
            this.Shown += new System.EventHandler(this.Game_Shown);
            this.AddResultPanel.ResumeLayout(false);
            this.AddResultPanel.PerformLayout();
            this.AddPlayerOnMatchPanel.ResumeLayout(false);
            this.AddPlayerOnMatchPanel.PerformLayout();
            this.GamePanel.ResumeLayout(false);
            this.GamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersOnMatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel AddResultPanel;
        private System.Windows.Forms.TextBox tbGoalsConceded;
        private System.Windows.Forms.TextBox tbGoalsScored;
        private System.Windows.Forms.Label lbResultFirst;
        private System.Windows.Forms.Label lbConcededGoals;
        private System.Windows.Forms.Label lbScoredGoals;
        private System.Windows.Forms.Button bPotvrdiResult;
        private System.Windows.Forms.Panel AddPlayerOnMatchPanel;
        private System.Windows.Forms.Label lbPlayerName;
        private System.Windows.Forms.Button bOdustaniPlayerOnMatch;
        private System.Windows.Forms.TextBox tbGoal;
        private System.Windows.Forms.TextBox tbAssist;
        private System.Windows.Forms.TextBox tbRedCard;
        private System.Windows.Forms.TextBox tbYellowCard;
        private System.Windows.Forms.TextBox tbMinutesPlayed;
        private System.Windows.Forms.CheckBox cbPlayed;
        private System.Windows.Forms.Label lbPlayer;
        private System.Windows.Forms.Label lbAssists;
        private System.Windows.Forms.Label lbGoals;
        private System.Windows.Forms.Label lbRedCard;
        private System.Windows.Forms.Label lbYellowCard;
        private System.Windows.Forms.Label lbMinutesPlayed;
        private System.Windows.Forms.Label lbInProtocol;
        private System.Windows.Forms.Button bPotvrdiPlayerOnMatch;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Label lbGuestGoals;
        private System.Windows.Forms.Label lbHostGoals;
        private System.Windows.Forms.Label lbGuest;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.DataGridView dgvPlayersOnMatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDIgraca;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUtakmice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Igrac;
        private System.Windows.Forms.DataGridViewTextBoxColumn UProtokolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minutaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZutiKarton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrveniKarton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asistencije;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golovi;
    }
}