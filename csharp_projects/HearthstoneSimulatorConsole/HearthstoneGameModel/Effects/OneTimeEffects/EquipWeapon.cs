using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class EquipWeapon : OneTimeEffect
    {
        SlotSelection _selection;
        WeaponCard _weapon;

        public EquipWeapon(SlotSelection selection, WeaponCard weapon) {
            _selection = selection;
            _weapon = weapon;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);

            foreach (CardSlot slot in selectedCardSlots)
            {
                WeaponCardSlot weaponCardSlot = (WeaponCardSlot)_weapon.CreateCardSlot(slot.Player, game);
                game.CardMover.EquipWeapon(slot.Player, weaponCardSlot);
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new EquipWeapon(_selection.Copy(), (WeaponCard)_weapon.Copy());
        }
    }
}
