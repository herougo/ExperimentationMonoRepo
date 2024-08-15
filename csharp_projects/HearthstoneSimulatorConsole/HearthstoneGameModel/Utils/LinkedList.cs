using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Utils
{
    public class CustomLinkedListNode<T>
    {
        public T Val;
        public CustomLinkedListNode<T> Prev;
        public CustomLinkedListNode<T> Next;

        public CustomLinkedListNode(T val, CustomLinkedListNode<T> prev, CustomLinkedListNode<T> next)
        {
            Val = val; Prev = prev; Next = next;
        }
    }

    public class CustomLinkedList<T> : IEnumerable<CustomLinkedListNode<T>>
    {
        public CustomLinkedListNode<T> First = null;
        public CustomLinkedListNode<T> Last = null;
        public int Length = 0;

        public void AddNodeBefore(CustomLinkedListNode<T> target, CustomLinkedListNode<T> newNode)
        {
            if (target == null) // is last
            {
                if (First == null)
                {
                    First = newNode;
                }
                else
                {
                    Last.Next = newNode;
                    newNode.Prev = Last;
                }
                Last = newNode;
            }
            else if (First == target) // is first
            {
                newNode.Next = First;
                First.Prev = newNode;
                First = newNode;
            }
            else
            {
                newNode.Prev = target.Prev;
                newNode.Next = target;
                target.Prev.Next = newNode;
                target.Prev = newNode;
            }
            Length++;
        }

        public void RemoveNode(CustomLinkedListNode<T> node)
        {
            if (node.Prev == null) // is first
            {
                First = node.Next;
            }
            else
            {
                node.Prev.Next = node.Next;
            }
            if (node.Next == null)
            {
                Last = node.Prev;
            }
            else
            {
                node.Next.Prev = node.Prev;
            }
            Length--;
        }

        public IEnumerator<CustomLinkedListNode<T>> GetEnumerator()
        {
            CustomLinkedListNode<T> curr = First;
            while (curr != null)
            {
                yield return curr;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
