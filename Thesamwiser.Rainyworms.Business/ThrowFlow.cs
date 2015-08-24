using System;
using System.Collections.Generic;
using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business
{
    /// <summary>
    /// New flow where it is possible to throw the dices to obtain the score
    /// </summary>
    public class ThrowFlow
    {
        private List<RainyDice> _dicesToThrow;
        private List<RainyDice> _dicesTaken;
        private static readonly Random Random = new Random();
        private readonly GameFlow _gameFlow;

        /// <summary>
        /// Default ctor
        /// </summary>
        public ThrowFlow(GameFlow gameFlow)
        {
            _gameFlow = gameFlow;
            _dicesToThrow = new List<RainyDice> // 8 dices
            {
                new RainyDice(Random), new RainyDice(Random), new RainyDice(Random), new RainyDice(Random),
                new RainyDice(Random), new RainyDice(Random), new RainyDice(Random), new RainyDice(Random)
            };
            _dicesTaken = new List<RainyDice>();
            State = ThrowFlowState.Throwing;
        }

        /// <summary>
        /// Lijst met nog te gebruiken dobbelstenen
        /// </summary>
        public IEnumerable<RainyDice> DicesToThrow {
            get {
                if (_gameFlow.ShouldSortThrownDice)
                {
                    return _dicesToThrow.OrderBy(d => d.LastThrowDiceValue?.SequenceNumber ?? -1);
                }
                return _dicesToThrow;
            }
        }

        /// <summary>
        /// Lijst met reeds genomen dobbelstenen
        /// </summary>
        public IEnumerable<RainyDice> DicesTaken {
            get {
                if (_gameFlow.ShouldSortTakenDice)
                {
                    return _dicesTaken.OrderBy(d => d.LastThrowDiceValue?.SequenceNumber ?? -1);
                }
                return _dicesTaken;
            }
        }

        /// <summary>
        /// Throw all dices that are not already taken
        /// </summary>
        public void ThrowDices()
        {
            if(State != ThrowFlowState.Throwing)
            {
                throw new InvalidOperationException("You can not throw the dices while you are not in the throwing state");
            }
            if (!CanThrowDices())
            {
                throw new InvalidOperationException("There are no more dices to throw");
            }
            _dicesToThrow.ForEach(d => d.ThrowDice());
            State = ThrowFlowState.Taking;
        }

        /// <summary>
        /// Takes all dices with the given value
        /// </summary>
        /// <param name="value"></param>
        public void TakeValue(RainyDiceValue value)
        {
            if(State != ThrowFlowState.Taking)
            {
                throw new InvalidOperationException("You can not take dices while you are not in the taking state");
            }
            if (!CanTakeValue(value))
            {
                throw new InvalidOperationException("The value "+value+" can not be taken.");
            }
            _dicesTaken.AddRange(_dicesToThrow.Where(d => d.LastThrowDiceValue == value));
            _dicesToThrow.RemoveAll(d => d.LastThrowDiceValue == value);
            State = ThrowFlowState.Throwing;
            ResetThrownDice();
        }

        /// <summary>
        /// Checks it if is possible to take a specific value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// True if - The value is thrown
        ///         - The value is not already taken
        ///  </returns>
        public bool CanTakeValue(RainyDiceValue value) {
            return State == ThrowFlowState.Taking
                && _dicesTaken.All(d => d.LastThrowDiceValue != value)
                && _dicesToThrow.Any(d => d.LastThrowDiceValue == value);
        }

        /// <summary>
        /// Checks if it is still possible to throw the dices
        /// </summary>
        /// <returns>
        /// True if - There are still any dices to throw 
        /// </returns>
        public bool CanThrowDices()
        {
            return State == ThrowFlowState.Throwing
                && _dicesToThrow.Any();
        }

        /// <summary>
        /// The sum of the values of all taken dices
        /// </summary>
        /// <returns></returns>
        public int TotalTakenValue
        {
            get { return _dicesTaken.Sum(d => d.LastThrowDiceValue.DiceValue); }
        }
        
        /// <summary>
        /// Check if the player has already taken a worm
        /// </summary>
        /// <returns>
        /// True if - there is already a worm taken
        /// </returns>
        public bool HasTakenWorm()
        {
            return _dicesTaken.Any(d => d.LastThrowDiceValue == RainyDiceValue.Worm);
        }

        /// <summary>
        /// Current state of the flow (throwing, taking)
        /// </summary>
        public ThrowFlowState State { get; private set; }

        /// <summary>
        /// True - If it's still possible to throw or take
        ///     -> When in throwing state:
        ///         - Should still have dices to throw
        ///         - AND there should still be an untaken value left
        ///     -> When in taking state:
        ///         - One of the lastThrownValues should still be takeable
        /// </summary>
        public bool CanStillThrowOrTake {
            get
            {
                if(State == ThrowFlowState.Throwing)
                {
                    return _dicesToThrow.Any() &&
                        RainyDiceValue.All.Any(v => !_dicesTaken.Any(d => d.LastThrowDiceValue == v));
                }else if(State == ThrowFlowState.Taking)
                {
                    return _dicesToThrow.Any(d => CanTakeValue(d.LastThrowDiceValue));
                }
                throw new InvalidOperationException("Flow is in an unknown state");
            }
        }

        /// <summary>
        /// Reset ThrowFlow, so the next person can go on
        /// </summary>
        public void Reset()
        {
            State = ThrowFlowState.Throwing;
            _dicesToThrow.AddRange(_dicesTaken);
            _dicesTaken.Clear();
            ResetThrownDice();
        }

        /// <summary>
        /// Calls the reset method on all thrown dice
        /// </summary>
        private void ResetThrownDice()
        {
            _dicesToThrow.ForEach(d => d.Reset());
        }
    }

    /// <summary>
    /// To indicate in which state the throwflow is
    /// </summary>
    public enum ThrowFlowState
    {
        Throwing,
        Taking
    }
}
