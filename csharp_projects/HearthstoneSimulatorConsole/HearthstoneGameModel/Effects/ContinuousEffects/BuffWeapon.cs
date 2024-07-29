using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class BuffWeapon : ContinuousEffect
    {
        int _attackAmount;
        int _durabilityAmount;

        public BuffWeapon(int attackAmount, int durabilityAmount)
        {
            _attackAmount = attackAmount;
            _durabilityAmount = durabilityAmount;
            _effectArea = EffectArea.All;
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            switch (cardSlot.CardType)
            {
                case CardType.Weapon:
                    WeaponCardSlot weaponCardSlot = (WeaponCardSlot)cardSlot;
                    weaponCardSlot.Attack += _attackAmount;
                    weaponCardSlot.MaxDurability += _durabilityAmount;
                    return;
            }
            throw new NotImplementedException("Invalid card type to adjust stats from BuffWeapon");
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.UpdateStats.Add(emNode.AffectedSlot);
            return plan;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.UpdateStats.Add(emNode.AffectedSlot);
            return plan;
        }

        public override EMEffect Copy()
        {
            return new BuffWeapon(_attackAmount, _durabilityAmount);
        }
    }
}
