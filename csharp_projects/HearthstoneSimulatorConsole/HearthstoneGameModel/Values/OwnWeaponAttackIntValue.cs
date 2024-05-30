using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Values
{
    public class OwnWeaponAttackIntValue : IIntValue
    {
        public int Get(HearthstoneGame game, CardSlot affectedSlot)
        {
            int player = affectedSlot.Player;
            WeaponCardSlot weapon = game.Weapons[player];
            if (weapon == null)
            {
                return 0;
            }
            return weapon.Attack;
        }
    }
}
