﻿using HearthstoneGameModel.Game;
using HearthstoneGameModel.UI;
using HearthstoneGameModel.UI.UIEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView.UIEventHandling.Handlers
{
    public class PlayerGoingFirstUIEventHandler : UIEventHandler
    {
        TextUIManager _textUiManager;

        public PlayerGoingFirstUIEventHandler(
            TextUIManager textUIManager
        )
        {
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogPlayerGoingFirst();
        }
    }

    public class StartTurnUIEventHandler : UIEventHandler
    {
        TextUIManager _textUiManager;

        public StartTurnUIEventHandler(
            TextUIManager textUIManager
        )
        {
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogTurn();
            _textUiManager.TextUILogger.LogGameState();
        }
    }

    public class GameOverUIEventHandler : UIEventHandler
    {
        GameOverUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public GameOverUIEventHandler(
            GameOverUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogGameOverResult(
                _uiEvent.Player0Dead, _uiEvent.Player1Dead
            );
        }
    }

    public class PlayCardUIEventHandler : UIEventHandler
    {
        PlayCardUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public PlayCardUIEventHandler(
            PlayCardUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogPlayCard(_uiEvent.CardName);
        }
    }

    public class SummonMinionUIEventHandler : UIEventHandler
    {
        SummonMinionUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public SummonMinionUIEventHandler(
            SummonMinionUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogSummonMinion(_uiEvent.Player, _uiEvent.CardName);
        }
    }

    public class AttackUIEventHandler : UIEventHandler
    {
        AttackUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public AttackUIEventHandler(
            AttackUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogAttack(
                _uiEvent.Attacker, _uiEvent.Defender
            );
        }
    }

    public class MinionDiedUIEventHandler : UIEventHandler
    {
        MinionDiedUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public MinionDiedUIEventHandler(
            MinionDiedUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogMinionDied(_uiEvent.Player, _uiEvent.CardName);
        }
    }

    public class CardBurnedUIEventHandler : UIEventHandler
    {
        CardBurnedUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public CardBurnedUIEventHandler(
            CardBurnedUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogCardBurned(_uiEvent.Player, _uiEvent.CardName);
        }
    }

    public class MinionReturnedToHandUIEventHandler : UIEventHandler
    {
        MinionReturnedToHandUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public MinionReturnedToHandUIEventHandler(
            MinionReturnedToHandUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogMinionReturnedToHand(_uiEvent.Player, _uiEvent.CardName);
        }
    }

    public class BattleboardChangedUIEventHandler : UIEventHandler
    {
        TextUIManager _textUiManager;

        public BattleboardChangedUIEventHandler(
            TextUIManager textUIManager
        )
        {
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogGameState();
        }
    }

    public class CardDiscardedUIEventHandler : UIEventHandler
    {
        CardDiscardedUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public CardDiscardedUIEventHandler(
            CardDiscardedUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogCardDiscarded(_uiEvent.Player, _uiEvent.CardName);
        }
    }
}
