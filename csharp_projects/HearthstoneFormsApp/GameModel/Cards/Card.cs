using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameModel.Cards.Enums;

namespace GameModel.Cards
{
    public class Card
    {
        protected string _cardId;
        protected string _name;
        protected HSClass _hsClass;
        protected bool _collectible = true;

        public string CardId { get { return _cardId; } }
        public string Name { get { return _name; } }
        public HSClass HsClass { get {  return _hsClass; } }
        public bool Collectible { get { return _collectible; } }
    }
}
