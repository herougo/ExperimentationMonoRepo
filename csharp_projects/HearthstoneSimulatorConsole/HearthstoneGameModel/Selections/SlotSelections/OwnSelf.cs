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
    public class OwnSelf : SlotSelection
    {
        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            return new List<CardSlot> { cardSlot };
        }

        public override SlotSelection Copy()
        {
            return new OwnSelf();
        }
    }
}
