using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class AllMinions : SlotSelection
    {
        public AllMinions()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay, EffectEvent.CardMovedToHand
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> result = new List<CardSlot>();
            result.AddRange(game.Battleboard.GetAllSlots(0));
            result.AddRange(game.Battleboard.GetAllSlots(1));
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllMinions();
        }
    }
}
