using System;
using System.Collections.Generic;
using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business.ComputerLogic
{
    public class LookAheadComputer : HeuristicBasedComputer
    {
        const double BETTER_TO_STEAL = 1.05D; // stealing is better than not stealing (5%)
        const double UNSTEALABLE_RATIO = 1.005D; // harder to steal from a higher number (0,5% to the value'th power)

        protected override double EstimatedScoreAfterAnotherThrow(RainyWorm wormToTake)
        {
            var div = WormsToSteal.Contains(wormToTake) ? BETTER_TO_STEAL : 1D; // when the worm to take can be stolen, that might be better than just rethrow

            var rdvs = RainyDiceValue.All.Where(rdv => ThrowFlow.DicesTaken.All(d => d.LastThrowDiceValue != rdv));
            return CalcScore(ThrowFlow.DicesToThrow.Count(), ThrowFlow.TotalTakenValue, rdvs) / div;
        }
        
        /// <summary>
        /// Max of  - worm after taking value
        ///         - estimated throwscore after taking
        /// </summary>
        protected override double TakeValueScore(RainyDiceValue dv) {
            var toThrow = ThrowFlow.DicesToThrow.Count(d => d.LastThrowDiceValue != dv);
            var thrown = ThrowFlow.DicesToThrow.Count(d => d.LastThrowDiceValue == dv);
            var newCurrentTotal = ThrowFlow.TotalTakenValue + (thrown * dv.DiceValue);
            var availableValues = ThrowFlow.DicesToThrow.Select(d => d.LastThrowDiceValue).Where(d => d != dv).Distinct();
            return Math.Max(CalcScoreForThrownValue(newCurrentTotal),
                CalcScore(toThrow, newCurrentTotal, availableValues));
        }

        /// <summary>
        /// Sum of all possible outcomes with the number of dices left in combination of possible values that can still be thrown
        /// </summary>
        /// <returns></returns>
        private double CalcScore(int dicesLeft, int currentTotalValue, IEnumerable<RainyDiceValue> availableValues)
        {
            return availableValues.Sum(rdv => Enumerable.Range(1, dicesLeft)
                    .Sum(take => ProbTakeExact(take, dicesLeft) * CalcScoreForThrownValue(currentTotalValue + (take * rdv.DiceValue))));
        }

        /// <summary>
        /// Calculate score for the best possible worm that still can be taken for thrown value in current flow
        /// Including:
        ///     - Unstealable ratio => higher values are harder to steal
        ///     - better to steal ratio => taking from someone else means the other also loses
        ///     - The value of the best block is taken in to account, number of worms as throw value
        /// </summary>
        private double CalcScoreForThrownValue(int currentThrownValue)
        {
            var stealWorm = WormsToSteal.FirstOrDefault(rw => rw.ThrowValue == currentThrownValue);
            if (stealWorm != null){
                // best score is to steal
                return stealWorm.WormValue * Math.Pow(UNSTEALABLE_RATIO, stealWorm.ThrowValue) * BETTER_TO_STEAL;
            }
            else if(Flow.WormsToTake.Any(rw => rw.ThrowValue <= currentThrownValue))
            {
                // max value of other worms
                return Flow.WormsToTake.Where(rw => rw.ThrowValue <= currentThrownValue).Max(rw => rw.WormValue * Math.Pow(UNSTEALABLE_RATIO, rw.ThrowValue));
            }
            return 0D;
        }
    }
}
