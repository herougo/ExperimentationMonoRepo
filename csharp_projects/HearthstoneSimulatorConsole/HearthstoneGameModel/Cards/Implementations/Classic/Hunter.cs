using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class ExplosiveTrap : SpellCard
    {
        public ExplosiveTrap()
        {
            _cardId = CardIds.ExplosiveTrap;
            _name = "Explosive Trap";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _whenPlayedEffect = new CreateSecret(
                new WhenAttackDeclared(BattlerFilter.Any, BattlerFilter.YourHero),
                new DealDamage(SelectionConstants.OtherLivingEnemies, 2)
            );
        }

        public override Card Copy()
        {
            return new ExplosiveTrap();
        }
    }
}
