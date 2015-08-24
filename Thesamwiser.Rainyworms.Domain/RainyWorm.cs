using System;
using System.Collections.Generic;

namespace Thesamwiser.Rainyworms.Domain
{
    /// <summary>
    /// Class representing the rainyworm blocks, the player can take
    /// </summary>
    public sealed class RainyWorm
    {
        /// <summary>
        /// no of dice outcomes
        /// </summary>
        public const int Count = 16;
        public const int MinValue = 21;
        public const int MaxValue = 36;
        private static readonly RainyWorm[] _rainyWormByValue = new RainyWorm[Count];

        /// <summary>
        /// Private ctor, so this is the only place that decided which dices to use
        /// </summary>
        /// <param name="throwValue"></param>
        /// <param name="numberOfWorms"></param>
        /// <param name=""></param>
        private RainyWorm(int throwValue, int numberOfWorms)
        {
            ThrowValue = throwValue;
            WormValue = numberOfWorms;
            _rainyWormByValue[ThrowValue-MinValue] = this;
        }

        /// <summary>
        /// Gives the list of all rainy dice values
        /// </summary>
        public static IEnumerable<RainyWorm> All { get { return _rainyWormByValue; } }

        /// <summary>
        /// Value you should throw to get this rainworm
        /// </summary>
        public int ThrowValue { get; set; }

        /// <summary>
        /// Value you get at the end of the game for obtaining the rainyworm block
        /// </summary>
        public int WormValue { get; set; }

        /// <summary>
        /// Returns the RainyWorm by thrown value
        /// It is 0-based so the possibilies are between 0 and the count of RainyWorm
        /// </summary>
        /// <param name="value">the thrown value</param>
        /// <returns></returns>
        public static RainyWorm GetByThrownValue(int value)
        {
            if (value < MinValue || value > MaxValue)
                throw new ArgumentOutOfRangeException($"Sequence should be between {MinValue} and {MaxValue}, while given: {value}");
            return _rainyWormByValue[value-MinValue];
        }

        // The possible outcomes
        public static RainyWorm TwentyOne = new RainyWorm(21, 1);
        public static RainyWorm TwentyTwo = new RainyWorm(22, 1);
        public static RainyWorm TwentyThree = new RainyWorm(23, 1);
        public static RainyWorm TwentyFour = new RainyWorm(24, 1);

        public static RainyWorm TwentyFive = new RainyWorm(25, 2);
        public static RainyWorm TwentySix = new RainyWorm(26, 2);
        public static RainyWorm TwentySeven = new RainyWorm(27, 2);
        public static RainyWorm TwentyEight = new RainyWorm(28, 2);

        public static RainyWorm TwentyNine = new RainyWorm(29, 3);
        public static RainyWorm Thirty = new RainyWorm(30, 3);
        public static RainyWorm ThirtyOne = new RainyWorm(31, 3);
        public static RainyWorm ThirtyTwo = new RainyWorm(32, 3);

        public static RainyWorm ThirtyThree = new RainyWorm(33, 4);
        public static RainyWorm ThirtyFour = new RainyWorm(34, 4);
        public static RainyWorm ThirtyFive = new RainyWorm(35, 4);
        public static RainyWorm ThirtySix = new RainyWorm(36, 4);

        public override string ToString() => ThrowValue.ToString();

    }
}
