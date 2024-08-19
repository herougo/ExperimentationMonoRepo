using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class MinionCardSlot : BattlerCardSlot
    {
        public MinionCard TypedCard;

        // stats

        // managed by effects 
        // TODO

        public MinionCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game)
        {
            TypedCard = (MinionCard)Card;
            Mana = TypedCard.Mana;
            Attack = TypedCard.Attack;
            MaxHealth = TypedCard.Health;
            Health = TypedCard.Health;
        }

        public override EffectManagerNodePlan TakeDamage()
        {
            int amount = TempDamageToTake;

            Health -= amount;
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            if (amount > 0)
            {
                plan.UpdateStats.Add(this);
                plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.DamageTaken, this));
            }
            return plan;
        }

        public override string ToString()
        {
            string result = $"CardSlot('{Card.Name}', Mana={Mana}, {Attack} / {Health})";
            return result;
        }

        public EffectManagerNodePlan InPlayCopyFrom(MinionCardSlot selectedCardSlot)
        {
            Game.EffectManager.PopEffectsBySlot(this);

            Card = selectedCardSlot.Card.Copy();
            TypedCard = (MinionCard)Card;

            Mana = selectedCardSlot.Mana;
            Attack = selectedCardSlot.Attack;
            MaxHealth = selectedCardSlot.MaxHealth;
            Health = selectedCardSlot.Health;

            // AttacksThisTurn
            // HasSleep
            // NumFrozen
            // NumWindfury
            // NumCharge
            // NumStealth
            // NumTaunt
            // NumElusive
            // NumCantAttackEffect

            IsDestroyed = selectedCardSlot.IsDestroyed;

            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            foreach (EffectManagerNode emNode in selectedCardSlot.GetEMNodes())
            {
                if (!emNode.Effect.IsExternal)
                {
                    Game.EffectManager.AddEffect(new EffectManagerNode(
                        emNode.Effect.Copy(), this, this, emNode.Silenceable
                    ));
                }
            }
            AddSleepEffectManagerNode();


            plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.MinionTransformed));
            return plan;
        }

        public override void UpdateStats()
        {
            Mana = TypedCard.Mana;
            Attack = TypedCard.Attack;
            int prevMaxHealth = MaxHealth;
            MaxHealth = TypedCard.Health;
            int prevHealth = Health;
            
            foreach (EffectManagerNode emNode in GetEMNodes())
            {
                emNode.Effect.AdjustStats(this);
            }

            Mana = Math.Max(0, Mana);
            Attack = Math.Max(0, Attack);

            int newHealth = Math.Min(
                prevHealth + Math.Max(0, MaxHealth - prevMaxHealth),
                MaxHealth
            );
            Health = newHealth;


            /* Cases                   prevHealth  Health   MaxHealth  prevMaxHealth  newHealth
               * silenced health buff:   4           3        3          4              3
               * damaged & silenced:     1           1        3          4              1
               * buffed:                 3           4        4          3              4
               * damaged & buffed:       2           3        4          3              3
               * damaged, existing buff: 3           4        4          4              3
              
               * Alexstrasza 8 max hp:   15          15       15         8              15
               * Alexstrasza 25 max hp:  15          15       25         25             15
             */
        }

        public void AddSleepEffectManagerNode()
        {
            if (HasSleep)
            {
                return;
            }
            EffectManagerNode sleepEmNode = new EffectManagerNode(
                new Sleep(), this, this, false
            );
            Game.EffectManager.AddEffect(sleepEmNode);
        }
    }
}
