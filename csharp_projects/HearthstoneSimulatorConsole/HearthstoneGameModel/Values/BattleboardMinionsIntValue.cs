using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.Utils;

namespace HearthstoneGameModel.Values
{
    public class BattleboardMinionsIntValue : IIntValue
    {
        PlayerChoice _playerChoice;

        public BattleboardMinionsIntValue()
        {
            _playerChoice = PlayerChoice.Both;
        }

        public BattleboardMinionsIntValue(PlayerChoice playerChoice)
        {
            _playerChoice = playerChoice;
        }

        public int Get(HearthstoneGame game, CardSlot affectedSlot)
        {
            if (_playerChoice == PlayerChoice.Both) {
                return game.Battleboard.BoardLen(0) + game.Battleboard.BoardLen(1);
            }
            else
            {
                int relevantPlayer = HSGameUtils.ComputePlayer(affectedSlot.Player, _playerChoice);
                return game.Battleboard.BoardLen(relevantPlayer);
            }
        }
    }
}
