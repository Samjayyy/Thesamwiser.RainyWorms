using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business
{
    public class GameManager
    {
        private GameConfiguration _config;
        /// <summary>
        /// Default ctor
        /// </summary>
        public GameManager()
        {
            _config = new GameConfiguration();
        }

        /// <summary>
        /// Creates a new GameFlow
        /// </summary>
        /// <returns></returns>
        public GameFlow CreateGameFlow()
        {
            var players = _config.CreatePlayersInSequence();
            return new GameFlow(players)
            {
                ShouldSortThrownDice = _config.ShouldSortThrownDice,
                ShouldSortTakenDice = _config.ShouldSortTakenDice
            };
        }
    }
}
