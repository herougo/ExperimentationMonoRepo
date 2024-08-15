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
        CustomLinkedList<EffectManagerNode> _linkedList;
        Dictionary<
            EffectManagerNode,
            CustomLinkedListNode<EffectManagerNode>
        > _emNodeToLLNode;

        public EffectManagerNodeList() {
            _linkedList = new CustomLinkedList<EffectManagerNode>();
            _emNodeToLLNode = new Dictionary<
                EffectManagerNode,
                CustomLinkedListNode<EffectManagerNode>
            >();
        }

        public void Append(EffectManagerNode emNode)
        {
            CustomLinkedListNode<EffectManagerNode> node = new CustomLinkedListNode<EffectManagerNode>(
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
            CustomLinkedListNode<EffectManagerNode> llNode = _emNodeToLLNode[emNode];
            _linkedList.RemoveNode(llNode);
            _emNodeToLLNode.Remove(emNode);
        }

        public IEnumerator<EffectManagerNode> GetEnumerator()
        {
            foreach (CustomLinkedListNode<EffectManagerNode> node in _linkedList)
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
