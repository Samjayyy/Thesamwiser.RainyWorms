using System;
using System.Drawing;
using System.Windows.Forms;
using Thesamwiser.Rainyworms.Domain;
using Thesamwiser.RainyWorms.Ui.Properties;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public partial class DiceUserControl : UserControl
    {
        private RainyDice _rainyDice;

        public DiceUserControl()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
            Binding bind = new Binding("BackgroundImage", bsDice, "LastThrowDiceValue");
            bind.Format += (s, e) => {
                e.Value = dices[((e.Value as RainyDiceValue) != null ? (e.Value as RainyDiceValue).SequenceNumber : 6)];
            };
            DataBindings.Add(bind);
        }

        /// <summary>
        /// In this way we can determine fast which image to use
        /// </summary>
        private readonly Bitmap[] dices = new Bitmap[]
        {
            Resources.dice1,
            Resources.dice2,
            Resources.dice3,
            Resources.dice4,
            Resources.dice5,
            Resources.worm,
            Resources.question
        };


        /// <summary>
        /// Set/Get the rainy dice
        /// </summary>
        public RainyDice RainyDice
        {
            get
            {
                return _rainyDice;
            }
            set
            {
                _rainyDice = value;
                if(_rainyDice == null)
                {
                    bsDice.DataSource = typeof(RainyDice);
                }
                else
                {
                    bsDice.DataSource = _rainyDice;
                }
            }
        }

        /// <summary>
        /// Action to perform when dice is clicked
        /// Returns true if click action was valid
        /// </summary>
        public Func<RainyDice, bool> ClickFunc { get; set; }

        /// <summary>
        /// Execute set clickaction set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiceUserControl_Click(object sender, EventArgs e)
        {
            if(ClickFunc == null)
            {
                return; // no click action set, so do nothing
            }
            ClickFunc(_rainyDice);
        }
    }
}
