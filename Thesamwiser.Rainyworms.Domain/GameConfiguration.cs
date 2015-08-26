using System;
using System.Collections.Generic;
using System.Linq;

namespace Thesamwiser.Rainyworms.Domain
{
    /// <summary>
    /// Representing a configuration for a game of rainy worms
    /// </summary>
    public class GameConfiguration
    {
        internal static readonly Random rnd = new Random();
        private PlayerConfig[] _players;
        /// <summary>
        /// Default ctor
        /// </summary>
        public GameConfiguration()
        {
            // default values
            _players = new PlayerConfig[]
            {
                new PlayerConfig {Name="Ludo", IsPlaying = true, IsHuman = true},
                new PlayerConfig {Name="Paula", IsPlaying = true, IsHuman = false},
                new PlayerConfig {Name="Emilie",IsPlaying = true, IsHuman = false},
                new PlayerConfig {Name="Tinneke",IsPlaying = true,IsHuman = false},
                new PlayerConfig {Name="Wart", IsPlaying = true, IsHuman = false},
                new PlayerConfig {Name="Danny",IsPlaying = false, IsHuman = false},
                new PlayerConfig {Name="Anne-marie",IsPlaying = false, IsHuman = false},
            };
            ShouldSortTakenDice = true;
            ShouldSortThrownDice = true;
            DecidePlayerSequence = PlayerSequenceDeterminator.RandomSequence;
        }

        /// <summary>
        /// Func die een Lijst van spelers binnenkrijgt en die in de volgorde zet zoals gekozen
        /// </summary>
        public PlayerSequenceDeterminator DecidePlayerSequence { get; set; }

        /// <summary>
        /// Default configured players
        /// </summary>
        public IList<PlayerConfig> Players { get { return _players; } }

        /// <summary>
        /// Indication that the thrown dice should automatically be sorted at all time
        /// </summary>
        public bool ShouldSortThrownDice { get; set; }

        /// <summary>
        /// Indication that the taken dice should automatically be sorted at all time
        /// </summary>
        public bool ShouldSortTakenDice { get; set; }

        /// <summary>
        /// return all players who are configured to play
        /// Sequence is determined by configured DecidePlayerSequence
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Player> CreatePlayersInSequence()
        {
            return DecidePlayerSequence.DetermineSequence(
                    Players.Where(p => p.IsPlaying)
                    .Select(p => new Player(p.Name, p.IsHuman))
            );
        }

    }


    /// <summary>
    /// Enum Object pattern
    /// representing all the possible ways you can choose to sort the players at the start of the game
    /// </summary>
    public sealed class PlayerSequenceDeterminator
    {
        /// <summary>
        /// no of dice outcomes
        /// </summary>
        public const int Count = 3;
        private static readonly PlayerSequenceDeterminator[] _valuesBySequence = new PlayerSequenceDeterminator[Count];

        // make the constructor private so that only this class can set up instances
        private PlayerSequenceDeterminator(string name, int seqNumber, Func<IEnumerable<Player>, IEnumerable<Player>> fnc)
        {
            Name = name;
            SequenceNumber = seqNumber;
            DetermineSequence = fnc;
            _valuesBySequence[seqNumber] = this;
        }

        /// <summary>
        /// Gives the list of all rainy dice values
        /// </summary>
        public static IEnumerable<PlayerSequenceDeterminator> All { get { return _valuesBySequence; } }

        /// <summary>
        /// Named version of the dice
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Unique sequence number
        /// </summary>
        public int SequenceNumber { get; }
        /// <summary>
        /// Func that gets as input the original Ienumerable and returns the sorted version
        /// </summary>
        public Func<IEnumerable<Player>, IEnumerable<Player>> DetermineSequence { get; }

        /// <summary>
        /// Returns the PlayerSequenceDeterminator by sequence number
        /// It is 0-based so the possibilies are between 0 and the count of PlayerSequenceDeterminator
        /// </summary>
        /// <param name="seq">the sequence number</param>
        /// <returns></returns>
        public static PlayerSequenceDeterminator GetBySequence(int seq)
        {
            if (seq < 0 || seq >= Count)
                throw new ArgumentOutOfRangeException($"Sequence should be between 0 and {Count}, while given: {seq}");
            return _valuesBySequence[seq];
        }

        // The possible ways
        public static PlayerSequenceDeterminator AsConfigured = new PlayerSequenceDeterminator("Zoals configuratie", 0, players => players);
        public static PlayerSequenceDeterminator RandomStarter = new PlayerSequenceDeterminator(
            "Willekeurig persoon start", 1, (players) =>
            {
                int starter = GameConfiguration.rnd.Next(players.ToList().Count);
                return players.Skip(starter).Union(players.Take(starter));
            });
        public static PlayerSequenceDeterminator RandomSequence = new PlayerSequenceDeterminator(
            "Willekeurige volgorde", 2, (players) => players.OrderBy(p => GameConfiguration.rnd.Next()));

        public override string ToString() => Name;
    }

    public class PlayerConfig
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public PlayerConfig()
        {

        }
        public string Name { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsHuman { get; set; }

    }
}
