using System;
using System.Collections.Generic;
using System.Linq;
using Thesamwiser.Rainyworms.Business.ComputerLogic;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business
{
    public class GameFlow
    {
        private LinkedList<Player> _players;
        private LinkedListNode<Player> _currentPlayerNode;
        private ThrowFlow _currentTurn;
        private List<RainyWorm> _wormsToTake;

        /// <summary>
        /// Default ctor
        /// </summary>
        public GameFlow(IEnumerable<Player> players)
        {
            _players = new LinkedList<Player>(players);
            _currentPlayerNode = _players.Last;
            _wormsToTake = new List<RainyWorm>(RainyWorm.All);
            _currentTurn = new ThrowFlow(this);
            Next();
        }

        /// <summary>
        /// Lijst met alle spelers
        /// </summary>
        public IEnumerable<Player> Players { get { return _players; } }

        /// <summary>
        /// Returns the number of players
        /// </summary>
        public int PlayerCount { get { return _players.Count; } }

        /// <summary>
        /// Speler die aan de beurt is
        /// </summary>
        public Player CurrentPlayer { get { return _currentPlayerNode.Value; } }

        /// <summary>
        /// Alle gegevens over de huidige worp van de huidige speler
        /// </summary>
        public ThrowFlow CurrentTurn
        {
            get { return _currentTurn; }
        }

        /// <summary>
        /// The worms left to take
        /// </summary>
        public IEnumerable<RainyWorm> WormsToTake { get { return _wormsToTake; } }

        /// <summary>
        /// The number of worms left
        /// </summary>
        public int WormsLeft { get { return _wormsToTake.Count; } }

        /// <summary>
        /// Take a specific block
        /// - If the given worm is null, this will end up in take nothing
        /// The method excepts a block that is free to take, else this will end up in an exception
        /// And go one with the rest of the game
        /// </summary>
        /// <returns></returns>
        public void TakeRainyWorm(RainyWorm worm) {
            if(worm == null)
            {
                TakeNothing();
                return;
            }
            if (!CanTakeRainyWorm(worm))
            {
                throw new InvalidOperationException("You can not take worm " + worm);
            }
            if (_wormsToTake.Contains(worm))
            {
                // taking a worm from the untaken stack
                _wormsToTake.Remove(worm);
                CurrentPlayer.AddWorm(worm);
            }
            else {
                // stealing worm of other player
                var player = _players.First(p => p.TopWorm == worm);                
                CurrentPlayer.AddWorm(player.TakeTopWorm());
            }
            Next();
        }

        /// <summary>
        /// Removes the worm with the highest throwvalue from the stack of worms to take
        /// And go on with the rest of the game
        /// </summary>
        public void TakeNothing()
        {
            _wormsToTake.Remove(_wormsToTake.First(w => w.ThrowValue == _wormsToTake.Max(r => r.ThrowValue)));
            Next();
        }

        /// <summary>
        /// Checks if a specific rainy worm can be taken
        /// </summary>
        /// <param name="worm"></param>
        /// <returns>
        /// True if - currentTurn is not null
        ///         - AND Value of turn is at least as big as the throwvalue of the worm
        ///         - AND There is already a worm taken in the turn
        ///         - AND The worm can still be taken from the general stack
        ///             - OR is on the top of one of the other players stack's 
        /// </returns>
        public bool CanTakeRainyWorm(RainyWorm worm) {
            return _currentTurn != null
                && _currentTurn.TotalTakenValue >= worm.ThrowValue
                && _currentTurn.State != ThrowFlowState.Taking
                && _currentTurn.HasTakenWorm()
                && (_wormsToTake.Contains(worm)
                    || (_currentTurn.TotalTakenValue == worm.ThrowValue 
                        && _players.Any(p => p != CurrentPlayer && p.TopWorm == worm)
                        )
                );
        }

        /// <summary>
        /// Indicates if the game has ended or not
        /// </summary>
        public bool HasEnded
        {
            get { return WormsLeft == 0; }
        }

        /// <summary>
        /// Initialiseer volgende speler en flow voor te kunnen gooien
        /// </summary>
        private void Next()
        {
            if (HasEnded)
            {
                GameEnded();
                return; // The game has ended
            }
            NextPlayer();
            _currentTurn.Reset();
            CurrentTurnChanged();
            if (!CurrentPlayer.IsHuman)
            {
                new DumbComputer().Play(this);
            }
        }

        /// <summary>
        /// Event to bind to when current turn is changed
        /// </summary>
        public event EventHandler OnCurrentTurnChanged;

        private void CurrentTurnChanged()
        {
            if (OnCurrentTurnChanged != null)
            {
                OnCurrentTurnChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Event to bind to when the current game has ended
        /// </summary>
        public event EventHandler OnGameEnded;

        private void GameEnded()
        {
            if (OnGameEnded != null)
            {
                OnGameEnded(this, new EventArgs());
            }
        }


        /// <summary>
        /// Places the current player at the back of the playerslist
        /// </summary>
        private void NextPlayer()
        {
            _currentPlayerNode = _currentPlayerNode.Next ?? _players.First;
        }

        /// <summary>
        /// Indication that the dices should automatically be sorted when taken
        /// </summary>
        internal bool ShouldSortTakenDice { get; set; }

        /// <summary>
        /// Indication that the dices should automatically be sorted after throwing
        /// </summary>
        internal bool ShouldSortThrownDice { get; set; }
    }
}
