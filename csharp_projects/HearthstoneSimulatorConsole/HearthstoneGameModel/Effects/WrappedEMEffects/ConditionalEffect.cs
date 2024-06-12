using HearthstoneGameModel.Conditions;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.WrappedEMEffects
{
    public class ConditionalEffect : WrappedEMEffect
    {
        protected ICondition _condition;
        protected bool _memoryCurrentCondEval = false;

        public ConditionalEffect(ICondition condition, EMEffect effect)
        : base(effect)
        {
            _condition = condition;
            _eventsReceived.AddRange(_condition.EventsReceived);
        }

        private EffectManagerNodePlan checkConditionAndAffectEffect(HearthstoneGame game, EffectManagerNode emNode)
        {
            bool prevEval = _memoryCurrentCondEval;
            _memoryCurrentCondEval = _condition.Evaluate(game, emNode);

            if (prevEval != _memoryCurrentCondEval) {
                EffectManagerNodePlan plan;
                if (_memoryCurrentCondEval)
                {
                    plan = _effect.Start(game, emNode);
                }
                else
                {
                    plan = _effect.Stop(game, emNode);
                }
                return plan;
            }
            return null;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            CheckValidEvent(effectEvent);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            if (_condition.EventsReceived.Contains(effectEvent))
            {
                plan.Update(checkConditionAndAffectEffect(game, emNode));
            }
            if (_memoryCurrentCondEval && _effect.EventsReceived.Contains(effectEvent))
            {
                plan.Update(_effect.SendEvent(effectEvent, game, emNode, eventSlot));
            }
            return plan;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            return checkConditionAndAffectEffect(game, emNode);
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            if (_memoryCurrentCondEval)
            {
                return _effect.Stop(game, emNode);
            }
            return null;
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            if (_memoryCurrentCondEval)
            {
                _effect.AdjustStats(cardSlot);
            }
        }

        public override EMEffect Copy()
        {
            return new ConditionalEffect(_condition.Copy(), _effect.Copy());
        }
    }
}
