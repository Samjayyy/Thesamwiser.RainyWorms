namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    partial class PlayerScoreUserControl
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
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.pnlTopWorm = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(-1, 13);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(111, 19);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Naam speler";
            // 
            // pnlTopWorm
            // 
            this.pnlTopWorm.Location = new System.Drawing.Point(3, 35);
            this.pnlTopWorm.Name = "pnlTopWorm";
            this.pnlTopWorm.Size = new System.Drawing.Size(111, 63);
            this.pnlTopWorm.TabIndex = 1;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(101, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 13);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            // 
            // PlayerScoreUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pnlTopWorm);
            this.Controls.Add(this.lblPlayerName);
            this.MinimumSize = new System.Drawing.Size(85, 100);
            this.Name = "PlayerScoreUserControl";
            this.Size = new System.Drawing.Size(117, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Panel pnlTopWorm;
        private System.Windows.Forms.Label lblScore;
    }
}
