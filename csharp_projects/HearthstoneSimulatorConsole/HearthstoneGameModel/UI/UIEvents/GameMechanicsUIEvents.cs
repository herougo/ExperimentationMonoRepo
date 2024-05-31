using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.UI.UIEvents
{
    public class PlayerGoingFirstUIEvent : UIEvent
    {
        int _player;

        public PlayerGoingFirstUIEvent(int player)
        {
            _player = player;
        }

        public int Player { get { return _player; } }

        public override UIEventType EventType
        {
            get { return UIEventType.PlayerGoingFirst; }
        }
    }

    public class StartTurnUIEvent : UIEvent
    {
        public override UIEventType EventType
        {
            get { return UIEventType.StartTurn; }
        }
    }

    public class GameOverUIEvent : UIEvent
    {
        bool _player0Dead;
        bool _player1Dead;

        public GameOverUIEvent(bool player0Dead, bool player1Dead)
        {
            _player0Dead = player0Dead;
            _player1Dead = player1Dead;
        }

        public bool Player0Dead { get { return _player0Dead; } }
        public bool Player1Dead { get { return _player1Dead; } }

        public const string PlayCard = "play_card";
        public const string SummonMinion = "summon_minion";
        public const string Attack = "attack";

        public override UIEventType EventType
        {
            get { return UIEventType.GameOver; }
        }
    }

    public class PlayCardUIEvent : UIEvent
    {
        string _cardName;

        public PlayCardUIEvent(string cardName)
        {
            _cardName = cardName;
        }

        public string CardName { get { return _cardName; } }

        public override UIEventType EventType
        {
            get { return UIEventType.PlayCard; }
        }
    }

    public class SummonMinionUIEvent : UIEvent
    {
        int _player;
        string _cardName;

        public SummonMinionUIEvent(int player, string cardName)
        {
            _player = player;
            _cardName = cardName;
        }

        public int Player { get { return _player; } }
        public string CardName { get { return _cardName; } }

        public override UIEventType EventType
        {
            get { return UIEventType.SummonMinion; }
        }
    }

    public class AttackUIEvent : UIEvent
    {
        BattlerCardSlot _attacker;
        BattlerCardSlot _defender;

        public AttackUIEvent(BattlerCardSlot attacker, BattlerCardSlot defender)
        {
            _attacker = attacker;
            _defender = defender;
        }

        public BattlerCardSlot Attacker { get { return _attacker; } }
        public BattlerCardSlot Defender { get { return _defender; } }

        public override UIEventType EventType
        {
            get { return UIEventType.Attack; }
        }
    }

    public class MinionDiedUIEvent : UIEvent
    {
        int _player;
        string _cardName;

        public MinionDiedUIEvent(int player, string cardName)
        {
            _player = player;
            _cardName = cardName;
        }

        public int Player { get { return _player; } }
        public string CardName { get { return _cardName; } }

        public override UIEventType EventType
        {
            get { return UIEventType.MinionDied; }
        }
    }

    public class CardBurnedUIEvent : UIEvent
    {
        int _player;
        string _cardName;

        public CardBurnedUIEvent(int player, string cardName)
        {
            _player = player;
            _cardName = cardName;
        }

        public int Player { get { return _player; } }
        public string CardName { get { return _cardName; } }

        public override UIEventType EventType
        {
            get { return UIEventType.CardBurned; }
        }
    }

    public class MinionReturnedToHandUIEvent : UIEvent
    {
        int _player;
        string _cardName;

        public MinionReturnedToHandUIEvent(int player, string cardName)
        {
            _player = player;
            _cardName = cardName;
        }

        public int Player { get { return _player; } }
        public string CardName { get { return _cardName; } }

        public override UIEventType EventType
        {
            get { return UIEventType.MinionReturnedToHand; }
        }
    }
}
