using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class AllFriendlyMinions : SlotSelection
    {
        public AllFriendlyMinions()
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
            int player = affectedCardSlot.Player;
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllFriendlyMinions();
        }
    }
}
