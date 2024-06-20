using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class HandSelection : SlotSelection
    {
        bool _opposing;

        public HandSelection(bool opposing) {
            _opposing = opposing;
            _eventsReceived = new List<string>
            {
                EffectEvent.CardPlayed, EffectEvent.CardMovedToHand
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            int player = cardSlot.Player;
            if (_opposing)
            {
                player = 1 - player;
            }
            List<CardSlot> result = new List<CardSlot>();
            foreach (CardSlot handCardSlot in game.Hands[player])
            {
                result.Add(handCardSlot);
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new HandSelection(_opposing);
        }
    }
}
