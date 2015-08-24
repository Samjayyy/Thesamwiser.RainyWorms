using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thesamwiser.Rainyworms.Business;
using Thesamwiser.Rainyworms.Domain;
using Thesamwiser.RainyWorms.Ui.Helper;

namespace Thesamwiser.RainyWorms.Ui.UserControls
{
    public partial class GamePlayUserControl : BaseRainyWormUserControl
    {
        public GamePlayUserControl()
        {
            InitializeComponent();
        }

        private GameFlow _gameFlow;
        private List<PlayerScoreUserControl> _playerScoreUserControls;

        /// <summary>
        /// Activate user Control
        /// </summary>
        /// <param name="parent"></param>
        public override void Activate(GameForm parent)
        {
            base.Activate(parent);
            _gameFlow = GameForm.Manager.CreateGameFlow();
            init();
        }

        private void init()
        {
            ucPlayDices.GameFlow = _gameFlow;
            GeneratePlayersPanel();
            Repaint();
            _gameFlow.OnCurrentTurnChanged += (sender, args) => Repaint();
            _gameFlow.OnGameEnded += (sender, args) => GameEnded();

        }

        private void Repaint()
        {
            ucPlayDices.Repaint();
            _playerScoreUserControls.ForEach(
                uc => {
                    var topWormUc = uc.Player.TopWorm == null ? null : new WormBlockUserControl { RainyWorm = uc.Player.TopWorm, ClickFunc = ClickWormFunc };
                    uc.Repaint(topWormUc);
                }
            );
            GenerateWormsPanel();
        }

        private void GameEnded()
        {
            pnlSpel.Controls.ClearAndDispose();
            var players = _gameFlow.Players.OrderByDescending(p => p.TotalWormScore).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Eindstand: ");
            players.ForEach(p => sb.AppendLine($" - {p.Name} => {p.TotalWormScore}"));
            GameForm.ShowInfo("Einde spel", sb.ToString());
        }

        private void GeneratePlayersPanel()
        {
            _playerScoreUserControls = _gameFlow.Players
                .Select(player => new PlayerScoreUserControl { Player = player })
                .ToList();
            //Clear out the existing controls, we are generating a new table layout
            pnlPlayers.Controls.ClearAndDispose();
            //Clear out the existing row and column styles
            pnlPlayers.ColumnStyles.Clear();
            pnlPlayers.RowStyles.Clear();

            pnlPlayers.RowCount = 1;
            pnlPlayers.ColumnCount = _playerScoreUserControls.Count;
            pnlPlayers.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var col = 0;
            foreach (var playerScoreUc in _playerScoreUserControls)
            {
                pnlPlayers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / _playerScoreUserControls.Count));
                pnlPlayers.Controls.Add(playerScoreUc, col++, 0);
            }
        }

        private void GenerateWormsPanel()
        {
            var wormsUcs = _gameFlow.WormsToTake
                .Select(worm => new WormBlockUserControl { RainyWorm = worm, ClickFunc = ClickWormFunc })
                .ToList();
            pnlWorms.Controls.ClearAndDispose();
            pnlWorms.ColumnStyles.Clear();
            pnlWorms.RowStyles.Clear();

            pnlWorms.RowCount = 1;
            pnlWorms.ColumnCount = wormsUcs.Count;
            pnlWorms.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var col = 0;
            foreach (var wormUc in wormsUcs)
            {
                pnlWorms.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / _gameFlow.WormsLeft));
                pnlWorms.Controls.Add(wormUc, col++, 0);
            }
        }

        /// <summary>
        /// React on clicking the worm
        /// </summary>
        private Func<RainyWorm, bool> ClickWormFunc
        {
            get
            {
                return (worm) =>
                {
                    if (_gameFlow == null
                        || !_gameFlow.CanTakeRainyWorm(worm))
                    {
                        return false;
                    }
                    _gameFlow.TakeRainyWorm(worm);
                    return true;
                };
            }
        }

        /// <summary>
        /// When in play, at least a warning should be shown
        /// </summary>
        /// <returns></returns>
        public override bool Deactivate()
        {
            return _gameFlow.HasEnded || GameForm.Confirm("Spel stoppen", "Weet je zeker dat je dit spel wilt stoppen terwijl het niet afgelopen is?");
        }

    }
}
