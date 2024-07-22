using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ActivatedEffects
{
    public class HeroPowerEffect : ActivatedEffect
    {
        public HeroPowerEffect(OneTimeEffect effect) : base(effect) {
            _eventsReceived = new List<string> { EffectEvent.ActivateHeroPower };
            _requiresSlotMatchForEvent = true;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            EffectManagerNodePlan result = _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot, eventSlots);
            game.PlayerMetadata[emNode.AffectedSlot.Player].HeroPowerUsedThisTurn = true;
            return result;
        }

        public override EMEffect Copy()
        {
            return new HeroPowerEffect(_effect.Copy());
        }
    }
}
