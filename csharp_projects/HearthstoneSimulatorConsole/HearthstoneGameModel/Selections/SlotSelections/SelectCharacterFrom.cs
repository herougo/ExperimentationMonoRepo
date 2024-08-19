using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class SelectCharacterFrom : SlotSelection
    {
        protected SlotSelection _selection;

        public SelectCharacterFrom(SlotSelection selection)
        {
            _selection = selection;
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int player = affectedCardSlot.Player;
            List<CardSlot> options = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            options = filterOptions(options, affectedCardSlot, originCardSlot);
            if (options.Count == 0)
            {
                return options;
            }
            else
            {
                return new List<CardSlot> { game.GetSelectionFromAction(options, player) };
            }
        }

        private List<CardSlot> filterOptions(
            List<CardSlot> options, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> result = new List<CardSlot>();
            foreach (CardSlot slot in options)
            {
                if (slot.CardType == CardType.Minion || slot.CardType == CardType.Hero)
                {
                    BattlerCardSlot battlerSlot = (BattlerCardSlot)slot;
                    if (affectedCardSlot.CardType == CardType.Spell)
                    {
                        if (!HSGameUtils.TargetableWithSpell(battlerSlot, affectedCardSlot.Player))
                        {
                            continue;
                        }
                    }
                    else if (affectedCardSlot.CardType == CardType.Hero)
                    {
                        if (!HSGameUtils.TargetableWithHeroPower(battlerSlot, affectedCardSlot.Player))
                        {
                            // TODO: handle new hero cards
                            continue;
                        }
                    }
                    else if (affectedCardSlot.CardType == CardType.Minion)
                    {
                        if (!HSGameUtils.TargetableWithMinionEffect(battlerSlot, affectedCardSlot.Player))
                        {
                            continue;
                        }
                    }
                }
                result.Add(slot);
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new SelectCharacterFrom(_selection.Copy());
        }
    }
}
