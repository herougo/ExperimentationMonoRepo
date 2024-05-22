using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class BuffHealth : ContinuousEffect
    {
        int _amount;

        public BuffHealth(int amount)
        {
            _amount = amount;
            _effectArea = EffectArea.All;
        }

        public override void AdjustStats(BattlerCardSlot cardSlot)
        {
            cardSlot.Health += _amount;
            cardSlot.MaxHealth += _amount;
        }

        public override EMEffect Copy()
        {
            return new BuffHealth(_amount);
        }
    }
}
