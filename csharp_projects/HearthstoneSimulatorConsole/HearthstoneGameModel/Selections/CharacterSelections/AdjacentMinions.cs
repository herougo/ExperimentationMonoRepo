using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CharacterSelections
{
    public class AdjacentMinions : CharacterSelection
    {
        public AdjacentMinions()
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
            int player = cardSlot.Player;
            List<CardSlot> result = new List<CardSlot>();
            int boardIndex = game.Battleboard.CardSlotToBoardIndex(cardSlot);
            int boardLen = game.Battleboard.BoardLen(player);

            if (boardIndex > 0)
            {
                result.Add(game.IndexToSlot(player, boardIndex - 1));
            }
            if (boardIndex < boardLen - 1)
            {
                result.Add(game.IndexToSlot(player, boardIndex + 1));
            }
            return result;
        }

        public override CharacterSelection Copy()
        {
            return new AdjacentMinions();
        }
    }
}
