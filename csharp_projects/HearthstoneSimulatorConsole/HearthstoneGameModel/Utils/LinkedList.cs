using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Utils
{
    public class LinkedListNode<T>
    {
        public T Val;
        public LinkedListNode<T> Prev;
        public LinkedListNode<T> Next;

        public LinkedListNode(T val, LinkedListNode<T> prev, LinkedListNode<T> next)
        {
            Val = val; Prev = prev; Next = next;
        }
    }

    public class LinkedList<T> : IEnumerable<LinkedListNode<T>>
    {
        public LinkedListNode<T> First = null;
        public LinkedListNode<T> Last = null;
        public int Length = 0;

        public void AddNodeBefore(LinkedListNode<T> target, LinkedListNode<T> newNode)
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

        public void RemoveNode(LinkedListNode<T> node)
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

        public IEnumerator<LinkedListNode<T>> GetEnumerator()
        {
            LinkedListNode<T> curr = First;
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
