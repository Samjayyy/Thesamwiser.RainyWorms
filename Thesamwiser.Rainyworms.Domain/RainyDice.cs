using System;
using System.Collections.Generic;

namespace Thesamwiser.Rainyworms.Domain
{
    /// <summary>
    /// Class representing a dice with a worm on it
    /// </summary>
    public class RainyDice
    {
        private Random _rnd;

        /// <summary>
        /// Defaul ctor
        /// </summary>
        public RainyDice(Random rnd)
        {
            _rnd = rnd;
        }
        /// <summary>
        /// The last thrown dice value for this dice
        /// </summary>
        public RainyDiceValue LastThrowDiceValue { get; private set; }

        /// <summary>
        /// Throws the dice and returns the thrown value, uniformly random
        /// </summary>
        /// <remarks>To recheck the result, the LastThrownDiceValue can be checked</remarks>
        /// <returns>The thrown value</returns>
        public RainyDiceValue ThrowDice()
        {
            LastThrowDiceValue = RainyDiceValue.GetBySequence(_rnd.Next(RainyDiceValue.Count));
            return LastThrowDiceValue;
        }

        /// <summary>
        /// Resets the current dice
        /// </summary>
        public void Reset()
        {
            LastThrowDiceValue = null;
        }
    }

    /// <summary>
    /// Enum Object pattern
    /// representing all the possible values you can throw with the RainyDice
    /// </summary>
    public sealed class RainyDiceValue
    {
        /// <summary>
        /// no of dice outcomes
        /// </summary>
        public const int Count = 6;
        private static readonly RainyDiceValue[] _valuesBySequence = new RainyDiceValue[Count];

        // make the constructor private so that only this class can set up instances
        private RainyDiceValue(string name, int seqNumber, int diceVal) {
            Name = name;
            SequenceNumber = seqNumber;
            DiceValue = diceVal;
            _valuesBySequence[seqNumber] = this;
        }

        /// <summary>
        /// Gives the list of all rainy dice values
        /// </summary>
        public static IEnumerable<RainyDiceValue> All { get { return _valuesBySequence; } }

        /// <summary>
        /// Named version of the dice
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Unique sequence number
        /// Condition: The sequence number is also bigger, for bigger values
        /// </summary>
        public int SequenceNumber { get; }
        /// <summary>
        /// Value that this dice outcome is worthy
        /// </summary>
        public int DiceValue { get; }

        /// <summary>
        /// Returns the RainyDiceValue by sequence number
        /// It is 0-based so the possibilies are between 0 and the count of RainyDiceValue
        /// </summary>
        /// <param name="seq">the sequence number</param>
        /// <returns></returns>
        public static RainyDiceValue GetBySequence(int seq)
        {
            if (seq < 0 || seq >= Count)
                throw new ArgumentOutOfRangeException($"Sequence should be between 0 and {Count}, while given: {seq}");
            return _valuesBySequence[seq];
        }

        // The six possible outcomes
        public static RainyDiceValue One = new RainyDiceValue("One", 0, 1);
        public static RainyDiceValue Two = new RainyDiceValue("Two", 1, 2);
        public static RainyDiceValue Three = new RainyDiceValue("Three", 2, 3);
        public static RainyDiceValue Four = new RainyDiceValue("Four", 3, 4);
        public static RainyDiceValue Five = new RainyDiceValue("Five", 4, 5);
        public static RainyDiceValue Worm = new RainyDiceValue("Worm", 5, 5);

        public override string ToString() => Name;
    }

}
