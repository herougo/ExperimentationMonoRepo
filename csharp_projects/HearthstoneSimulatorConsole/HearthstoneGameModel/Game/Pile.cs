using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Game
{
    public class Pile : IEnumerable<CardSlot>
    {
        List<CardSlot> _data;

        public Pile(List<CardSlot> data)
        {
            _data = data;
        }

        public Pile()
        {
            _data = new List<CardSlot>();
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public CardSlot Top
        { 
            get { return _data[_data.Count - 1]; }
        }

        public void AddCard(CardSlot cardSlot)
        {
            _data.Add(cardSlot);
        }

        public void PutTopCardOnTheBottom()
        {
            CardSlot top = Top;
            for (int i = Count - 1; i > 0; i--)
            {
                _data[i] = _data[i - 1];
            }
            _data[0] = top;
        }

        public CardSlot Pop(int index)
        {
            CardSlot result = _data[index];
            _data.RemoveAt(index);
            return result;
        }

        public void PopByCardSlots(List<CardSlot> cardSlots)
        {
            HashSet<CardSlot> cardSlotHashSet = cardSlots.ToHashSet();

            for (int i = Count - 1; i >= 0; i--)
            {
                CardSlot slot = this[i];
                if (cardSlotHashSet.Contains(slot))
                {
                    Pop(i);
                }
            }
        }

        public CardSlot DrawCard()
        {
            return Pop(Count - 1);
        }

        public List<CardSlot> Draw(int numCards)
        {
            if (numCards > Count)
            {
                throw new ArgumentException("Too few cards to draw");
            }

            List<CardSlot> result = new List<CardSlot>();
            for (int i = 0; i < numCards; i++)
            {
                result.Add(DrawCard());
            }
            return result;
        }

        public void AddCards(List<CardSlot> cards)
        {
            _data.AddRange(cards);
        }

        public void AddCards(List<CardSlot> cards, int index)
        {
            _data.InsertRange(index, cards);
        }

        public void AddCard(CardSlot card, int index)
        {
            _data.Insert(index, card);
        }

        public CardSlot this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<CardSlot> GetEnumerator()
        {
            foreach (CardSlot slot in _data)
            {
                yield return slot;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
