using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class Battleboard
    {
        HearthstoneGame _game;
        Pile[] _boards = new Pile[2] { new Pile(), new Pile() };
        Dictionary<CardSlot, int> _cardSlotToBoardIndex = new Dictionary<CardSlot, int>();
        HashSet<CardSlot>[] _taunts = new HashSet<CardSlot>[2] {
            new HashSet<CardSlot>(),
            new HashSet<CardSlot>()
        };

        public Battleboard(HearthstoneGame game)
        {
            _game = game;
            
        }

        public void AddCards(int player, List<CardSlot> cardSlots)
        {
            AddCards(player, cardSlots, _boards[player].Count);
        }

        public void AddCards(int player, List<CardSlot> cardSlots, int index)
        {
            _boards[player].AddCards(cardSlots, index);

            for (int i = index; i < _boards[player].Count; i++)
            {
                CardSlot cardSlot = _boards[player][i];
                _cardSlotToBoardIndex[cardSlot] = i;
            }
        }

        public void PopCardSlot(CardSlot cardSlot)
        {
            // remove from the board
            int player = cardSlot.Player;
            int originalBoardIndex = _cardSlotToBoardIndex[cardSlot];

            _cardSlotToBoardIndex.Remove(cardSlot);
            for (int i = originalBoardIndex + 1; i < BoardLen(player); i++)
            {
                CardSlot currentCardSlot = _boards[player][i];
                _cardSlotToBoardIndex[currentCardSlot] = i - 1;
            }

            _boards[player].Pop(originalBoardIndex);
        }

        public void ReplaceCardSlot(CardSlot cardSlot, CardSlot replaceWith)
        {
            // remove from the board
            int player = cardSlot.Player;
            int originalBoardIndex = _cardSlotToBoardIndex[cardSlot];

            _cardSlotToBoardIndex.Remove(cardSlot);
            _cardSlotToBoardIndex[replaceWith] = originalBoardIndex;

            _boards[player][originalBoardIndex] = replaceWith;
        }

        public int BoardLen(int player)
        {
            return _boards[player].Count;
        }

        public CardSlot GetSlot(int player, int boardIndex)
        {
            if (0 <= boardIndex && boardIndex < _boards[player].Count)
            {
                return _boards[player][boardIndex];
            }
            return null;
        }

        public List<CardSlot> GetAllSlots(int player)
        {
            return _boards[player].ToList();
        }

        public int CardSlotToBoardIndex(CardSlot cardSlot)
        {
            if (_cardSlotToBoardIndex.ContainsKey(cardSlot))
            {
                return _cardSlotToBoardIndex[cardSlot];
            }
            return HearthstoneConstants.NullInt;
        }

        public void AddTaunt(CardSlot cardSlot)
        {
            if (_taunts[cardSlot.Player].Contains(cardSlot))
            {
                throw new ArgumentException("Taunt already present");
            }
            _taunts[cardSlot.Player].Add(cardSlot);
        }

        public void RemoveTaunt(CardSlot cardSlot)
        {
            _taunts[cardSlot.Player].Remove(cardSlot);
        }

        public bool DefenderObeysTaunt(CardSlot defenderCardSlot)
        {
            HashSet<CardSlot> taunts = _taunts[defenderCardSlot.Player];
            if (taunts.Count == 0)
            {
                return true;
            }
            return taunts.Contains(defenderCardSlot);
        }

        public bool HasRoom(int player)
        {
            return BoardLen(player) < _game.PlayerMetadata[player].BattleboardLimit;
        }

        public Tuple<CardSlot, CardSlot> GetNeighbours(CardSlot slot)
        {
            int boardIndex = CardSlotToBoardIndex(slot);
            if (boardIndex == HearthstoneConstants.NullInt)
            {
                return new Tuple<CardSlot, CardSlot>(null, null);
            }

            int boardLen = BoardLen(slot.Player);

            CardSlot leftNeighbour = null;
            if (boardIndex > 0)
            {
                leftNeighbour = _boards[slot.Player][boardIndex - 1];
            }
            CardSlot rightNeighbour = null;
            if (boardIndex + 1 < boardLen)
            {
                rightNeighbour = _boards[slot.Player][boardIndex + 1];
            }

            return new Tuple<CardSlot, CardSlot>(leftNeighbour, rightNeighbour);
        }

        public List<CardSlot> GetNeighboursAsList(CardSlot slot)
        {
            Tuple<CardSlot, CardSlot> neighbours = _game.Battleboard.GetNeighbours(slot);
            List<CardSlot> result = new List<CardSlot>();
            if (neighbours.Item1 != null)
            {
                result.Add(neighbours.Item1);
            }
            if (neighbours.Item2 != null)
            {
                result.Add(neighbours.Item2);
            }
            return result;
        }
    }
}
