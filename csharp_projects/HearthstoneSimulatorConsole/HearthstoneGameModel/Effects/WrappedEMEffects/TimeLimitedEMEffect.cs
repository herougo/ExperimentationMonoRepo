using HearthstoneGameModel.Core;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.WrappedEMEffects
{
    public class TimeLimitedEMEffect : WrappedEMEffect
    {
        EffectTimeLimit _untilWhen;

        public TimeLimitedEMEffect(EMEffect effect, EffectTimeLimit untilWhen)
            : base(effect)
        {
            _untilWhen = untilWhen;
            _eventsReceived.Add(EffectEvent.EndTurn);
        }

        private bool isTimeUp(int endingTurn, int affectedSlotPlayer)
        {
            if (_untilWhen == EffectTimeLimit.NoLimit)
            {
                return false;
            }
            else if (_untilWhen == EffectTimeLimit.EndOfTurn)
            {
                return true;
            }
            else if (_untilWhen == EffectTimeLimit.EndOfPlayerTurn)
            {
                return endingTurn == affectedSlotPlayer;
            }
            else if (_untilWhen == EffectTimeLimit.EndOfOpponentTurn)
            {
                return endingTurn != affectedSlotPlayer;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (effectEvent == EffectEvent.EndTurn
                && isTimeUp(game.GameMetadata.Turn, emNode.AffectedSlot.Player))
            {
                EffectManagerNodePlan plan = new EffectManagerNodePlan();
                plan.ToRemove.Add(emNode);
                return plan;
            }
            else if (_effect.EventsReceived.Contains(effectEvent))
            {
                return _effect.SendEvent(effectEvent, game, emNode, eventSlots);
            }
            throw new AssertionException("unhandled event (shouldn't happen)");
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = _effect.Start(game, emNode);
            if (plan != null)
            {
                foreach (EffectManagerNode toAddNode in plan.ToAdd)
                {
                    toAddNode.Effect = new TimeLimitedEMEffect(toAddNode.Effect, _untilWhen);
                }
            }
            return plan;
        }

        public override EMEffect Copy()
        {
            return new TimeLimitedEMEffect(_effect.Copy(), _untilWhen);
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            _effect.AdjustStats(cardSlot);
        }
    }
}
