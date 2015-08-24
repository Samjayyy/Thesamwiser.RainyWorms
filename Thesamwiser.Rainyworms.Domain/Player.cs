using System.Collections.Generic;
using System.Linq;

namespace Thesamwiser.Rainyworms.Domain
{
    /// <summary>
    /// Class representing a player that plays the game
    /// </summary>
    public class Player
    {
        private Stack<RainyWorm> _wormsWon;

        /// <summary>
        /// Default ctor
        /// </summary>
        public Player(string name, bool isHuman)
        {
            Name = name;
            _wormsWon = new Stack<RainyWorm>();
        }

        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get;}

        /// <summary>
        /// Indication if this player acts automatically of by human interaction
        /// </summary>
        public bool IsHuman { get; }

        /// <summary>
        /// The stack with scored worms
        /// </summary>
        public IEnumerable<RainyWorm> WormsWon { get { return _wormsWon; } }

        /// <summary>
        /// Puts the given worm on top of the stack
        /// </summary>
        /// <param name="worm"></param>
        public void AddWorm(RainyWorm worm)
        {
            _wormsWon.Push(worm);
        }

        /// <summary>
        /// Removes and returns the topWorm of the stack
        /// throws exception when no worms on the stack
        /// </summary>
        /// <returns>the worm on top of the stack</returns>
        public RainyWorm TakeTopWorm()
        {
            return _wormsWon.Pop();
        }


        /// <summary>
        /// The worm on top of the stack
        /// Or NULL if not gained any
        /// </summary>
        public RainyWorm TopWorm {
            get {
                if (!_wormsWon.Any())
                    return null;
                return _wormsWon.Peek();
            }
        }

        /// <summary>
        /// Total number of worms scored by this player
        /// </summary>
        public int TotalWormScore {
            get
            {
                return _wormsWon.Sum(w => w.WormValue);
            }
        }

        /// <summary>
        /// The player's name
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;
    }
}
