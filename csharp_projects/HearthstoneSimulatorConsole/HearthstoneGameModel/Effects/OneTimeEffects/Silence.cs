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
    public class Silence : OneTimeEffect
    {
        SlotSelection _selection;

        public Silence(SlotSelection selection) {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            
            foreach (CardSlot slot in selectedCardSlots)
            {
                slot.Silenced = true;
                foreach (EffectManagerNode emNode in game.EffectManager.GetRelevantEMNodes(slot))
                {
                    if (emNode.Silenceable)
                    {
                        plan.ToRemove.Add(emNode);
                    }
                }
            }

            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new Silence(_selection.Copy());
        }
    }
}
