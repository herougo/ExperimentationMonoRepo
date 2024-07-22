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
    public class ReduceWeaponDurability : OneTimeEffect
    {
        bool _opposing;
        IIntValue _amount;

        public ReduceWeaponDurability(int amount, bool opposing)
        {
            _opposing = opposing;
            _amount = new ConstIntValue(amount);
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
        }

        public ReduceWeaponDurability(IIntValue amount, bool opposing)
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
                for (int i = 0; i < Math.Min(weapon.Durability, amount); i++)
                {
                    game.ReduceDurability(player);
                }

                plan.UpdateStats.Add(weapon);
                return plan;
            }
            
            return null;    
        }

        public override OneTimeEffect Copy()
        {
            return new ReduceWeaponDurability(_amount, _opposing);
        }
    }
}
