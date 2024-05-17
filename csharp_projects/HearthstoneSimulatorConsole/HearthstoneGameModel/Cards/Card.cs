using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Cards
{
    public abstract class Card
    {
        protected string _cardId;
        protected string _name;
        protected string _hsClass;
        protected int _mana;
        protected bool _collectible = true;
        protected List<EMEffect> _inPlayEffects = new List<EMEffect>();

        public string CardId { get { return _cardId; } }
        public string Name { get { return _name; } }
        public string HsClass { get {  return _hsClass; } }
        public bool Collectible { get { return _collectible; } }
        public int Mana { get { return _mana; } }

        public List<EMEffect> InPlayEffects { get { return _inPlayEffects; } }

        abstract public CardType CardType { get; }

        public abstract CardSlot CreateCardSlot(int player, HearthstoneGame game);

        public Card Copy()
        {
            return CardFactory.CreateCard(_cardId);
        }
    }
}
