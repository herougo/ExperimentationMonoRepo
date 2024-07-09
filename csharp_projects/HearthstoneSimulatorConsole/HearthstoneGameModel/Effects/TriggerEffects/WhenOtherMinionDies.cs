using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.Utils;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class WhenOtherMinionDies : TriggerEffect
    {
        PlayerChoice _playerChoice;

        public WhenOtherMinionDies(OneTimeEffect effect, PlayerChoice playerChoice)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionDies };
            _playerChoice = playerChoice;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (HSGameUtils.IsPlayerAffected(emNode.AffectedSlot.Player, eventSlots[0].Player, _playerChoice)
                && eventSlots[0] != emNode.AffectedSlot)
            {
                EffectManagerNodePlan result = _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot);
                return result;
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new WhenOtherMinionDies(_effect.Copy(), _playerChoice);
        }
    }
}
