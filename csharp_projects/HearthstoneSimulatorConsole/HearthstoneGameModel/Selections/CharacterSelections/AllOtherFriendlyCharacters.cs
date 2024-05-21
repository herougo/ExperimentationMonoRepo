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
    public class AllOtherFriendlyCharacters : CharacterSelection
    {
        public AllOtherFriendlyCharacters()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            CardSlot cardSlot = emNode.AffectedSlot;
            int player = cardSlot.Player;
            CardSlot playerSlot = game.Players[player];
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            result.Add(playerSlot);
            result.Remove(cardSlot);
            return result;
        }

        public override CharacterSelection Copy()
        {
            return new AllOtherFriendlyCharacters();
        }
    }
}
