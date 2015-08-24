using System.Windows.Forms;
using Thesamwiser.Rainyworms.Business;
using Thesamwiser.RainyWorms.Ui.UserControls;

namespace Thesamwiser.RainyWorms.Ui
{
    /// <summary>
    /// The form that will display all about the game
    /// </summary>
    public partial class GameForm : Form
    {
        private BaseRainyWormUserControl _activeUserControl;

        /// <summary>
        /// Ctor
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            ActiveUserControl = new WelcomeUserControl();
            Manager = new GameManager();
        }

        /// <summary>
        /// The current gameconfiguration
        /// </summary>
        public GameManager Manager { get; }

        /// <summary>
        /// The active user control of the form
        /// </summary>
        public BaseRainyWormUserControl ActiveUserControl
        {
            get
            {
                return _activeUserControl;
            }

            set
            {
                if(_activeUserControl != null)
                {
                    if (!_activeUserControl.Deactivate())
                        return;  // don't do anything when no ready to deactivate
                    pnlActiveUserControl.Controls.Remove(_activeUserControl);
                    _activeUserControl.Dispose();
                }
                _activeUserControl = value;
                _activeUserControl.Activate(this);
                pnlActiveUserControl.Controls.Add(_activeUserControl);
            }
        }

        /// <summary>
        /// De manier om een foutmelding te geven tijdens het spel
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="fout"></param>
        public void ShowErrors(string titel, string fout)
        {
            MessageBox.Show(fout, titel, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// De manier om een waarschuwing te geven tijdens het spel
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="waarschuwing"></param>
        public void ShowWarning(string titel, string waarschuwing)
        {
            MessageBox.Show(waarschuwing, titel, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// De manier om informatie terug te geven tijdens een spel
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="bericht"></param>
        public void ShowInfo(string titel, string bericht)
        {
            MessageBox.Show(bericht, titel, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// De manier om confirmatie aan de gebruiker te vragen
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="vraag"></param>
        /// <returns></returns>
        public bool Confirm(string titel, string vraag)
        {
            return MessageBox.Show(vraag, titel, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        /// <summary>
        /// Starting a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGameStart_Click(object sender, System.EventArgs e)
        {
            ActiveUserControl = new GamePlayUserControl();
        }

        /// <summary>
        /// Afsluiten
        /// cfr: http://stackoverflow.com/questions/12977924/how-to-properly-exit-a-c-sharp-application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGameAfsluiten_Click(object sender, System.EventArgs e)
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
        /// <summary>
        /// Controleren of er afgesloten mag/kan worden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ActiveUserControl != null && !ActiveUserControl.Deactivate())
            {
                e.Cancel = true;
            }
        }

    }
}
