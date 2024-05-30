using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations
{
    public class Coin : SpellCard
    {
        public Coin() {
            _cardId = CardIds.Coin;
            _name = "Coin";
            _hsClass = HSClass.Neutral;
            _mana = 0;
            _collectible = false;

            _whenPlayedEffect = new GainCurrentManaCrystals(
                SelectionConstants.Player,
                1
            );
        }

        public override Card Copy()
        {
            return new Coin();
        }
    }
}
