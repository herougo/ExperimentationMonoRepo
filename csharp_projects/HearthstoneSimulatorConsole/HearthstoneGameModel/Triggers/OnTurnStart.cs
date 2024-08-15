using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Selections;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class OnTurnStart : TriggerEffect
    {
        PlayerChoice _playerChoice;

        public OnTurnStart(OneTimeEffect effect, PlayerChoice playerChoice)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.StartTurn };
            _playerChoice = playerChoice;
        }

        public OnTurnStart(OneTimeEffect effect)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.StartTurn };
            _playerChoice = PlayerChoice.Player;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (HSGameUtils.IsPlayerAffected(emNode.AffectedSlot.Player, game.GameMetadata.Turn, _playerChoice))
            {
                EffectManagerNodePlan result = _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot, eventSlots);
                return result;
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new OnTurnStart(_effect.Copy(), _playerChoice);
        }
    }
}
