using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Selections.SelectionFilters;
using HearthstoneGameModel.Selections.SlotSelections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections
{
    public static class SelectionConstants
    {
        public static AllCharacters AllCharacters = new AllCharacters();
        public static AllFriendlyCharacters AllFriendlyCharacters = new AllFriendlyCharacters();
        public static AllFriendlyMinions AllFriendlyMinions = new AllFriendlyMinions();
        public static AllOtherFriendlyCharacters AllOtherFriendlyCharacters = new AllOtherFriendlyCharacters();
        public static AllOtherFriendlyMinions AllOtherFriendlyMinions = new AllOtherFriendlyMinions();
        public static AllOtherCharacters AllOtherCharacters = new AllOtherCharacters();
        public static AllOtherMinions AllOtherMinions = new AllOtherMinions();

        public static SelectCharacterFrom SelectCharacter = new SelectCharacterFrom(new AllCharacters());
        public static SelectCharacterFrom SelectOtherCharacter = new SelectCharacterFrom(new AllOtherCharacters());
        public static SelectCharacterFrom SelectOtherMinion = new SelectCharacterFrom(new AllOtherMinions());
        public static SelectCharacterFrom SelectOtherFriendlyMinion = new SelectCharacterFrom(new AllOtherFriendlyMinions());

        public static RandomCharacter RandomOtherLivingCharacter = new RandomCharacter(new AllOtherLivingCharacters());
        public static RandomCharacter RandomOtherLivingEnemy = new RandomCharacter(new AllOtherLivingEnemies());
        public static RandomCharacter RandomOtherFriendlyMinion = new RandomCharacter(new AllOtherFriendlyMinions());
        
        public static HeroSelection Player = new HeroSelection(false);
        public static HeroSelection Opponent = new HeroSelection(true);
        public static OwnSelf OwnSelf = new OwnSelf();
        
        public static AdjacentMinions AdjacentMinions = new AdjacentMinions();

        public static WeaponSelection PlayerWeapon = new WeaponSelection(false);
        public static WeaponSelection OpponentWeapon = new WeaponSelection(true);

        public static CardTypeSelectionFilter PlayerHandMinions = new CardTypeSelectionFilter(
            new HandSelection(PlayerChoice.Player),
            CardType.Minion
        );
        public static CardTypeSelectionFilter AllHandMinions = new CardTypeSelectionFilter(
            new HandSelection(PlayerChoice.Both),
            CardType.Minion
        );

    }
}
