namespace Thesamwiser.RainyWorms.Ui
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.mnuGame = new System.Windows.Forms.MenuStrip();
            this.tsmGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGameStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGameAfsluiten = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlActiveUserControl = new System.Windows.Forms.Panel();
            this.tsmInstellingen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuGame
            // 
            this.mnuGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGame});
            this.mnuGame.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuGame.Location = new System.Drawing.Point(0, 0);
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.Size = new System.Drawing.Size(984, 24);
            this.mnuGame.TabIndex = 0;
            this.mnuGame.Text = "GameMenu";
            this.mnuGame.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // tsmGame
            // 
            this.tsmGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmInstellingen,
            this.tsmGameStart,
            this.tsmGameAfsluiten});
            this.tsmGame.Name = "tsmGame";
            this.tsmGame.ShortcutKeyDisplayString = "G";
            this.tsmGame.Size = new System.Drawing.Size(50, 20);
            this.tsmGame.Text = "Game";
            this.tsmGame.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tsmGameStart
            // 
            this.tsmGameStart.Name = "tsmGameStart";
            this.tsmGameStart.Size = new System.Drawing.Size(152, 22);
            this.tsmGameStart.Text = "Start";
            this.tsmGameStart.Click += new System.EventHandler(this.tsmGameStart_Click);
            // 
            // tsmGameAfsluiten
            // 
            this.tsmGameAfsluiten.Name = "tsmGameAfsluiten";
            this.tsmGameAfsluiten.Size = new System.Drawing.Size(152, 22);
            this.tsmGameAfsluiten.Text = "Afsluiten";
            this.tsmGameAfsluiten.Click += new System.EventHandler(this.tsmGameAfsluiten_Click);
            // 
            // pnlActiveUserControl
            // 
            this.pnlActiveUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActiveUserControl.Location = new System.Drawing.Point(0, 24);
            this.pnlActiveUserControl.MinimumSize = new System.Drawing.Size(500, 300);
            this.pnlActiveUserControl.Name = "pnlActiveUserControl";
            this.pnlActiveUserControl.Size = new System.Drawing.Size(984, 537);
            this.pnlActiveUserControl.TabIndex = 1;
            // 
            // tsmInstellingen
            // 
            this.tsmInstellingen.Name = "tsmInstellingen";
            this.tsmInstellingen.Size = new System.Drawing.Size(152, 22);
            this.tsmInstellingen.Text = "Instellingen";
            this.tsmInstellingen.Click += new System.EventHandler(this.tsmInstellingen_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnlActiveUserControl);
            this.Controls.Add(this.mnuGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuGame;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "GameForm";
            this.Text = "Rainy Worms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.mnuGame.ResumeLayout(false);
            this.mnuGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuGame;
        private System.Windows.Forms.ToolStripMenuItem tsmGame;
        private System.Windows.Forms.ToolStripMenuItem tsmGameStart;
        private System.Windows.Forms.ToolStripMenuItem tsmGameAfsluiten;
        private System.Windows.Forms.Panel pnlActiveUserControl;
        private System.Windows.Forms.ToolStripMenuItem tsmInstellingen;
    }
}

