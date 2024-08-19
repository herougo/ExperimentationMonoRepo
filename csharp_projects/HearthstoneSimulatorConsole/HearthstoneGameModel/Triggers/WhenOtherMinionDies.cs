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
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Triggers
{
    public class WhenOtherMinionDies : Trigger
    {
        PlayerChoice _playerChoice;
        MinionTag _minionTag;

        public WhenOtherMinionDies(PlayerChoice playerChoice)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionDies };
            _playerChoice = playerChoice;
            _minionTag = MinionTag.Any;
        }

        public WhenOtherMinionDies(PlayerChoice playerChoice, MinionTag minionTag)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionDies };
            _playerChoice = playerChoice;
            _minionTag = minionTag;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            CardSlot affectedSlot, List<CardSlot> eventSlots)
        {
            MinionCardSlot slot = (MinionCardSlot)eventSlots[0];
            return (
                HSGameUtils.IsPlayerAffected(affectedSlot.Player, slot.Player, _playerChoice)
                && HSGameUtils.MatchesTag(_minionTag, slot.TypedCard.Tag)
                && slot != affectedSlot
            );
        }

        public override Trigger Copy()
        {
            return new WhenOtherMinionDies(_playerChoice, _minionTag);
        }
    }
}
