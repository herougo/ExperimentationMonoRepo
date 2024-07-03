using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class RandomCharacterFrom : SlotSelection
    {
        protected SlotSelection _selection;

        public RandomCharacterFrom(SlotSelection selection) {
            _selection = selection;
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> possibleCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            if (possibleCardSlots.Count == 0)
            {
                return possibleCardSlots;
            }
            int chosen = RandomGenerator.GetRandomInt(0, possibleCardSlots.Count - 1);
            return new List<CardSlot> { possibleCardSlots[chosen] };
        }

        public override SlotSelection Copy()
        {
            return new RandomCharacterFrom(_selection.Copy());
        }
    }
}
