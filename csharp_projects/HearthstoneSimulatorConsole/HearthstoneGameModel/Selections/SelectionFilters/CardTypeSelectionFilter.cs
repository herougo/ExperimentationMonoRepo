﻿using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SelectionFilters
{
    public class CardTypeSelectionFilter : SelectionFilter
    {
        CardType _desiredCardType;

        public CardTypeSelectionFilter(CardType desiredCardType)
        {
            _desiredCardType = desiredCardType;
        }

        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(slot => slot.CardType == _desiredCardType).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new CardTypeSelectionFilter(_desiredCardType);
        }
    }
}
