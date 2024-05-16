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
                EffectManagerNodeList
            >
        > _slotSpecificData = new Dictionary<
            string,
            Dictionary<
                CardSlot,
                EffectManagerNodeList
            >
        >();
        Dictionary<
            string,
            Dictionary<
                int,
                EffectManagerNodeList
            >
        > _playerAndNullData = new Dictionary<
            string,
            Dictionary<
                int,
                EffectManagerNodeList
            >
        >();

        public void Add(string effectEvent, EffectManagerNode emNode)
        {
            CardSlot slot = emNode.AffectedSlot;
            if (!_slotSpecificData.ContainsKey(effectEvent))
            {
                _slotSpecificData[effectEvent] = new Dictionary<CardSlot, EffectManagerNodeList>();
                _playerAndNullData[effectEvent] = new Dictionary<int, EffectManagerNodeList>();
                _playerAndNullData[effectEvent][HashGenerator.NullHash] = new EffectManagerNodeList();
                _playerAndNullData[effectEvent][HashGenerator.Player0Hash] = new EffectManagerNodeList();
                _playerAndNullData[effectEvent][HashGenerator.Player1Hash] = new EffectManagerNodeList();
            }

            if (emNode.Effect.RequiresSlotMatchForEvent)
            {
                Dictionary<CardSlot, EffectManagerNodeList> slotToEmNodeList = _slotSpecificData[effectEvent];
                if (!slotToEmNodeList.ContainsKey(slot))
                {
                    slotToEmNodeList[slot] = new EffectManagerNodeList();
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
                    foreach (EffectManagerNode emNode in _playerAndNullData[effectEvent][player])
                    {
                        result.Add(emNode);
                    }
                }
            }

            if (_slotSpecificData.ContainsKey(effectEvent) && eventCardSlot != null)
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
