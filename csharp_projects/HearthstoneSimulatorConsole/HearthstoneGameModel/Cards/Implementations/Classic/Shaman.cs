using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Selections.SlotSelections;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class EarthShock : SpellCard
    {
        public EarthShock()
        {
            _cardId = CardIds.EarthShock;
            _name = "Earth Shock";
            _hsClass = HSClass.Shaman;
            _mana = 1;
            _collectible = true;

            _whenPlayedEffect = new OneTimeEffectSequence(new List<OneTimeEffect> {
                new SilenceAndDealDamage(new SelectCharacterFrom(SelectionConstants.AllMinions), 1)
            });
        }

        public override Card Copy()
        {
            return new EarthShock();
        }
    }
}
