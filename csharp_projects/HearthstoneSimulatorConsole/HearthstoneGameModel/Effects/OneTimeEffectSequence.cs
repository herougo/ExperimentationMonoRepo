using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public class OneTimeEffectSequence : OneTimeEffect
    {
        List<OneTimeEffect> _effects;

        public OneTimeEffectSequence(List<OneTimeEffect> effects) {
            _effects = effects;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot cardSlot)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            foreach (OneTimeEffect effect in _effects)
            {
                EffectManagerNodePlan newPlan = effect.Execute(game, cardSlot);
                plan.Update(newPlan);
            }
            if (plan.IsEmpty)
            {
                return null;
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            List<OneTimeEffect> effects = new List<OneTimeEffect>();
            foreach (OneTimeEffect effect in _effects)
            {
                effects.Add(effect.Copy());
            }

            return new OneTimeEffectSequence(effects);
        }
    }
}
