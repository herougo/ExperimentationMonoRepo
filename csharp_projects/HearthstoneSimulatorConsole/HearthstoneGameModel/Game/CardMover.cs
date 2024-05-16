using System.Collections.Generic;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Game
{
    public class CardMover
    {
        HearthstoneGame _game;
        List<CardSlot> _limbo = new List<CardSlot>();

        public CardMover(HearthstoneGame game)
        {
            _game = game;
        }

        public void PlayCard(int cardInHandIndex, int destinationIndex)
        {
            CardSlot cardSlot = _game.Hands[_game.GameMetadata.Turn].Pop(cardInHandIndex);
            _game.Players[_game.GameMetadata.Turn].CurrentMana -= cardSlot.Mana;

            string cardName = cardSlot.Card.Name;
            // TODO: UIManager log play card

            // TODO: other

        }

        public void DrawCards(int player, int numCards)
        {
            // TODO
        }
    }
}
