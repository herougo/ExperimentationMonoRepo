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
    public class AllOtherCharacters : CharacterSelection
    {
        public AllOtherCharacters()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            CardSlot cardSlot = emNode.AffectedSlot;
            List<CardSlot> result = game.Players.ToList<CardSlot>();
            result.AddRange(game.Battleboard.GetAllSlots(0));
            result.AddRange(game.Battleboard.GetAllSlots(1));
            result.Remove(cardSlot);
            return result;
        }

        public override CharacterSelection Copy()
        {
            return new AllOtherCharacters();
        }
    }
}
