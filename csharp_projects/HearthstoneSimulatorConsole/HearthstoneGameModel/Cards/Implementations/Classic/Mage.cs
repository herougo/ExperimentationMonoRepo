using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.HandContinuousEffects;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class ManaWyrm : MinionCard
    {
        public ManaWyrm()
        {
            _cardId = CardIds.ManaWyrm;
            _name = "Mana Wyrm";
            _hsClass = HSClass.Mage;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new AfterSpellActivation(PlayerChoice.Player),
                    new ChangeAttack(SelectionConstants.OwnSelf, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new ManaWyrm();
        }
    }

    public class SorcerersApprentice : MinionCard
    {
        public SorcerersApprentice()
        {
            _cardId = CardIds.SorcerersApprentice;
            _name = "Sorcerer's Apprentice";
            _hsClass = HSClass.Mage;
            _collectible = true;

            _mana = 4;
            _attack = 3;
            _health = 2;

            _inPlayEffects = new List<EMEffect> {
                new ContinuousSelectionFieldEffect(
                    SelectionConstants.PlayerHandSpells,
                    new ManaChange(1, -1)
                )
            };
        }

        public override Card Copy()
        {
            return new SorcerersApprentice();
        }
    }

    public class IceBarrier : SpellCard
    {
        public IceBarrier()
        {
            _cardId = CardIds.IceBarrier;
            _name = "Ice Barrier";
            _hsClass = HSClass.Mage;
            _mana = 3;
            _collectible = true;

            _spellType = SpellType.Secret;
            _school = SpellSchool.Frost;

            _whenPlayedEffect = new CreateSecret(
                new WhenAttackDeclared(BattlerFilter.Any, BattlerFilter.YourHero),
                new GainArmour(SelectionConstants.Player, 8)
            );
        }

        public override Card Copy()
        {
            return new IceBarrier();
        }
    }
}
