namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    partial class ConfigurationUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpInstellingen = new System.Windows.Forms.GroupBox();
            this.lblVerdeling = new System.Windows.Forms.Label();
            this.cboVerdelingStart = new System.Windows.Forms.ComboBox();
            this.bsConfig = new System.Windows.Forms.BindingSource(this.components);
            this.bsVerdelingStartOpties = new System.Windows.Forms.BindingSource(this.components);
            this.chkShouldSortThrown = new System.Windows.Forms.CheckBox();
            this.chkShouldSortTaken = new System.Windows.Forms.CheckBox();
            this.grpSpelers = new System.Windows.Forms.GroupBox();
            this.grdSpelers = new System.Windows.Forms.DataGridView();
            this.coltxtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchkIsPlaying = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colchkIsHuman = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsConfiguredPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.grpInstellingen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVerdelingStartOpties)).BeginInit();
            this.grpSpelers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpelers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfiguredPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInstellingen
            // 
            this.grpInstellingen.Controls.Add(this.lblVerdeling);
            this.grpInstellingen.Controls.Add(this.cboVerdelingStart);
            this.grpInstellingen.Controls.Add(this.chkShouldSortThrown);
            this.grpInstellingen.Controls.Add(this.chkShouldSortTaken);
            this.grpInstellingen.Controls.Add(this.grpSpelers);
            this.grpInstellingen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInstellingen.Location = new System.Drawing.Point(0, 0);
            this.grpInstellingen.Name = "grpInstellingen";
            this.grpInstellingen.Size = new System.Drawing.Size(603, 403);
            this.grpInstellingen.TabIndex = 0;
            this.grpInstellingen.TabStop = false;
            this.grpInstellingen.Text = "Instellingen";
            // 
            // lblVerdeling
            // 
            this.lblVerdeling.AutoSize = true;
            this.lblVerdeling.Location = new System.Drawing.Point(3, 117);
            this.lblVerdeling.Name = "lblVerdeling";
            this.lblVerdeling.Size = new System.Drawing.Size(77, 13);
            this.lblVerdeling.TabIndex = 5;
            this.lblVerdeling.Text = "Verdeling start:";
            // 
            // cboVerdelingStart
            // 
            this.cboVerdelingStart.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsConfig, "DecidePlayerSequence", true));
            this.cboVerdelingStart.DataSource = this.bsVerdelingStartOpties;
            this.cboVerdelingStart.DisplayMember = "Name";
            this.cboVerdelingStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVerdelingStart.FormattingEnabled = true;
            this.cboVerdelingStart.Location = new System.Drawing.Point(6, 133);
            this.cboVerdelingStart.Name = "cboVerdelingStart";
            this.cboVerdelingStart.Size = new System.Drawing.Size(179, 21);
            this.cboVerdelingStart.TabIndex = 4;
            // 
            // bsConfig
            // 
            this.bsConfig.DataSource = typeof(Thesamwiser.Rainyworms.Domain.GameConfiguration);
            // 
            // bsVerdelingStartOpties
            // 
            this.bsVerdelingStartOpties.DataSource = typeof(Thesamwiser.Rainyworms.Domain.PlayerSequenceDeterminator);
            // 
            // chkShouldSortThrown
            // 
            this.chkShouldSortThrown.AutoSize = true;
            this.chkShouldSortThrown.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsConfig, "ShouldSortThrownDice", true));
            this.chkShouldSortThrown.Location = new System.Drawing.Point(6, 73);
            this.chkShouldSortThrown.Name = "chkShouldSortThrown";
            this.chkShouldSortThrown.Size = new System.Drawing.Size(177, 17);
            this.chkShouldSortThrown.TabIndex = 3;
            this.chkShouldSortThrown.Text = "Sorteer dobbelstenen na gooien";
            this.chkShouldSortThrown.UseVisualStyleBackColor = true;
            // 
            // chkShouldSortTaken
            // 
            this.chkShouldSortTaken.AutoSize = true;
            this.chkShouldSortTaken.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsConfig, "ShouldSortTakenDice", true));
            this.chkShouldSortTaken.Location = new System.Drawing.Point(6, 35);
            this.chkShouldSortTaken.Name = "chkShouldSortTaken";
            this.chkShouldSortTaken.Size = new System.Drawing.Size(177, 17);
            this.chkShouldSortTaken.TabIndex = 2;
            this.chkShouldSortTaken.Text = "Sorteer dobbelstenen na nemen";
            this.chkShouldSortTaken.UseVisualStyleBackColor = true;
            // 
            // grpSpelers
            // 
            this.grpSpelers.Controls.Add(this.grdSpelers);
            this.grpSpelers.Location = new System.Drawing.Point(200, 19);
            this.grpSpelers.Name = "grpSpelers";
            this.grpSpelers.Size = new System.Drawing.Size(403, 196);
            this.grpSpelers.TabIndex = 1;
            this.grpSpelers.TabStop = false;
            this.grpSpelers.Text = "Spelers";
            // 
            // grdSpelers
            // 
            this.grdSpelers.AllowUserToAddRows = false;
            this.grdSpelers.AllowUserToDeleteRows = false;
            this.grdSpelers.AllowUserToOrderColumns = true;
            this.grdSpelers.AutoGenerateColumns = false;
            this.grdSpelers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSpelers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coltxtName,
            this.colchkIsPlaying,
            this.colchkIsHuman});
            this.grdSpelers.DataSource = this.bsConfiguredPlayers;
            this.grdSpelers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSpelers.Location = new System.Drawing.Point(3, 16);
            this.grdSpelers.Name = "grdSpelers";
            this.grdSpelers.Size = new System.Drawing.Size(397, 177);
            this.grdSpelers.TabIndex = 0;
            // 
            // coltxtName
            // 
            this.coltxtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coltxtName.DataPropertyName = "Name";
            this.coltxtName.HeaderText = "Speler";
            this.coltxtName.MaxInputLength = 50;
            this.coltxtName.Name = "coltxtName";
            // 
            // colchkIsPlaying
            // 
            this.colchkIsPlaying.DataPropertyName = "IsPlaying";
            this.colchkIsPlaying.HeaderText = "Speelt mee?";
            this.colchkIsPlaying.Name = "colchkIsPlaying";
            // 
            // colchkIsHuman
            // 
            this.colchkIsHuman.DataPropertyName = "IsHuman";
            this.colchkIsHuman.HeaderText = "Is mens?";
            this.colchkIsHuman.Name = "colchkIsHuman";
            // 
            // bsConfiguredPlayers
            // 
            this.bsConfiguredPlayers.DataMember = "Players";
            this.bsConfiguredPlayers.DataSource = this.bsConfig;
            // 
            // ConfigurationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grpInstellingen);
            this.Name = "ConfigurationUserControl";
            this.Size = new System.Drawing.Size(603, 403);
            this.grpInstellingen.ResumeLayout(false);
            this.grpInstellingen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVerdelingStartOpties)).EndInit();
            this.grpSpelers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSpelers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfiguredPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInstellingen;
        private System.Windows.Forms.DataGridView grdSpelers;
        private System.Windows.Forms.BindingSource bsConfiguredPlayers;
        private System.Windows.Forms.BindingSource bsConfig;
        private System.Windows.Forms.GroupBox grpSpelers;
        private System.Windows.Forms.CheckBox chkShouldSortThrown;
        private System.Windows.Forms.CheckBox chkShouldSortTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltxtName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colchkIsPlaying;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colchkIsHuman;
        private System.Windows.Forms.Label lblVerdeling;
        private System.Windows.Forms.ComboBox cboVerdelingStart;
        private System.Windows.Forms.BindingSource bsVerdelingStartOpties;
    }
}
