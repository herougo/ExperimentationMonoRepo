using GameModel.Cards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel.Game
{
    public class Decklist
    {
        public readonly List<string> CardIdList;
        public readonly string HeroClass; 

        public Decklist(List<string> cardIdList, string heroClass)
        {
            CardIdList = cardIdList;
            HeroClass = heroClass;
        }

        public bool IsValid()
        {
            return CardIdList.Count == HearthstoneConstants.DeckLength;
        }
    }
}
