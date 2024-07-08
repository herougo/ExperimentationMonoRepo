using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class EffectManager
    {
        HearthstoneGame _game;
        HashSet<EffectManagerNode> _emNodes = new HashSet<EffectManagerNode>();
        Dictionary<EffectManagerNode, List<string>> _emNodeToEvents = new Dictionary<EffectManagerNode, List<string>>();
        EventCardSlotToEMNodeListDictionary _eventToEffectNodeList = new EventCardSlotToEMNodeListDictionary();
        Dictionary<CardSlot, PrioritizedEffectManagerNodeList> _slotToEmNodeList = new Dictionary<CardSlot, PrioritizedEffectManagerNodeList>();

        public EffectManager(HearthstoneGame game) {
            _game = game;
        }

        public void AddToEmNodeToEvents(EffectManagerNode emNode, string receivedEvent)
        {
            if (!_emNodeToEvents.ContainsKey(emNode))
            {
                _emNodeToEvents[emNode] = new List<string>();
            }
            _emNodeToEvents[emNode].Add(receivedEvent);
        }

        public void AddToSlotToEmNodeList(EffectManagerNode emNode)
        {
            CardSlot slot = emNode.AffectedSlot;
            if (!_slotToEmNodeList.ContainsKey(slot))
            {
                _slotToEmNodeList[slot] = new PrioritizedEffectManagerNodeList();
            }
            _slotToEmNodeList[slot].Append(emNode);
        }

        public void AddEffect(EffectManagerNode emNode)
        {
            _emNodes.Add(emNode);
            foreach (string receivedEvent in emNode.Effect.EventsReceived)
            {
                AddToEmNodeToEvents(emNode, receivedEvent);
                _eventToEffectNodeList.Add(receivedEvent, emNode);

            }
            AddToSlotToEmNodeList(emNode);

            EffectManagerNodePlan plan = emNode.Start(_game, this);
            performPlan(plan);
        }

        public void PopEffect(EffectManagerNode emNode)
        {
            CardSlot slot = emNode.AffectedSlot;
            EffectManagerNodePlan plan = emNode.Stop(_game, this);
            if (_emNodeToEvents.ContainsKey(emNode))
            {
                foreach (string effectEvent in _emNodeToEvents[emNode])
                {
                    _eventToEffectNodeList.Remove(effectEvent, emNode);
                }
            }

            _slotToEmNodeList[slot].Remove(emNode);
            _emNodes.Remove(emNode);
            _emNodeToEvents.Remove(emNode);

            performPlan(plan);
        }

        public List<EffectManagerNode> GetRelevantEMNodes(CardSlot cardSlot)
        {
            List<EffectManagerNode> result = new List<EffectManagerNode>();
            if (_slotToEmNodeList.ContainsKey(cardSlot))
            {
                foreach (EffectManagerNode emNode in _slotToEmNodeList[cardSlot])
                {
                    result.Add(emNode);
                }
            }
            return result;
        }

        public void PopEffectsBySlot(CardSlot cardSlot, bool handOnly)
        {
            if (!_slotToEmNodeList.ContainsKey(cardSlot))
            {
                return;
            }

            List<EffectManagerNode> emNodes = _slotToEmNodeList[cardSlot].ToList();
            emNodes.Reverse();
            foreach (EffectManagerNode emNode in emNodes)
            {
                if (!emNode.Effect.IsExternal && (!handOnly || emNode.Effect.IsHandEffect))
                {
                    PopEffect(emNode);
                }
            }
        }

        public void PopEffectsBySlot(CardSlot cardSlot)
        {
            PopEffectsBySlot(cardSlot, false);
        }

        public void SendEvent(string effectEvent, CardSlot eventSlot)
        {
            List<EffectManagerNode> relevantEMNodes = _eventToEffectNodeList.GetRelevantEMNodes(effectEvent, eventSlot);
            foreach (EffectManagerNode emNode in relevantEMNodes)
            {
                emNode.SendEvent(effectEvent, _game, this, eventSlot);
            }
            _game.KillIfNecessary();
        }

        public void SendEvent(string effectEvent)
        {
            SendEvent(effectEvent, null);
        }

        public void SendEvent(EffectEventArgs args)
        {
            SendEvent(args.EffectEvent, args.EventSlot);
        }

        public void Execute(OneTimeEffect effect, HearthstoneGame game, CardSlot cardSlot)
        {
            EffectManagerNodePlan plan = effect.Execute(game, cardSlot, cardSlot);
            performPlan(plan);
        }

        private void performPlan(EffectManagerNodePlan plan)
        {
            if (plan != null)
            {
                plan.Perform(this);
                _game.KillIfNecessary();
            }
        }

        public void AddInPlayEffects(CardSlot cardSlot)
        {
            foreach (EMEffect effect in cardSlot.Card.InPlayEffects)
            {
                EffectManagerNode emNode = new EffectManagerNode(
                    effect, cardSlot, cardSlot, true
                );
                AddEffect(emNode);
            }
        }

        public void AddInHandEffects(CardSlot cardSlot)
        {
            foreach (EMEffect effect in cardSlot.Card.InHandEffects)
            {
                EffectManagerNode emNode = new EffectManagerNode(
                    effect, cardSlot, cardSlot, false
                );
                AddEffect(emNode);
            }
        }
    }
}
