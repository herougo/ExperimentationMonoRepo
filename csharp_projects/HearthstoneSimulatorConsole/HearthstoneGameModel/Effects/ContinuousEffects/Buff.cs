using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Buff : ContinuousEffect
    {
        int _attackAmount;
        int _healthAmount;

        public Buff(int attackAmount, int healthAmount)
        {
            _attackAmount = attackAmount;
            _healthAmount = healthAmount;
            _effectArea = EffectArea.All;
        }

        public override void AdjustStats(BattlerCardSlot cardSlot)
        {
            cardSlot.Attack += _attackAmount;
            cardSlot.Health += _healthAmount;
            cardSlot.MaxHealth += _healthAmount;
        }

        public override EMEffect Copy()
        {
            return new Buff(_attackAmount, _healthAmount);
        }
    }
}
