using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class GainWeaponDurability : OneTimeEffect
    {
        bool _opposing;
        IIntValue _amount;

        public GainWeaponDurability(int amount, bool opposing)
        {
            _opposing = opposing;
            _amount = new ConstIntValue(amount);
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
        }

        public GainWeaponDurability(IIntValue amount, bool opposing)
        {
            _opposing = opposing;
            _amount = amount;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            int player = affectedCardSlot.Player;
            if (_opposing)
            {
                player = 1 - player;
            }
            WeaponCardSlot weapon = game.Weapons[player];
            if (weapon != null)
            {
                EffectManagerNodePlan plan = new EffectManagerNodePlan();
                int amount = _amount.Get(game, affectedCardSlot);
                EffectManagerNode newEmNode = new EffectManagerNode(
                    new BuffDurability(amount), weapon, originCardSlot, false
                );
                plan.ToAdd.Add(newEmNode);
                return plan;
            }
            
            return null;    
        }

        public override OneTimeEffect Copy()
        {
            return new GainWeaponDurability(_amount, _opposing);
        }
    }
}
