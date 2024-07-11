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
        public static SlotSelection AllCharacters = (
            new HeroSelection(PlayerChoice.Both) + new BoardSelection(PlayerChoice.Both)
        );
        public static SlotSelection AllFriendlyCharacters = (
            new HeroSelection(PlayerChoice.Player) + new BoardSelection(PlayerChoice.Player)
        );
        public static SlotSelection AllFriendlyMinions = (
            new BoardSelection(PlayerChoice.Player) & new CardTypeSelectionFilter(CardType.Minion)
        );
        public static SlotSelection AllOtherFriendlyCharacters = (
            (new HeroSelection(PlayerChoice.Player) + new BoardSelection(PlayerChoice.Player))
            & new OtherSelectionFilter()
        );
        public static SlotSelection AllOtherFriendlyMinions = (
            (new BoardSelection(PlayerChoice.Player) & new CardTypeSelectionFilter(CardType.Minion))
            & new OtherSelectionFilter()
        );
        public static SlotSelection AllOtherCharacters = (
            (new HeroSelection(PlayerChoice.Both) + new BoardSelection(PlayerChoice.Both))
            & new OtherSelectionFilter()
        );
        public static SlotSelection AllOtherMinions = (
            (new BoardSelection(PlayerChoice.Both) & new CardTypeSelectionFilter(CardType.Minion))
            & new OtherSelectionFilter()
        );
        public static SlotSelection AllMinions = (
            (new BoardSelection(PlayerChoice.Both) & new CardTypeSelectionFilter(CardType.Minion))
        );
        public static SlotSelection OtherLivingEnemies = (
            ((new HeroSelection(PlayerChoice.Opponent) + new BoardSelection(PlayerChoice.Opponent))
            & new LivingSelectionFilter())
            & new OtherSelectionFilter()
        );
        public static SlotSelection OtherLivingEnemyMinions = (
            (new BoardSelection(PlayerChoice.Opponent) & new LivingSelectionFilter())
            & new OtherSelectionFilter()
        );
        public static SlotSelection OtherLivingCharacters = (
            ((new HeroSelection(PlayerChoice.Both) + new BoardSelection(PlayerChoice.Both))
            & new LivingSelectionFilter())
            & new OtherSelectionFilter()
        );

        public static SlotSelection Player = new HeroSelection(PlayerChoice.Player);
        public static SlotSelection Opponent = new HeroSelection(PlayerChoice.Opponent);
        public static SlotSelection OwnSelf = new OwnSelf();
        
        public static SlotSelection AdjacentMinions = new AdjacentMinions();

        public static SlotSelection PlayerWeapon = new WeaponSelection(false);
        public static SlotSelection OpponentWeapon = new WeaponSelection(true);

        public static SlotSelection PlayerHandMinions = (
            new HandSelection(PlayerChoice.Player)
            & new CardTypeSelectionFilter(CardType.Minion)
        );
        public static SlotSelection AllHandMinions = (
            new HandSelection(PlayerChoice.Both)
            & new CardTypeSelectionFilter(CardType.Minion)
        );

    }
}
