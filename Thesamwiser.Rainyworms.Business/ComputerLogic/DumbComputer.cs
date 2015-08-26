using System;
using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business.ComputerLogic
{
    public class DumbComputer
    {
        /// <summary>
        /// Strategy for taking worm
        ///     => always take the worm with highest throwvalue possible as soon as possible
        /// Strategy for taking dice
        ///     => always take the highest dice value possible
        /// </summary>
        /// <param name="flow"></param>
        public void Play(GameFlow flow)
        {
            if (flow.CurrentPlayer.IsHuman)
                throw new InvalidOperationException("Don't use computer logic for a human");
            var throwFlow = flow.CurrentTurn;
            do
            {
                if(throwFlow.State == ThrowFlowState.Throwing)
                {
                    var valueToTake = RainyWorm.All.Where(w => flow.CanTakeRainyWorm(w)).OrderByDescending(w => w.ThrowValue).FirstOrDefault();
                    if(valueToTake != null)
                    {
                        flow.TakeRainyWorm(valueToTake);
                        return;
                    }
                    throwFlow.ThrowDices();
                }else if(throwFlow.State == ThrowFlowState.Taking)
                {
                    // required to take dices here
                    var dv = throwFlow.DicesToThrow
                            .Select(d => d.LastThrowDiceValue)
                            .Where(thrown => throwFlow.DicesTaken.Select(d => d.LastThrowDiceValue).All(taken => taken != thrown))
                            .OrderByDescending(value => value.SequenceNumber).First();
                    throwFlow.TakeValue(dv);
                }
            } while (throwFlow.CanStillThrowOrTake);
            flow.TakeNothing();
        }
    }
}
