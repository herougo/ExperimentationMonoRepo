using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class ContinuousSelectionFieldEffect : ContinuousEffect
    {
        SlotSelection _selection;
        EMEffect _effect;
        Dictionary<CardSlot, EffectManagerNode> _memoryCurrentSelection;

        public ContinuousSelectionFieldEffect(SlotSelection selection, EMEffect effect)
        {
            _selection = selection;
            _effect = effect;
            _eventsReceived.AddRange(selection.EventsReceived);
            _memoryCurrentSelection = new Dictionary<CardSlot, EffectManagerNode>();
        }

        private EffectManagerNodePlan reEvaluateSelection(HearthstoneGame game, EffectManagerNode emNode)
        {
            HashSet<CardSlot> prevSelectedSlots = _memoryCurrentSelection.Keys.ToHashSet<CardSlot>();
            HashSet<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(
                game, emNode.AffectedSlot, emNode.OriginSlot
            ).ToHashSet();

            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot slot in prevSelectedSlots)
            {
                if (!selectedCardSlots.Contains(slot))
                {
                    plan.ToRemove.Add(_memoryCurrentSelection[slot]);
                    _memoryCurrentSelection.Remove(slot);
                }
            }

            foreach (CardSlot slot in selectedCardSlots)
            {
                if (!prevSelectedSlots.Contains(slot))
                {
                    ExternalEffect effect = new ExternalEffect(_effect.Copy());
                    EffectManagerNode node = new EffectManagerNode(
                        effect, slot, emNode.AffectedSlot, false
                    );
                    plan.ToAdd.Add(node);
                    _memoryCurrentSelection[slot] = node;
                }
            }

            return plan;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            CheckValidEvent(effectEvent);
            return reEvaluateSelection(game, emNode);
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            return reEvaluateSelection(game, emNode);
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            
            foreach (CardSlot slot in _memoryCurrentSelection.Keys)
            {
                plan.ToRemove.Add(_memoryCurrentSelection[slot]);
            }
            return plan;
        }

        public override EMEffect Copy()
        {
            return new ContinuousSelectionFieldEffect(_selection.Copy(), _effect.Copy());
        }
    }
}
