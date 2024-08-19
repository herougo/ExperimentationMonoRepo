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
    public class WhenOpponentPlaysLivingMinion : Trigger
    {
        public WhenOpponentPlaysLivingMinion()
        {
            _eventsReceived = new List<string> { EffectEvent.CardPlayed };
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            CardSlot affectedSlot, List<CardSlot> eventSlots)
        {
            CardSlot slot = eventSlots[0];

            if (affectedSlot.Player == slot.Player)
            {
                return false;
            }

            if (slot.CardType != CardType.Minion)
            {
                return false;
            }

            MinionCardSlot typedSlot = (MinionCardSlot)slot;
            if (!typedSlot.IsAlive)
            {
                return false;
            }

            return true;
        }

        public override Trigger Copy()
        {
            return new WhenOpponentPlaysLivingMinion();
        }
    }
}
