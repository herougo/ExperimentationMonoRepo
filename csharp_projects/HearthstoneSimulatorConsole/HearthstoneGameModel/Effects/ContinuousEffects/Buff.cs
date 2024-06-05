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

        public override void AdjustStats(CardSlot cardSlot)
        {
            switch (cardSlot.CardType)
            {
                case CardType.Minion:
                case CardType.Hero:
                    BattlerCardSlot battlerCardSlot = (BattlerCardSlot)cardSlot;
                    battlerCardSlot.Attack += _attackAmount;
                    battlerCardSlot.Health += _healthAmount;
                    battlerCardSlot.MaxHealth += _healthAmount;
                    break;
            }
            throw new NotImplementedException("Invalid card type to adjust stats from BuffHealth");
        }

        public override EMEffect Copy()
        {
            return new Buff(_attackAmount, _healthAmount);
        }
    }
}
