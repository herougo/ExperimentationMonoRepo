using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class AllFriendlyCharacters : SlotSelection
    {
        public AllFriendlyCharacters() {
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
            CardSlot playerSlot = game.Players[player];
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            result.Add(playerSlot);
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllFriendlyCharacters();
        }
    }
}
