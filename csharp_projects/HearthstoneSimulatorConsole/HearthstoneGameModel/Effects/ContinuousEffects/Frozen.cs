using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Frozen : ContinuousEffect
    {
        public Frozen() {
            _eventsReceived = new List<string> { EffectEvent.PreEndTurnFrozen };
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumFrozen += 1;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumFrozen -= 1;
            if (typedSlot.NumFrozen < 0)
            {
                throw new Exception("NumFrozen < 0");
            }
            return null;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            CheckValidEvent(effectEvent);
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            if (game.GameMetadata.Turn == typedSlot.Player
                && typedSlot.AttacksThisTurn < typedSlot.NumPossibleAttacksIgnoringFrozen)
            {
                EffectManagerNodePlan plan = new EffectManagerNodePlan();
                plan.ToRemove.Add(emNode);
                return plan;
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new Frozen();
        }
    }
}
