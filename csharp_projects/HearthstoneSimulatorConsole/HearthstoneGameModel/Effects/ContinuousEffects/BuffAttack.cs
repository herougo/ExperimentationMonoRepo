using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class BuffAttack : ContinuousEffect
    {
        int _amount;

        public BuffAttack(int amount)
        {
            _amount = amount;
            _effectArea = EffectArea.All;
        }

        public override void AdjustStats(BattlerCardSlot cardSlot)
        {
            cardSlot.Attack += _amount;
        }

        public override EMEffect Copy()
        {
            return new BuffAttack(_amount);
        }
    }
}
