using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Cards
{
    public abstract class Card
    {
        protected string _cardId;
        protected string _name;
        protected string _hsClass;
        protected bool _collectible = true;
        protected int _mana;

        public string CardId { get { return _cardId; } }
        public string Name { get { return _name; } }
        public string HsClass { get {  return _hsClass; } }
        public bool Collectible { get { return _collectible; } }
        public int Mana { get { return _mana; } }

        abstract public CardType CardType { get; }

        public abstract CardSlot CreateCardSlot(int player, HearthstoneGame game);
    }
}
