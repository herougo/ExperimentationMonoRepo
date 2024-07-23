using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.CardGeneration
{
    public interface ICardGenerator
    {
        Card Generate(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots);

        ICardGenerator Copy();
    }
}
