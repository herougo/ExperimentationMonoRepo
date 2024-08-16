using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.SecretManagement
{
    public class Secret
    {
        SpellCardSlot _cardSlot;
        Trigger _trigger;
        OneTimeEffect _oneTimeEffect;

        public Secret(SpellCardSlot cardSlot, Trigger trigger, OneTimeEffect oneTimeEffect)
        {
            _cardSlot = cardSlot;
            _trigger = trigger;
            _oneTimeEffect = oneTimeEffect;
        }

        public SpellCardSlot CardSlot { get { return _cardSlot; } }

        public Trigger Trigger { get { return _trigger; } }

        public OneTimeEffect OneTimeEffect { get {  return _oneTimeEffect; } }

        
    }
}
