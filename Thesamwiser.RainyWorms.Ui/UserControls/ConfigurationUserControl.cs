using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public partial class ConfigurationUserControl : BaseRainyWormUserControl
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public ConfigurationUserControl()
        {
            InitializeComponent();
        }

        public GameConfiguration Configuration { get; private set; }

        /// <summary>
        /// Todo on activation of the user control
        /// </summary>
        /// <param name="parent"></param>
        public override void Activate(GameForm parent)
        {
            base.Activate(parent);

            Configuration = parent.Manager.Config;
            bsVerdelingStartOpties.DataSource = PlayerSequenceDeterminator.All;
            if(Configuration == null)
            {
                bsConfig.DataSource = typeof(GameConfiguration);
            }
            else
            {
                bsConfig.DataSource = Configuration;
            }
        }

        /// <summary>
        /// Todo on deactivation of the user control
        /// </summary>
        /// <returns></returns>
        public override bool Deactivate()
        {
            grdSpelers.CommitEdit(System.Windows.Forms.DataGridViewDataErrorContexts.Commit); // ensure grid is commited before validating
            bsConfig.EndEdit();
            if (!Configuration.Players.Any(p => p.IsHuman && p.IsPlaying))
            {
                GameForm.ShowErrors("Foutieve configuratie", "Gelieve minstens 1 menselijke speler te kiezen die speelt");
                return false;
            }
            else if (Configuration.Players.Count(p => p.IsPlaying) == 1)
            {
                return GameForm.Confirm("Configuratie afsluiten", "Ben je zeker dat je een eenzaam spelletje zonder tegenstanders wilt spelen?");
            }
            return true;
        }

    }
}
