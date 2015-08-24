using System;
using System.Windows.Forms;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public partial class WormBlockUserControl : UserControl
    {
        private RainyWorm _rainyWorm;
        public WormBlockUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zet de te tonen worm
        /// </summary>
        public RainyWorm RainyWorm
        {
            get
            {
                return _rainyWorm;
            }
            set
            {
                _rainyWorm = value;
                if (_rainyWorm == null)
                {
                    bsWorm.DataSource = typeof(RainyWorm);
                }
                else
                {
                    bsWorm.DataSource = _rainyWorm;
                }
            }
        }

        /// <summary>
        /// Action to perform when dice is clicked
        /// Returns true if click action was valid
        /// </summary>
        public Func<RainyWorm, bool> ClickFunc { get; set; }
        
        /// <summary>
        /// React on a click on a worm, when set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WormBlockUserControl_Click(object sender, EventArgs e)
        {
            if (ClickFunc == null)
            {
                return; // no click action set, so do nothing
            }
            ClickFunc(_rainyWorm);
        }
    }
}
