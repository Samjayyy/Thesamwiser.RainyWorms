using System;
using System.Windows.Forms;
using Thesamwiser.Rainyworms.Business;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public partial class GamePlayDicesUserControl : UserControl
    {       
        public GamePlayDicesUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The current gameflow
        /// </summary>
        public GameFlow GameFlow { get; set; }

        /// <summary>
        /// Current throw flow
        /// </summary>
        public ThrowFlow CurrentThrowFlow
        {
            get { return GameFlow?.CurrentTurn; }
        }

        /// <summary>
        /// Repaint all user controls according to the current data
        /// </summary>
        public void Repaint()
        {
            if (CurrentThrowFlow == null) return;
            if (GameFlow.HasEnded)
            {
                btnThrow.Visible = false;
                return;
            }
            if (!CurrentThrowFlow.CanStillThrowOrTake)
            {
                btnThrow.Text = "Passen";
                btnThrow.Visible = true;
            }else if (CurrentThrowFlow.State == ThrowFlowState.Throwing)
            {
                btnThrow.Text = "Gooi";
                btnThrow.Visible = true;
            }else 
            {
                btnThrow.Visible = false;
            }
            while (pnlToThrow.Controls.Count > 0) pnlToThrow.Controls[0].Dispose();
            while (pnlTaken.Controls.Count > 0) pnlTaken.Controls[0].Dispose();

            foreach (var dice in CurrentThrowFlow.DicesToThrow)
            {
                pnlToThrow.Controls.Add(new DiceUserControl { RainyDice = dice, ClickFunc = DiceTakeFunc });
            }
            foreach (var dice in CurrentThrowFlow.DicesTaken)
            {
                pnlTaken.Controls.Add(new DiceUserControl { RainyDice = dice });
            }
            lblPlayerName.Text = GameFlow.CurrentPlayer.ToString();
            lblCurrentTotal.Text = CurrentThrowFlow.TotalTakenValue.ToString();
        }

        private Func<RainyDice,bool> DiceTakeFunc
        {
            get
            {
                return (dice) =>
                {
                    if (dice == null
                        || CurrentThrowFlow == null
                        || !CurrentThrowFlow.CanTakeValue(dice.LastThrowDiceValue))
                    {
                        return false;
                    }
                    CurrentThrowFlow.TakeValue(dice.LastThrowDiceValue);
                    Repaint();
                    return true;
                };
            }
        } 


        private void btnThrow_Click(object sender, EventArgs e)
        {
            if (GameFlow.HasEnded) return;
            if (!CurrentThrowFlow.CanStillThrowOrTake)
            {
                GameFlow.TakeNothing();
            }
            else if (CurrentThrowFlow.State == ThrowFlowState.Throwing)
            {
                CurrentThrowFlow.ThrowDices();
            }
            Repaint();
        }
    }
}
