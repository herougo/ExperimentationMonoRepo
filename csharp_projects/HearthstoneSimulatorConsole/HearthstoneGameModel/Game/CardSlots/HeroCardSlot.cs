using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ActivatedEffects;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class HeroCardSlot : BattlerCardSlot
    {
        public HeroCard TypedCard;

        public int CurrentMana = 0; // CurrentMana / AvailableMana
        public int AvailableMana = 0;
        public int MaximumMana = 0;
        public int Armour = 0;
        public bool HeroPowerUsedThisTurn = false;

        // Other metadata

        public int HeroPowerCost
        {
            get { return TypedCard.HeroPowerCost; }
        }

        public HeroCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) {
            TypedCard = (HeroCard)Card;
        }
        public override EffectManagerNodePlan TakeDamage(int amount)
        {
            int damageToHealth = Math.Max(amount - Armour, 0);
            int damageToArmour = amount - damageToHealth;
            Health -= damageToHealth;
            Armour -= damageToArmour;
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            if (amount > 0)
            {
                plan.UpdateStats.Add(this);
                plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.DamageTaken, this));
            }
            return plan;
        }

        public void SetupHeroPower()
        {
            EMEffect heroPowerEffect = new HeroPowerEffect(TypedCard.HeroPowerEffect);
            EffectManagerNode emNode = new EffectManagerNode(
                heroPowerEffect, this, this, false
            );
            _game.EffectManager.AddEffect(emNode);
        }

        public override void UpdateStats()
        {
            if (_game.Weapons[Player] != null)
            {
                Attack = _game.Weapons[Player].Attack;
            }
            else
            {
                Attack = 0;
            }

            foreach (EffectManagerNode emNode in GetEMNodes())
            {
                emNode.Effect.AdjustStats(this);
            }

            Attack = Math.Max(0, Attack);
        }
    }
}
