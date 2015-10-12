using System;
using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business.ComputerLogic
{
    public class SafetyFirstComputer : HeuristicBasedComputer
    {
        protected override double EstimatedScoreAfterAnotherThrow(RainyWorm wormToTake)
        {
            return 0; // always play safe
        }

        protected override double TakeValueScore(RainyDiceValue dv)
        {
            return dv.SequenceNumber; // take the one with the heigesht sequence number
        }
    }
}
