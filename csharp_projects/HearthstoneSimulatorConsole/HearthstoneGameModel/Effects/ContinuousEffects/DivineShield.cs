using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class DivineShield : ContinuousEffect
    {
        public DivineShield()
        {
            _eventsReceived = new List<string> {
                EffectEvent.AfterAttackerInitialCombatDamage,
                EffectEvent.AfterDefenderInitialCombatDamage
            };
            _requiresSlotMatchForEvent = true;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            CheckValidEvent(effectEvent);
            bool removeEmNode = false;
            if (effectEvent == EffectEvent.AfterAttackerInitialCombatDamage)
            {
                if (game.GameMetadata.AttackerDamageTaken != 0)
                {
                    game.GameMetadata.AttackerDamageTaken = 0;
                    removeEmNode = true;
                }
            }
            else if (effectEvent == EffectEvent.AfterDefenderInitialCombatDamage)
            {
                if (game.GameMetadata.DefenderDamageTaken != 0)
                {
                    game.GameMetadata.DefenderDamageTaken = 0;
                    removeEmNode = true;
                }
            }

            if (removeEmNode)
            {
                EffectManagerNodePlan plan = new EffectManagerNodePlan();
                plan.ToRemove.Add(emNode);
                return plan;
            }

            return null;
            
        }

        public override EMEffect Copy()
        {
            return new DivineShield();
        }
    }
}
