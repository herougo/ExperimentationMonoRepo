using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CharacterSelections
{
    public class RandomCharacter : CharacterSelection
    {
        protected CharacterSelection _selection;

        public RandomCharacter(CharacterSelection selection) {
            _selection = selection;
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            List<CardSlot> possibleCardSlots = _selection.GetSelectedCardSlots(game, emNode);
            if (possibleCardSlots.Count == 0)
            {
                return possibleCardSlots;
            }
            int chosen = RandomGenerator.GetRandomInt(0, possibleCardSlots.Count - 1);
            return new List<CardSlot> { possibleCardSlots[chosen] };
        }

        public override CharacterSelection Copy()
        {
            return new RandomCharacter(_selection.Copy());
        }
    }
}
