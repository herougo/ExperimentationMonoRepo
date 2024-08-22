using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ActivatedEffects;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Metadata;
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
        
        // Other metadata

        public int HeroPowerCost
        {
            get { return TypedCard.HeroPowerCost; }
        }

        public HeroCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) {
            TypedCard = (HeroCard)Card;
        }
        public override EffectManagerNodePlan TakeDamage()
        {
            int amount = TempDamageToTake;
            PlayerMetadata playerMetadata = Game.PlayerMetadata[Player];

            int damageToHealth = Math.Max(amount - playerMetadata.Armour, 0);
            int damageToArmour = amount - damageToHealth;
            Health -= damageToHealth;
            playerMetadata.Armour -= damageToArmour;
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
            Game.EffectManager.AddEffect(emNode);
        }

        public override void UpdateStats()
        {
            if (Game.Weapons[Player] != null && Game.GameMetadata.Turn == Player)
            {
                Attack = Game.Weapons[Player].Attack;
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
