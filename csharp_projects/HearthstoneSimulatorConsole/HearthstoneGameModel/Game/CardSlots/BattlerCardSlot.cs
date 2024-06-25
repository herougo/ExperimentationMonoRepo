using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public abstract class BattlerCardSlot : CardSlot
    {
        // stats
        public int Attack = 0;

        public int MaxHealth = 0;
        public int Health = 0;

        public int AttacksThisTurn = 0;

        public bool HasSleep = false;
        public int NumFrozen = 0;
        public int NumWindfury = 0;
        public int NumCharge = 0;
        public int NumStealth = 0;
        public int NumTaunt = 0;
        public int NumElusive = 0;
        public int NumCantAttackEffect = 0;

        public BattlerCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) { }
        public abstract EffectManagerNodePlan TakeDamage(int amount);

        public bool IsFrozen
        {
            get { return NumFrozen > 0; }
        }

        public bool HasWindfury
        {
            get { return NumWindfury > 0; }
        }

        public bool HasCharge
        {
            get { return NumCharge > 0; }
        }

        public bool HasStealth
        {
            get { return NumStealth > 0; }
        }

        public bool HasCantAttackEffect
        {
            get { return NumCantAttackEffect > 0; }
        }

        public int NumPossibleAttacksIgnoringFrozen
        {
            get
            {
                if (HasWindfury)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }

        public CanAttackResponse CanAttackIgnoringFrozen
        {
            get
            {
                if (HasCantAttackEffect)
                {
                    return CanAttackResponse.CantAttackEffect;
                }
                else if (Attack == 0)
                {
                    return CanAttackResponse.ZeroAttack;
                }
                else if (AttacksThisTurn >= NumPossibleAttacksIgnoringFrozen)
                {
                    return CanAttackResponse.AttackedEnough;
                }
                else if (HasCharge)
                {

                }
                else if (HasSleep)
                {
                    return CanAttackResponse.Asleep;
                }

                return CanAttackResponse.Yes;
            }
        }

        public CanAttackResponse CanAttack
        {
            get
            {
                if (IsFrozen)
                {
                    return CanAttackResponse.Frozen;
                }
                return CanAttackIgnoringFrozen;
            }
        }

        public bool HasElusive
        {
            get { return NumElusive > 0; }
        }
    }
}
