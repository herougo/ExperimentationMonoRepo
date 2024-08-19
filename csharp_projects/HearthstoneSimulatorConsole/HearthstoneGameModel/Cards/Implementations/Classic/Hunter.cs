using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
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

            _school = SpellSchool.Fire;

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

    public class FreezingTrap : SpellCard
    {
        public FreezingTrap()
        {
            _cardId = CardIds.FreezingTrap;
            _name = "Freezing Trap";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _school = SpellSchool.Frost;

            _whenPlayedEffect = new CreateSecret(
                new WhenAttackDeclared(BattlerFilter.EnemyMinion, BattlerFilter.Any),
                new ReturnMinionToHandAndChangeMana(
                    SelectionConstants.EventSlot0, 2
                )
            );
        }

        public override Card Copy()
        {
            return new FreezingTrap();
        }
    }

    public class Snipe : SpellCard
    {
        public Snipe()
        {
            _cardId = CardIds.Snipe;
            _name = "Snipe";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _whenPlayedEffect = new CreateSecret(
                new WhenOpponentPlaysLivingMinion(),
                new DealDamage(SelectionConstants.EventSlot0, 4)
            );
        }

        public override Card Copy()
        {
            return new Snipe();
        }
    }
}
