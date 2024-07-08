using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class EventCardSlotToEMNodeListDictionary
    {
        // Maps event to a dictionary mapping card slot to an EffectManagerNodeList.
        // This also handles Player0Hash and NullHash

        Dictionary<
            string,
            Dictionary<
                CardSlot,
                PrioritizedEffectManagerNodeList
            >
        > _slotSpecificData = new Dictionary<
            string,
            Dictionary<
                CardSlot,
                PrioritizedEffectManagerNodeList
            >
        >();
        Dictionary<
            string,
            Dictionary<
                int,
                PrioritizedEffectManagerNodeList
            >
        > _playerAndNullData = new Dictionary<
            string,
            Dictionary<
                int,
                PrioritizedEffectManagerNodeList
            >
        >();

        public void Add(string effectEvent, EffectManagerNode emNode)
        {
            CardSlot slot = emNode.AffectedSlot;
            if (!_slotSpecificData.ContainsKey(effectEvent))
            {
                _slotSpecificData[effectEvent] = new Dictionary<CardSlot, PrioritizedEffectManagerNodeList>();
                _playerAndNullData[effectEvent] = new Dictionary<int, PrioritizedEffectManagerNodeList>();
                _playerAndNullData[effectEvent][HashGenerator.NullHash] = new PrioritizedEffectManagerNodeList();
                _playerAndNullData[effectEvent][HashGenerator.Player0Hash] = new PrioritizedEffectManagerNodeList();
                _playerAndNullData[effectEvent][HashGenerator.Player1Hash] = new PrioritizedEffectManagerNodeList();
            }

            if (emNode.Effect.RequiresSlotMatchForEvent)
            {
                Dictionary<CardSlot, PrioritizedEffectManagerNodeList> slotToEmNodeList = _slotSpecificData[effectEvent];
                if (!slotToEmNodeList.ContainsKey(slot))
                {
                    slotToEmNodeList[slot] = new PrioritizedEffectManagerNodeList();
                }
                slotToEmNodeList[slot].Append(emNode);

            }
            else if (emNode.Effect.RequiresSlotPlayerMatchForEvent)
            {
                int player = slot.Player;
                _playerAndNullData[effectEvent][player].Append(emNode);
            }
            else
            {
                _playerAndNullData[effectEvent][HashGenerator.NullHash].Append(emNode);
            }
        }

        public void Remove(string effectEvent, EffectManagerNode emNode)
        {
            CardSlot slot = emNode.AffectedSlot;

            if (emNode.Effect.RequiresSlotMatchForEvent)
            {
                _slotSpecificData[effectEvent][slot].Remove(emNode);

            }
            else if (emNode.Effect.RequiresSlotPlayerMatchForEvent)
            {
                int player = slot.Player;
                _playerAndNullData[effectEvent][player].Remove(emNode);
            }
            else
            {
                _playerAndNullData[effectEvent][HashGenerator.NullHash].Remove(emNode);
            }
        }

        public List<EffectManagerNode> GetRelevantEMNodes(string effectEvent)
        {
            return GetRelevantEMNodes(effectEvent, null);
        }

        public List<EffectManagerNode> GetRelevantEMNodes(string effectEvent, CardSlot eventCardSlot)
        {
            List<EffectManagerNode> result = new List<EffectManagerNode>();

            if (_playerAndNullData.ContainsKey(effectEvent))
            {
                foreach (EffectManagerNode emNode in _playerAndNullData[effectEvent][HashGenerator.NullHash])
                {
                    result.Add(emNode);
                }

                if (eventCardSlot != null)
                {
                    int player = eventCardSlot.Player;
                    if (_playerAndNullData[effectEvent].ContainsKey(player))
                    {
                        foreach (EffectManagerNode emNode in _playerAndNullData[effectEvent][player])
                        {
                            result.Add(emNode);
                        }
                    }
                }
            }

            if (_slotSpecificData.ContainsKey(effectEvent) && eventCardSlot != null
                && _slotSpecificData[effectEvent].ContainsKey(eventCardSlot))
            {
                foreach (EffectManagerNode emNode in _slotSpecificData[effectEvent][eventCardSlot])
                {
                    result.Add(emNode);
                }
            }

            return result;
        }
    }
}
