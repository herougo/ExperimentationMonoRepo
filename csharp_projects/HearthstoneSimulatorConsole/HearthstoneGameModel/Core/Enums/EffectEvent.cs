﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public static class EffectEvent
    {
        public const string StartTurn = "start_turn";
        public const string EndTurn = "end_turn";
        public const string WeaponDestroyed = "weapon_destroyed";
        public const string WeaponEquipped = "weapon_equipped";
        // public const string AfterAttackerInitialCombatDamage = "after_attacker_initial_combat_damage";
        // public const string AfterDefenderInitialCombatDamage = "after_defender_initial_combat_damage";
        public const string AfterAttackerAttacked = "after_attacker_attacked";
        public const string AttackFinished = "attack_finished";
        public const string CalculateStats = "calculate_stats";
        public const string MinionPutInPlay = "minion_put_in_play";
        public const string Battlecry = "battlecry";
        public const string MinionSummoned = "minion_summoned";
        public const string MinionDies = "minion_dies";
        public const string ActivateHeroPower = "activate_hero_power";
        public const string HeroPowerEnd = "hero_power_end";
        public const string MinionReturnedToHand = "minion_returned_to_hand";
        public const string AfterSpellActivated = "after_spell_activated";
        public const string PreEndTurnFrozen = "pre_end_turn_frozen";
        public const string DamageTaken = "damage_taken";
        public const string CharacterHealed = "character_healed";
        public const string WeaponChangeStats = "weapon_change_stats";
        public const string CardMovedToHand = "card_moved_to_hand";
        public const string CardPlayed = "card_played";
        public const string SetHealth = "set_health";
        // public const string AttackerInflictDamage = "attacker_inflict_damage";
        // public const string DefenderInflictDamage = "defender_inflict_damage";
        public const string InflictDamage = "inflict_damage";
        public const string WhenCardPlayed = "when_card_played";
        public const string MinionTransformed = "minion_transformed";
        public const string DamagePreparation = "damage_preparation";
        public const string CardDiscarded = "card_discarded";
        public const string MinionChooseOne = "minion_choose_one";
        public const string AttackDeclared = "attack_declared";
        public const string SecretRevealed = "secret_revealed";
        public const string AttackAborted = "attack_aborted";
        public const string BeforeAttackDeclared = "before_attack_declared";

    }
}
