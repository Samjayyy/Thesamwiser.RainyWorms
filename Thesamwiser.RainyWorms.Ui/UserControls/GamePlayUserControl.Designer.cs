namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    partial class GamePlayUserControl
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
            this.grpSpel = new System.Windows.Forms.GroupBox();
            this.pnlSpel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPlayers = new System.Windows.Forms.TableLayoutPanel();
            this.pnlWorms = new System.Windows.Forms.TableLayoutPanel();
            this.ucPlayDices = new Thesamwiser.RainyWorms.Ui.UserControls.GamePlayDicesUserControl();
            this.grpSpel.SuspendLayout();
            this.pnlSpel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSpel
            // 
            this.grpSpel.BackColor = System.Drawing.Color.Green;
            this.grpSpel.Controls.Add(this.pnlSpel);
            this.grpSpel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSpel.Location = new System.Drawing.Point(0, 0);
            this.grpSpel.Name = "grpSpel";
            this.grpSpel.Size = new System.Drawing.Size(1047, 600);
            this.grpSpel.TabIndex = 0;
            this.grpSpel.TabStop = false;
            this.grpSpel.Text = "Spel";
            // 
            // pnlSpel
            // 
            this.pnlSpel.ColumnCount = 1;
            this.pnlSpel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSpel.Controls.Add(this.pnlPlayers, 0, 0);
            this.pnlSpel.Controls.Add(this.pnlWorms, 0, 1);
            this.pnlSpel.Controls.Add(this.ucPlayDices, 0, 2);
            this.pnlSpel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpel.Location = new System.Drawing.Point(3, 16);
            this.pnlSpel.Name = "pnlSpel";
            this.pnlSpel.RowCount = 3;
            this.pnlSpel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.pnlSpel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlSpel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSpel.Size = new System.Drawing.Size(1041, 581);
            this.pnlSpel.TabIndex = 0;
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.ColumnCount = 1;
            this.pnlPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayers.Location = new System.Drawing.Point(3, 3);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.RowCount = 1;
            this.pnlPlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPlayers.Size = new System.Drawing.Size(1035, 144);
            this.pnlPlayers.TabIndex = 0;
            // 
            // pnlWorms
            // 
            this.pnlWorms.ColumnCount = 1;
            this.pnlWorms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlWorms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlWorms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorms.Location = new System.Drawing.Point(3, 153);
            this.pnlWorms.Name = "pnlWorms";
            this.pnlWorms.RowCount = 1;
            this.pnlWorms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlWorms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlWorms.Size = new System.Drawing.Size(1035, 94);
            this.pnlWorms.TabIndex = 1;
            // 
            // ucPlayDices
            // 
            this.ucPlayDices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayDices.Location = new System.Drawing.Point(3, 253);
            this.ucPlayDices.Name = "ucPlayDices";
            this.ucPlayDices.Size = new System.Drawing.Size(1035, 325);
            this.ucPlayDices.TabIndex = 2;
            // 
            // GamePlayUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSpel);
            this.Name = "GamePlayUserControl";
            this.Size = new System.Drawing.Size(1047, 600);
            this.grpSpel.ResumeLayout(false);
            this.pnlSpel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSpel;
        private System.Windows.Forms.TableLayoutPanel pnlSpel;
        private System.Windows.Forms.TableLayoutPanel pnlPlayers;
        private System.Windows.Forms.TableLayoutPanel pnlWorms;
        private GamePlayDicesUserControl ucPlayDices;
    }
}
