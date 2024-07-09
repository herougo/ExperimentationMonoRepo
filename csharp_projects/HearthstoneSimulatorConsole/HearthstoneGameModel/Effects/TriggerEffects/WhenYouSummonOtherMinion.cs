using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.CardTypes;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class WhenYouSummonOtherMinion : TriggerEffect
    {
        MinionTag _desiredTag;

        public WhenYouSummonOtherMinion(OneTimeEffect effect, MinionTag desiredTag)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionSummoned };
            _requiresSlotPlayerMatchForEvent = true;
            _desiredTag = desiredTag;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            MinionCard minionCard = (MinionCard)eventSlots[0].Card;
            if (HSGameUtils.MatchesTag(_desiredTag, minionCard.Tag) && emNode.AffectedSlot != eventSlots[0])
            {
                EffectManagerNodePlan result = _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot);
                return result;
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new WhenYouSummonOtherMinion(_effect.Copy(), _desiredTag);
        }
    }
}
