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
    public class GiveEMEffect : OneTimeEffect
    {
        SlotSelection _selection;
        List<EMEffect> _effects;

        public GiveEMEffect(SlotSelection selection, EMEffect effect)
        {
            _selection = selection;
            _effects = new List<EMEffect> { effect };
        }

        public GiveEMEffect(SlotSelection selection, List<EMEffect> effects)
        {
            _selection = selection;
            _effects = effects;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                foreach (EMEffect effect in _effects)
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
            List<EMEffect> effectsCopy = new List<EMEffect>();
            foreach (EMEffect effect in _effects)
            {
                effectsCopy.Add(effect.Copy());
            }
            return new GiveEMEffect(_selection.Copy(), effectsCopy);
        }
    }
}
