using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public abstract class WrappedEMEffect : EMEffect
    {
        protected EMEffect _effect;

        public WrappedEMEffect(EMEffect effect) {
            _effect = effect;
            _eventsReceived = effect.EventsReceived.ToList();
        }

        public override void AdjustStats(BattlerCardSlot cardSlot)
        {
            _effect.AdjustStats(cardSlot);
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            return _effect.SendEvent(effectEvent, game, emNode, eventSlot);
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            return _effect.Start(game, emNode);
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            return _effect.Stop(game, emNode);
        }
    }
}
