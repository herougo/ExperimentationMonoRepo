using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Conditions;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class AngryChicken : MinionCard
    {
        public AngryChicken()
        {
            _cardId = CardIds.AngryChicken;
            _name = "Angry Chicken";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new ConditionalEffect(
                    new WhileSelfDamaged(),
                    new BuffAttack(5)
                )
            };
        }

        public override Card Copy()
        {
            return new AngryChicken();
        }
    }

    public class BloodsailCorsair : MinionCard
    {
        public BloodsailCorsair()
        {
            _cardId = CardIds.BloodsailCorsair;
            _name = "Bloodsail Corsair";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;

            _inPlayEffects = new List<EMEffect> {
                // TODO
            };
        }

        public override Card Copy()
        {
            return new BloodsailCorsair();
        }
    }

    public class Lightwarden : MinionCard
    {
        public Lightwarden()
        {
            _cardId = CardIds.Lightwarden;
            _name = "Lightwarden";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                // TODO
            };
        }

        public override Card Copy()
        {
            return new Lightwarden();
        }
    }

    public class MurlocTidecaller : MinionCard
    {
        public MurlocTidecaller()
        {
            _cardId = CardIds.MurlocTidecaller;
            _name = "Murloc Tidecaller";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                // TODO
            };
        }

        public override Card Copy()
        {
            return new MurlocTidecaller();
        }
    }
}
