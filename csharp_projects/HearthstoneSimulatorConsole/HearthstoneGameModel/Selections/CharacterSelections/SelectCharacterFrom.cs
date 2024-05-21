using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CharacterSelections
{
    public class SelectCharacterFrom : CharacterSelection
    {
        protected CharacterSelection _selection;

        public SelectCharacterFrom(CharacterSelection selection)
        {
            _selection = selection;
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            List<CardSlot> options = _selection.GetSelectedCardSlots(game, emNode);
            options = filterBasedOnEmNode(options);
            if (options.Count == 0)
            {
                return options;
            }
            else
            {
                return new List<CardSlot> { game.GetSelectionFromAction(options, player) };
            }
        }

        private List<CardSlot> filterBasedOnEmNode(List<CardSlot> options)
        {
            // TODO: 
            return options;
        }

        public override CharacterSelection Copy()
        {
            return new SelectCharacterFrom(_selection.Copy());
        }
    }
}
