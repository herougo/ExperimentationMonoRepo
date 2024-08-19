using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class WhenAttackDeclared : Trigger
    {
        BattlerFilter _attackerFilter;
        BattlerFilter _defenderFilter;

        public WhenAttackDeclared(BattlerFilter attackerFilter, BattlerFilter defenderFilter)
        {
            _eventsReceived = new List<string> { EffectEvent.AttackDeclared };
            _attackerFilter = attackerFilter;
            _defenderFilter = defenderFilter;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game, CardSlot affectedSlot, List<CardSlot> eventSlots
        )
        {
            BattlerCardSlot attacker = (BattlerCardSlot)eventSlots[0];
            BattlerCardSlot defender = (BattlerCardSlot)eventSlots[1];

            if (!HSGameUtils.MatchesBattlerFilter(attacker, _attackerFilter, affectedSlot.Player))
            {
                return false;
            }

            if (!HSGameUtils.MatchesBattlerFilter(defender, _defenderFilter, affectedSlot.Player))
            {
                return false;
            }

            // TODO: check if battlers are alive??

            return true;
        }

        public override Trigger Copy()
        {
            return new WhenAttackDeclared(_attackerFilter, _defenderFilter);
        }
    }
}
