using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class WhenOtherCardPlayed : TriggerEffect
    {
        public WhenOtherCardPlayed(OneTimeEffect effect)
            :base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.WhenCardPlayed };
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (eventSlots[0] == emNode.AffectedSlot)
            {
                return null;
            }
            return _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot);
        }

        public override EMEffect Copy()
        {
            return new WhenOtherCardPlayed(_effect.Copy());
        }
    }
}
