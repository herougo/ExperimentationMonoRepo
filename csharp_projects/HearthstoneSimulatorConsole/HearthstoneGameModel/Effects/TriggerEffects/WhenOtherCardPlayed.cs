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
    public class WhenOtherCardPlayed : TriggerEffect
    {
        PlayerChoice _playerMatch;

        public WhenOtherCardPlayed(OneTimeEffect effect, PlayerChoice playerMatch)
            :base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.WhenCardPlayed };
            _playerMatch = playerMatch;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (eventSlots[0] == emNode.AffectedSlot)
            {
                return null;
            }
            int eventPlayer = eventSlots[0].Player;
            int effectPlayer = emNode.AffectedSlot.Player;

            if (!HSGameUtils.IsPlayerAffected(effectPlayer, eventPlayer, _playerMatch))
            {
                return null;
            }
            return _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot, eventSlots);
        }

        public override EMEffect Copy()
        {
            return new WhenOtherCardPlayed(_effect.Copy(), _playerMatch);
        }
    }
}
