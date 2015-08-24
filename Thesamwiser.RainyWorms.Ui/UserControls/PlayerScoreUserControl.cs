using System.Windows.Forms;
using Thesamwiser.Rainyworms.Domain;
using Thesamwiser.RainyWorms.Ui.Helper;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public partial class PlayerScoreUserControl : UserControl
    {
        public PlayerScoreUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The player for this control
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Check all properties and push them through
        /// </summary>
        public void Repaint(WormBlockUserControl wormUc)
        {
            lblPlayerName.Text = Player.ToString();
            lblScore.Text = Player.TotalWormScore.ToString();
            pnlTopWorm.Controls.ClearAndDispose();
            if (wormUc != null)
            {
                wormUc.Visible = true;
                pnlTopWorm.Controls.Add(wormUc);
            }
        }
    }
}
