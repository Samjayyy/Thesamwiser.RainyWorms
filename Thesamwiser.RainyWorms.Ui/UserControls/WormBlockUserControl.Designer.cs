namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    partial class WormBlockUserControl
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
            this.bsWorm = new System.Windows.Forms.BindingSource(this.components);
            this.lblThrowValue = new System.Windows.Forms.Label();
            this.lblWormValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsWorm)).BeginInit();
            this.SuspendLayout();
            // 
            // bsWorm
            // 
            this.bsWorm.DataSource = typeof(Thesamwiser.Rainyworms.Domain.RainyWorm);
            // 
            // lblThrowValue
            // 
            this.lblThrowValue.AutoEllipsis = true;
            this.lblThrowValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblThrowValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThrowValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWorm, "ThrowValue", true));
            this.lblThrowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThrowValue.Location = new System.Drawing.Point(33, 27);
            this.lblThrowValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblThrowValue.Name = "lblThrowValue";
            this.lblThrowValue.Size = new System.Drawing.Size(39, 23);
            this.lblThrowValue.TabIndex = 0;
            this.lblThrowValue.Text = "30";
            this.lblThrowValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWormValue
            // 
            this.lblWormValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWormValue.AutoEllipsis = true;
            this.lblWormValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblWormValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWormValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsWorm, "WormValue", true));
            this.lblWormValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWormValue.Location = new System.Drawing.Point(67, 0);
            this.lblWormValue.Name = "lblWormValue";
            this.lblWormValue.Size = new System.Drawing.Size(19, 19);
            this.lblWormValue.TabIndex = 1;
            this.lblWormValue.Text = "3";
            // 
            // WormBlockUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Thesamwiser.RainyWorms.Ui.Properties.Resources.worm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblWormValue);
            this.Controls.Add(this.lblThrowValue);
            this.MaximumSize = new System.Drawing.Size(100, 80);
            this.MinimumSize = new System.Drawing.Size(88, 70);
            this.Name = "WormBlockUserControl";
            this.Size = new System.Drawing.Size(86, 68);
            this.Click += new System.EventHandler(this.WormBlockUserControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.bsWorm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsWorm;
        private System.Windows.Forms.Label lblThrowValue;
        private System.Windows.Forms.Label lblWormValue;
    }
}
