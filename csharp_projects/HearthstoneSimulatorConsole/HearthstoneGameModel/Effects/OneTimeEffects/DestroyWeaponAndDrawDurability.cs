using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class DestroyWeaponAndDrawDurability : OneTimeEffect
    {
        PlayerChoice _weaponPlayer;
        PlayerChoice _drawPlayer;

        public DestroyWeaponAndDrawDurability(PlayerChoice weaponPlayer, PlayerChoice drawPlayer)
        {
            _weaponPlayer = weaponPlayer;
            _drawPlayer = drawPlayer;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int player = affectedCardSlot.Player;
            int weaponPlayer = HSGameUtils.ComputePlayer(player, _weaponPlayer);
            int drawPlayer = HSGameUtils.ComputePlayer(player, _drawPlayer);

            WeaponCardSlot weapon = game.Weapons[weaponPlayer];
            if ( weapon == null )
            {
                return null;
            }
            int durability = weapon.Durability;

            game.CardMover.DestroyWeapon(weaponPlayer);
            game.CardMover.DrawCards(drawPlayer, durability);

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new DestroyWeaponAndDrawDurability(_weaponPlayer, _drawPlayer);
        }
    }
}
