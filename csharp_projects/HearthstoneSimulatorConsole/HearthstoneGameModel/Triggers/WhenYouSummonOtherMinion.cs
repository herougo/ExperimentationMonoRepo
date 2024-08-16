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
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Triggers
{
    public class WhenYouSummonOtherMinion : Trigger
    {
        MinionTag _desiredTag;

        public WhenYouSummonOtherMinion(MinionTag desiredTag)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionSummoned };
            _requiresSlotPlayerMatchForEvent = true;
            _desiredTag = desiredTag;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            CardSlot affectedSlot, List<CardSlot> eventSlots)
        {
            MinionCard minionCard = (MinionCard)eventSlots[0].Card;
            return (
                HSGameUtils.MatchesTag(_desiredTag, minionCard.Tag)
                && affectedSlot != eventSlots[0]
            );
        }

        public override Trigger Copy()
        {
            return new WhenYouSummonOtherMinion(_desiredTag);
        }
    }
}
