using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class GiveContinuousEffect : OneTimeEffect
    {
        SlotSelection _selection;
        ContinuousEffect _effect;

        public GiveContinuousEffect(SlotSelection selection, ContinuousEffect effect)
        {
            _selection = selection;
            _effect = effect;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                EffectManagerNode newEmNode = new EffectManagerNode(
                    _effect.Copy(), selectedCardSlot, originCardSlot, true
                );
                plan.ToAdd.Add(newEmNode);
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new GiveContinuousEffect(_selection.Copy(), (ContinuousEffect)_effect.Copy());
        }
    }
}
