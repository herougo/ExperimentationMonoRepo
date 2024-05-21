using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public class GroupContinuousEffect : EMEffect
    {
        List<ContinuousEffect> _effects;
        public GroupContinuousEffect(List<ContinuousEffect> effects)
        {
            _effects = effects;
            _eventsReceived = new List<string>();
            foreach (ContinuousEffect effect in _effects)
            {
                _eventsReceived.AddRange(effect.EventsReceived);
            }
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            foreach (ContinuousEffect effect in _effects)
            {
                EffectManagerNodePlan newPlan = effect.Start(game, emNode);
                plan.Update(newPlan);
            }
            if (plan.IsEmpty)
            {
                return null;
            }
            return plan;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            foreach (ContinuousEffect effect in _effects)
            {
                EffectManagerNodePlan newPlan = effect.Stop(game, emNode);
                plan.Update(newPlan);
            }
            if (plan.IsEmpty)
            {
                return null;
            }
            return plan;
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            foreach (ContinuousEffect effect in _effects)
            {
                effect.AdjustStats(cardSlot);
            }
        }

        public override EMEffect Copy()
        {
            List<ContinuousEffect> effects = new List<ContinuousEffect>();
            foreach (ContinuousEffect effect in _effects)
            {
                effects.Add((ContinuousEffect) effect.Copy());
            }

            return new GroupContinuousEffect(effects);
        }
    }
}
