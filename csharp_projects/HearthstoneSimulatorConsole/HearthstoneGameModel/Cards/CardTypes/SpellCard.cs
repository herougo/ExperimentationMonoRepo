using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects;

namespace HearthstoneGameModel.Cards.CardTypes
{
    public abstract class SpellCard : Card
    {
        protected OneTimeEffect _whenPlayedEffect;
        
        public OneTimeEffect WhenPlayedEffect { get { return _whenPlayedEffect; } }

        public override CardType CardType { get { return CardType.Spell; } }

        public override CardSlot CreateCardSlot(int player, HearthstoneGame game)
        {
            return new SpellCardSlot(_cardId, player, game);
        }
    }
}
