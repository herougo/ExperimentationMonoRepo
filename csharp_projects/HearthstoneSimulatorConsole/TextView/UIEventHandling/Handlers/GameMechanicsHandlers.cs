using HearthstoneGameModel.Game;
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
}
