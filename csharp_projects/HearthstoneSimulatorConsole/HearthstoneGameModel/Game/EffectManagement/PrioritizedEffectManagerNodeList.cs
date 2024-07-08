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
        List<LinkedList<EffectManagerNode>> _linkedLists;
        Dictionary<
            EffectManagerNode,
            LinkedListNode<EffectManagerNode>
        > _emNodeToLLNode;

        public PrioritizedEffectManagerNodeList() {
            _linkedLists = new List<LinkedList<EffectManagerNode>>() {
                new LinkedList<EffectManagerNode>(), new LinkedList<EffectManagerNode>()
            };

            _emNodeToLLNode = new Dictionary<
                EffectManagerNode,
                LinkedListNode<EffectManagerNode>
            >();
        }

        public void Append(EffectManagerNode emNode)
        {
            int priority = emNode.Priority;
            LinkedListNode<EffectManagerNode> node = new LinkedListNode<EffectManagerNode>(
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
            LinkedListNode<EffectManagerNode> llNode = _emNodeToLLNode[emNode];
            _linkedLists[priority].RemoveNode(llNode);
            _emNodeToLLNode.Remove(emNode);
        }

        public IEnumerator<EffectManagerNode> GetEnumerator()
        {
            foreach (LinkedList<EffectManagerNode> linkedList in _linkedLists)
            {
                foreach (LinkedListNode<EffectManagerNode> node in linkedList)
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
