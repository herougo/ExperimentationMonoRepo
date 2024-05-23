using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Effects
{
    public abstract class TriggerEffect : EMEffect
    {
        protected OneTimeEffect _effect;

        public TriggerEffect(OneTimeEffect effect)
        {
            _effect = effect;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            return null;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            CheckValidEvent(effectEvent);
            return _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot);
        }
    }
}
