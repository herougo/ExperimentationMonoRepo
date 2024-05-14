using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class HeroCardSlot : BattlerCardSlot
    {
        public int CurrentMana = 0;
        public int AvailableMana = 0;
        public int MaximumMana = 0;
        public int MaxHealth = 0;
        public int Health = 0;
        public int Armour = 0;
        public bool HeroPowerUsedThisTurn = false;

        // TODO: _heroPowerCost and _heroPowerEffect

        // Other metadata
        public int NumTaunt = 0;
        public int NumCharge = 0;
        public int NumWindfury = 0;
        public int NumStealth = 0;
        public int NumFrozen = 0;
        public int NumElusive = 0;
        public bool HasSleep = false;

        public HeroCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) { }
        public override void TakeDamage(int amount)
        {
            int damageToHealth = Math.Max(amount - Armour, 0);
            int damageToArmour = amount - damageToHealth;
            Health -= damageToHealth;
            Armour -= damageToArmour;
        }
    }
}
