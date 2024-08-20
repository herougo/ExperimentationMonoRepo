using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    internal class LoseEMEffect : OneTimeEffect
    {
        SlotSelection _selection;
        EMEffectType _effectType;

        public LoseEMEffect(SlotSelection selection, EMEffectType effectType)
        {
            _selection = selection;
            _effectType = effectType;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedSlots = _selection.GetSelectedCardSlots(
                game, affectedCardSlot, originCardSlot, eventSlots
            );
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            foreach (CardSlot slot in selectedSlots)
            {
                foreach (EffectManagerNode emNode in slot.GetEMNodes())
                {
                    if (emNode.Effect.EffectType == _effectType)
                    {
                        plan.ToRemove.Add(emNode);
                        break;
                    }
                }
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new LoseEMEffect(_selection.Copy(), _effectType);
        }
    }
}
