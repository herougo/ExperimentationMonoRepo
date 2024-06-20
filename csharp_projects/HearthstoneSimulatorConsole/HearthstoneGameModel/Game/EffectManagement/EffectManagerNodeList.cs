using HearthstoneGameModel.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class EffectManagerNodeList : IEnumerable<EffectManagerNode>
    {
        LinkedList<EffectManagerNode> _linkedList;
        Dictionary<
            EffectManagerNode,
            LinkedListNode<EffectManagerNode>
        > _emNodeToLLNode;

        public EffectManagerNodeList() {
            _linkedList = new LinkedList<EffectManagerNode>();
            _emNodeToLLNode = new Dictionary<
                EffectManagerNode,
                LinkedListNode<EffectManagerNode>
            >();
        }

        public void Append(EffectManagerNode emNode)
        {
            LinkedListNode<EffectManagerNode> node = new LinkedListNode<EffectManagerNode>(
                emNode, null, null
            );
            _emNodeToLLNode[emNode] = node;
            _linkedList.AddNodeBefore(null, node);
        }

        public void Remove(EffectManagerNode emNode)
        {
            if (!_emNodeToLLNode.ContainsKey(emNode))
            {
                throw new Exception($"missing slot: {emNode.AffectedSlot.ToString()}");
            }
            LinkedListNode<EffectManagerNode> llNode = _emNodeToLLNode[emNode];
            _linkedList.RemoveNode(llNode);
            _emNodeToLLNode.Remove(emNode);
        }

        public IEnumerator<EffectManagerNode> GetEnumerator()
        {
            foreach (LinkedListNode<EffectManagerNode> node in _linkedList)
            {
                yield return node.Val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
