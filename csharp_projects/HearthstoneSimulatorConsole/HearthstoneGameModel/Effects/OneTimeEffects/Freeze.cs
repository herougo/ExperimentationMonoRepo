using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.ContinuousEffects;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class Freeze : OneTimeEffect
    {
        SlotSelection _selection;

        public Freeze(SlotSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                EffectManagerNode newEmNode = new EffectManagerNode(
                    new Frozen(), selectedCardSlot, originCardSlot, true
                );
                plan.ToAdd.Add(newEmNode);
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new Freeze(_selection.Copy());
        }
    }
}
