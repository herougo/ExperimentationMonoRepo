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
    public class OwnSelf : CharacterSelection
    {
        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            CardSlot cardSlot = emNode.AffectedSlot;
            return new List<CardSlot> { cardSlot };
        }

        public override CharacterSelection Copy()
        {
            return new OwnSelf();
        }
    }
}
