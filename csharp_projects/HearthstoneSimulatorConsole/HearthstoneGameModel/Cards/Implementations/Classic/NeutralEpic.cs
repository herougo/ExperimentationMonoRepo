﻿using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.JoinedOneTimeEffects;
using HearthstoneGameModel.Selections.SelectionFilters;
using HearthstoneGameModel.Selections.SlotSelections;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class HungryCrab : MinionCard
    {
        public HungryCrab()
        {
            _cardId = CardIds.HungryCrab;
            _name = "Hungry Crab";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new DestroyMinionAndBuff(
                    new SelectCharacterFrom(SelectionConstants.AllOtherMinions & new TagSelectionFilter(MinionTag.Murloc)),
                    SelectionConstants.OwnSelf,
                    2,
                    2
                ))
            };
        }

        public override Card Copy()
        {
            return new HungryCrab();
        }
    }

    public class Doomsayer : MinionCard
    {
        public Doomsayer()
        {
            _cardId = CardIds.Doomsayer;
            _name = "Doomsayer";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 0;
            _health = 7;

            _inPlayEffects = new List<EMEffect>
            {
                new OnTurnStart(new DestroyMinion(SelectionConstants.AllMinions), PlayerChoice.Player)
            };
        }

        public override Card Copy()
        {
            return new Doomsayer();
        }
    }
}