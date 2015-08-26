using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business
{
    public class GameManager
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public GameManager()
        {
            Config = new GameConfiguration();
        }

        /// <summary>
        /// The configuration that belongs to the manager
        /// </summary>
        public GameConfiguration Config { get; }

        /// <summary>
        /// Creates a new GameFlow
        /// </summary>
        /// <returns></returns>
        public GameFlow CreateGameFlow()
        {
            var players = Config.CreatePlayersInSequence();
            return new GameFlow(players)
            {
                ShouldSortThrownDice = Config.ShouldSortThrownDice,
                ShouldSortTakenDice = Config.ShouldSortTakenDice
            };
        }
    }
}
