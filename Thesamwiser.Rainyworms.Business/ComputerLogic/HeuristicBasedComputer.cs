using System;
using System.Collections.Generic;
using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business.ComputerLogic
{
    public abstract class HeuristicBasedComputer : GameFlowLogic
    {
        /// <summary>
        /// Throw again if the heuristic thinks you can still benefit from it
        /// Else take the highest worm value available
        /// </summary>
        /// <returns></returns>
        protected override bool HandleThrowing()
        {
            var valueToTake = RainyWorm.All.Where(w => Flow.CanTakeRainyWorm(w)).OrderByDescending(w => w.ThrowValue).FirstOrDefault();
            if(ShouldTakeWorm(valueToTake))
            {
                Flow.TakeRainyWorm(valueToTake);
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method assumes the computer is not the clumsy guy that does another try when it's not possible anymore
        /// </summary>
        private bool ShouldTakeWorm(RainyWorm worm)
        {
            if (worm == null)
            {
                return false;
            }
            // if all dice value are used, STOP!
            if (ThrowFlow.DicesTaken.Select(d => d.LastThrowDiceValue).Distinct().Count() == RainyDiceValue.Count)
            {
                return true;
            }
            // if there are no dices left to throw with, STOP!
            if (!ThrowFlow.DicesToThrow.Any())
            {
                return true;
            }
            // take worm if available and worse than possibility when throwing again
            if (worm.WormValue >= EstimatedScoreAfterAnotherThrow(worm))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Estimated score you will have after doing another throw in the current throwflow
        /// - The worm that will be taken else is given as param, in case you want to put logic to that
        /// </summary>
        protected abstract double EstimatedScoreAfterAnotherThrow(RainyWorm wormToTake);

        /// <summary>
        /// Takes the best value according to the heuristic
        /// </summary>
        protected override void HandleTaking(IEnumerable<RainyDiceValue> thrownValues)
        {
            // pick the best according to CalcVal heuristic
            var val = thrownValues.Aggregate((v1, v2) =>
                TakeValueScore(v1) >
                TakeValueScore(v2) ?
                v1 : v2);
            ThrowFlow.TakeValue(val);
        }

        /// <summary>
        /// returns a score that will be used to determine which dicevalue should be taken ideally
        /// The highest will be taken from these that are still available
        /// </summary>
        protected abstract double TakeValueScore(RainyDiceValue dv);

        /// <summary>
        /// FORMULA: bin(n,k) * p^k * (1−p)^(n−k)
        ///     = (bin(n, k) * (5/6)^(n-k)) / (6^k)
        /// </summary>
        protected static double ProbTakeExact(int take, int total)
        {
            return (1D * Binom(total, take) * Math.Pow(5D / 6, total - take)) / Math.Pow(6D, take);
        }

        public static double Binom(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }
            return Math.Pow(10, sum);
        }
    }
}
