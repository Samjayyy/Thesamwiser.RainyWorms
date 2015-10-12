using System;
using System.Collections.Generic;
using System.Linq;
using Thesamwiser.Rainyworms.Domain;

namespace Thesamwiser.Rainyworms.Business.ComputerLogic
{
    public abstract class GameFlowLogic
    {
        protected GameFlow Flow { get; private set; }
        protected ThrowFlow ThrowFlow { get; private set; }
        protected IEnumerable<RainyWorm> WormsToSteal { get; private set;}

        /// <summary>
        /// Init data that is reused often the same play
        /// </summary>
        protected virtual void InitPlay(GameFlow flow)
        {
            Flow = flow;
            WormsToSteal = Flow.Players.Where(p => p != Flow.CurrentPlayer && p.WormsWon.Any()).Select(p => p.TopWorm);
            ThrowFlow = Flow.CurrentTurn;
        }

        public void Play(GameFlow flow)
        {
            InitPlay(flow);
            if (Flow.CurrentPlayer.IsHuman)
            {
                throw new InvalidOperationException("Don't use computer logic for a human");
            }
            do
            {
                if(ThrowFlow.State == ThrowFlowState.Throwing)
                {
                    if(RainyWorm.All.Any(w => Flow.CanTakeRainyWorm(w))) 
                    {
                        if (HandleThrowing())
                        {
                            return; // Stop when a rainyworm was taken
                        }
                    }
                    ThrowFlow.ThrowDices();
                }else if(ThrowFlow.State == ThrowFlowState.Taking)
                {
                    // distinct thrown values that are not thrown yet
                    var thrownValues = ThrowFlow.DicesToThrow
                            .Select(d => d.LastThrowDiceValue)
                            .Distinct()
                            .Where(thrown => ThrowFlow.DicesTaken.Select(d => d.LastThrowDiceValue).All(taken => taken != thrown));
                    // check if there are any left to pick
                    if (thrownValues.Any())
                    {
                        HandleTaking(thrownValues);
                    }
                }
            } while (ThrowFlow.CanStillThrowOrTake);
            Flow.TakeNothing();
        }

        /// <summary>
        /// returns true - if a worm was taken
        /// </summary>
        /// <returns></returns>
        protected abstract bool HandleThrowing();

        /// <summary>
        /// returns true - if some die was taken
        /// </summary>
        protected abstract void HandleTaking(IEnumerable<RainyDiceValue> thrownValues);
    }
}
