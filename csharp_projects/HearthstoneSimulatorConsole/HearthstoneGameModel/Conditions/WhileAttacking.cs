using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Conditions
{
    public class WhileAttacking : Condition
    {
        public WhileAttacking()
        {
            _eventsReceived = new List<string> {
                EffectEvent.BeforeAttackDeclared, EffectEvent.AttackFinished, EffectEvent.AttackAborted
            };
        }

        public override bool Evaluate(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            CardSlot slot = emNode.AffectedSlot;

            bool result =  effectEvent == EffectEvent.BeforeAttackDeclared
                           && (eventSlots.Count > 0 && slot == eventSlots[0]);

            return result;
        }

        public override Condition Copy()
        {
            return new WhileAttacking();
        }
    }
}
