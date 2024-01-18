using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel.Game
{
    public class Decklist
    {
        List<string> CardIdList;
        public Decklist(List<string> cardIdList)
        {
            CardIdList = cardIdList;
        }

        public bool IsValid()
        {
            return CardIdList.Count == HearthstoneConstants.DeckLength;
        }
    }
}
