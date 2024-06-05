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
    public class AllOtherCharacters : SlotSelection
    {
        public AllOtherCharacters()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            List<CardSlot> result = game.Players.ToList<CardSlot>();
            result.AddRange(game.Battleboard.GetAllSlots(0));
            result.AddRange(game.Battleboard.GetAllSlots(1));
            result.Remove(cardSlot);
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllOtherCharacters();
        }
    }
}
