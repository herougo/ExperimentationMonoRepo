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
    public class AllFriendlyMinions : CharacterSelection
    {
        public AllFriendlyMinions()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            return result;
        }

        public override CharacterSelection Copy()
        {
            return new AllFriendlyMinions();
        }
    }
}
