using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class WhenSecretPlayed : Trigger
    {
        public WhenSecretPlayed()
        {
            _eventsReceived = new List<string> { EffectEvent.CardPlayed };
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game, CardSlot affectedSlot, List<CardSlot> eventSlots
        )
        {
            CardSlot cardPlayed = eventSlots[0];
            if (cardPlayed.CardType != CardType.Spell)
            {
                return false;
            }

            SpellType spellType = ((SpellCardSlot)cardPlayed).TypedCard.SpellType;
            if (spellType != SpellType.Secret)
            {
                return false;
            }

            return true;
        }

        public override Trigger Copy()
        {
            return new WhenSecretPlayed();
        }
    }
}
