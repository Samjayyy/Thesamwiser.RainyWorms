namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    partial class GamePlayDicesUserControl
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
            this.pnlDicePlay = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTaken = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlToThrow = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThrow = new System.Windows.Forms.Button();
            this.pnlCurrentPlayer = new System.Windows.Forms.Panel();
            this.lblCurrentTotal = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.pnlDicePlay.SuspendLayout();
            this.pnlCurrentPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDicePlay
            // 
            this.pnlDicePlay.ColumnCount = 2;
            this.pnlDicePlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDicePlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.pnlDicePlay.Controls.Add(this.pnlTaken, 0, 1);
            this.pnlDicePlay.Controls.Add(this.pnlToThrow, 0, 0);
            this.pnlDicePlay.Controls.Add(this.btnThrow, 1, 0);
            this.pnlDicePlay.Controls.Add(this.pnlCurrentPlayer, 1, 1);
            this.pnlDicePlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDicePlay.Location = new System.Drawing.Point(0, 0);
            this.pnlDicePlay.Name = "pnlDicePlay";
            this.pnlDicePlay.RowCount = 2;
            this.pnlDicePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlDicePlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlDicePlay.Size = new System.Drawing.Size(911, 354);
            this.pnlDicePlay.TabIndex = 0;
            // 
            // pnlTaken
            // 
            this.pnlTaken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTaken.Location = new System.Drawing.Point(3, 180);
            this.pnlTaken.Name = "pnlTaken";
            this.pnlTaken.Size = new System.Drawing.Size(755, 171);
            this.pnlTaken.TabIndex = 0;
            // 
            // pnlToThrow
            // 
            this.pnlToThrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToThrow.Location = new System.Drawing.Point(3, 3);
            this.pnlToThrow.Name = "pnlToThrow";
            this.pnlToThrow.Size = new System.Drawing.Size(755, 171);
            this.pnlToThrow.TabIndex = 1;
            // 
            // btnThrow
            // 
            this.btnThrow.AutoEllipsis = true;
            this.btnThrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThrow.Location = new System.Drawing.Point(764, 3);
            this.btnThrow.Name = "btnThrow";
            this.btnThrow.Size = new System.Drawing.Size(144, 171);
            this.btnThrow.TabIndex = 2;
            this.btnThrow.Text = "Gooi";
            this.btnThrow.UseVisualStyleBackColor = true;
            this.btnThrow.Click += new System.EventHandler(this.btnThrow_Click);
            // 
            // pnlCurrentPlayer
            // 
            this.pnlCurrentPlayer.Controls.Add(this.lblCurrentTotal);
            this.pnlCurrentPlayer.Controls.Add(this.lblPlayerName);
            this.pnlCurrentPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCurrentPlayer.Location = new System.Drawing.Point(764, 180);
            this.pnlCurrentPlayer.Name = "pnlCurrentPlayer";
            this.pnlCurrentPlayer.Size = new System.Drawing.Size(144, 171);
            this.pnlCurrentPlayer.TabIndex = 3;
            // 
            // lblCurrentTotal
            // 
            this.lblCurrentTotal.AutoSize = true;
            this.lblCurrentTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTotal.Location = new System.Drawing.Point(51, 72);
            this.lblCurrentTotal.Name = "lblCurrentTotal";
            this.lblCurrentTotal.Size = new System.Drawing.Size(27, 29);
            this.lblCurrentTotal.TabIndex = 1;
            this.lblCurrentTotal.Text = "0";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(15, 27);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(111, 19);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Naam speler";
            // 
            // GamePlayDicesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDicePlay);
            this.Name = "GamePlayDicesUserControl";
            this.Size = new System.Drawing.Size(911, 354);
            this.pnlDicePlay.ResumeLayout(false);
            this.pnlCurrentPlayer.ResumeLayout(false);
            this.pnlCurrentPlayer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlDicePlay;
        private System.Windows.Forms.FlowLayoutPanel pnlTaken;
        private System.Windows.Forms.FlowLayoutPanel pnlToThrow;
        private System.Windows.Forms.Button btnThrow;
        private System.Windows.Forms.Panel pnlCurrentPlayer;
        private System.Windows.Forms.Label lblCurrentTotal;
        private System.Windows.Forms.Label lblPlayerName;
    }
}
