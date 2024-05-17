using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Heroes
{
    public class SilverHandRecruit : MinionCard
    {
        public SilverHandRecruit() {
            _cardId = "HU002";
            _name = "Silver Hand Recruit";
            _hsClass = HSClass.Paladin;
            _mana = 1;
            _collectible = false;

            _attack = 1;
            _health = 1;
        }
    }
}
