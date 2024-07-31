using HearthstoneGameModel.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class GraveyardTrackerEntry
    {
        Card _card;
        int _player;
        int _turnDied;
        
        public GraveyardTrackerEntry(Card card, int player, int turnDied)
        {
            _card = card;
            _player = player;
            _turnDied = turnDied;
        }

        public Card Card { get { return _card; } }

        public int Player { get { return _player; } }

        public int TurnDied { get {  return _turnDied; } }
    }
}
