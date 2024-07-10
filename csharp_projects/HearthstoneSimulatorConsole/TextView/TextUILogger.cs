using HearthstoneGameModel.Core;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView
{
    public class TextUILogger
    {
        protected HearthstoneGame _game = null;
        protected ITextLogger _textLogger;
        
        public TextUILogger(ITextLogger logger) { _textLogger = logger; }

        public void SetGame(HearthstoneGame game)
        {
            _game = game;
        }

        public void LogText(string text)
        {
            _textLogger.LogText(text);
        }

        public void LogError(string message)
        {
            LogText("ERROR: " + message + "\n");
        }

        private void LogHand(int player)
        {
            int i = 0;
            foreach (CardSlot cardSlot in _game.Hands[player])
            {
                LogText($"{i}: {cardSlot}\n");
                i += 1;
            }
        }

        private void LogBoard(int player)
        {
            int i = 0;
            foreach (CardSlot cardSlot in _game.Battleboard.GetAllSlots(player))
            {
                LogText($"\t{i}: {cardSlot}\n");
                i += 1;
            }
        }

        public void LogWeapon(WeaponCardSlot weapon)
        {
            if (weapon != null)
            {
                LogText($"Weapon: {weapon.Card.Name}, {weapon.Attack} attack, {weapon.Durability} durability\n");
            }
            else
            {
                LogText("Weapon: None\n");
            }
        }

        public void LogGameState() {
            int player = 0;
            int opp = 1;
            PlayerMetadata oppMetadata = _game.PlayerMetadata[opp];
            HeroCardSlot oppSlot = _game.Players[opp];
            int oppCurrentMana = oppMetadata.CurrentMana;
            int oppAvailableMana = oppMetadata.AvailableMana;
            LogText($"Opponent ({opp}) - health: {oppSlot.Health}, armour: {oppMetadata.Armour}, ");
            LogText($"mana: {oppCurrentMana} / {oppAvailableMana}\n");

            LogWeapon(_game.Weapons[opp]);
            LogHand(opp);

            LogText("\n");
            LogBoard(opp);
            LogText("\t------------\n");
            LogBoard(player);
            LogText("\n");

            HeroCardSlot playerSlot = _game.Players[player];
            PlayerMetadata playerMetadata = _game.PlayerMetadata[player];
            int playerCurrentMana = playerMetadata.CurrentMana;
            int playerAvailableMana = playerMetadata.AvailableMana;
            LogText($"Player ({player}) - health: {playerSlot.Health}, armour: {playerMetadata.Armour}, ");
            LogText($"mana: {playerCurrentMana} / {playerAvailableMana}\n");
            LogWeapon(_game.Weapons[player]);
            LogHand(player);
            LogText("\n");
        }

        public void LogPlayerGoingFirst()
        {
            LogText($"{_game.GameMetadata.WhoGoesFirst} goes first\n");
        }

        public void LogTurn()
        {
            LogText("-------------------------------------------\n");
            LogText($"{_game.GameMetadata.Turn} turn\n");
            LogText("-------------------------------------------\n");
        }

        public void LogGameOverResult(bool player0Dead, bool player1Dead)
        {
            if (player0Dead && player1Dead)
            {
                LogText("Game Over: TIE\n");
            }
            else if (player0Dead)
            {
                LogText("Game Over: Player 1 Wins\n");
            }
            else if (player1Dead)
            {
                LogText("Game Over: Player 0 Wins\n");
            }
            else
            {
                throw new ArgumentException("Neither player is dead in LogGameOverResult");
            }
        }

        public void LogPlayCard(string cardName)
        {
            LogText($"{_game.GameMetadata.Turn} plays {cardName}\n");
        }

        public void LogSummonMinion(int player, string cardName)
        {
            LogText($"{player} summons {cardName}\n");
        }

        public void LogAttack(BattlerCardSlot attacker, BattlerCardSlot defender)
        {
            LogText($"{attacker}\n\tattacks {defender}\n");
        }
        
        public void LogMinionDied(int player, string cardName)
        {
            LogText($"Player {player}'s {cardName} died\n");
        }

        public void LogCardBurned(int player, string cardName)
        {
            LogText($"Player {player} burned {cardName}\n");
        }

        public void LogMinionReturnedToHand(int player, string cardName)
        {
            LogText($"{cardName} returned to player {player}'s hand\n");
        }
    }
}
