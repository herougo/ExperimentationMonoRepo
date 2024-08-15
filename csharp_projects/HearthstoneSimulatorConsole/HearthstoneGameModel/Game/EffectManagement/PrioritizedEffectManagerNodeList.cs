using HearthstoneGameModel.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class PrioritizedEffectManagerNodeList : IEnumerable<EffectManagerNode>
    {
        List<CustomLinkedList<EffectManagerNode>> _linkedLists;
        Dictionary<
            EffectManagerNode,
            CustomLinkedListNode<EffectManagerNode>
        > _emNodeToLLNode;

        public PrioritizedEffectManagerNodeList() {
            _linkedLists = new List<CustomLinkedList<EffectManagerNode>>() {
                new CustomLinkedList<EffectManagerNode>(), new CustomLinkedList<EffectManagerNode>()
            };

            _emNodeToLLNode = new Dictionary<
                EffectManagerNode,
                CustomLinkedListNode<EffectManagerNode>
            >();
        }

        public void Append(EffectManagerNode emNode)
        {
            int priority = emNode.Priority;
            CustomLinkedListNode<EffectManagerNode> node = new CustomLinkedListNode<EffectManagerNode>(
                emNode, null, null
            );
            _emNodeToLLNode[emNode] = node;
            _linkedLists[priority].AddNodeBefore(null, node);
        }

        public void Remove(EffectManagerNode emNode)
        {
            int priority = emNode.Priority;
            if (!_emNodeToLLNode.ContainsKey(emNode))
            {
                throw new Exception($"missing slot: {emNode.AffectedSlot.ToString()}");
            }
            CustomLinkedListNode<EffectManagerNode> llNode = _emNodeToLLNode[emNode];
            _linkedLists[priority].RemoveNode(llNode);
            _emNodeToLLNode.Remove(emNode);
        }

        public IEnumerator<EffectManagerNode> GetEnumerator()
        {
            foreach (CustomLinkedList<EffectManagerNode> linkedList in _linkedLists)
            {
                foreach (CustomLinkedListNode<EffectManagerNode> node in linkedList)
                {
                    yield return node.Val;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
