using System.Windows.Forms;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public class BaseRainyWormUserControl : UserControl
    {
        protected GameForm GameForm { get; private set; }
        /// <summary>
        /// Activates this control
        /// </summary>
        /// <param name="parent"></param>
        public virtual void Activate(GameForm parent) {
            GameForm = parent;
            Visible = true;
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Deactivates the control if possible
        /// Returns true if deactivation worked (by default always possible)
        /// </summary>
        /// <returns></returns>
        public virtual bool Deactivate()
        {
            Visible = false;
            return true;
        }

    }
}
