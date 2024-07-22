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
        List<ContinuousEffect> _effects;

        public GiveContinuousEffect(SlotSelection selection, ContinuousEffect effect)
        {
            _selection = selection;
            _effects = new List<ContinuousEffect> { effect };
        }

        public GiveContinuousEffect(SlotSelection selection, List<ContinuousEffect> effects)
        {
            _selection = selection;
            _effects = effects;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                foreach (ContinuousEffect effect in _effects)
                {
                    EffectManagerNode newEmNode = new EffectManagerNode(
                        effect.Copy(), selectedCardSlot, originCardSlot, true
                    );
                    plan.ToAdd.Add(newEmNode);
                }
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            List<ContinuousEffect> effectsCopy = new List<ContinuousEffect>();
            foreach (ContinuousEffect effect in _effects)
            {
                effectsCopy.Add((ContinuousEffect)effect.Copy());
            }
            return new GiveContinuousEffect(_selection.Copy(), effectsCopy);
        }
    }
}
