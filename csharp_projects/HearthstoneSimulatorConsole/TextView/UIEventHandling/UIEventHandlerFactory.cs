﻿using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.UI;
using HearthstoneGameModel.UI.UIEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextView.UIEventHandling.Handlers;

namespace TextView.UIEventHandling
{
    public static class UIEventHandlerFactory
    {
        public static UIEventHandler GetHandler(UIEvent uiEvent, TextUIManager textUiManager)
        {
            switch (uiEvent.EventType)
            {
                // ActionUIEvents
                case UIEventType.ActionCompleted:
                    return new ActionCompletedUIEventHandler(textUiManager);

                // GameMechanicsUIEvents
                case UIEventType.PlayerGoingFirst:
                    return new PlayerGoingFirstUIEventHandler(textUiManager);
                case UIEventType.StartTurn:
                    return new StartTurnUIEventHandler(textUiManager);
                case UIEventType.GameOver:
                    return new GameOverUIEventHandler((GameOverUIEvent)uiEvent, textUiManager);
                case UIEventType.PlayCard:
                    return new PlayCardUIEventHandler((PlayCardUIEvent)uiEvent, textUiManager);
                case UIEventType.SummonMinion:
                    return new SummonMinionUIEventHandler((SummonMinionUIEvent)uiEvent, textUiManager);
                case UIEventType.Attack:
                    return new AttackUIEventHandler((AttackUIEvent)uiEvent, textUiManager);
                case UIEventType.MinionDied:
                    return new MinionDiedUIEventHandler((MinionDiedUIEvent)uiEvent, textUiManager);
                case UIEventType.CardBurned:
                    return new CardBurnedUIEventHandler((CardBurnedUIEvent)uiEvent, textUiManager);
                case UIEventType.MinionReturnedToHand:
                    return new MinionReturnedToHandUIEventHandler((MinionReturnedToHandUIEvent)uiEvent, textUiManager);
                case UIEventType.CardDiscarded:
                    return new CardDiscardedUIEventHandler((CardDiscardedUIEvent)uiEvent, textUiManager);

                // CardEffectUIEvents
                case UIEventType.SecretRevealed:
                    return new SecretRevealedUIEventHandler((SecretRevealedUIEvent)uiEvent, textUiManager);
            }
            throw new NotImplementedException();
        }
    }
}
