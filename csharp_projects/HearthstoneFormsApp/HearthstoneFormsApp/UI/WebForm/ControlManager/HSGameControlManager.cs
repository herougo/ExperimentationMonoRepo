using System;
using System.Windows.Forms;

namespace HearthstoneFormsApp.UI.WebForm.ControlManager
{
    internal partial class HSGameControlManager
    {
        private int _mainHeight = 600;
        private int _mainWidth = 1000;
        
        private int _margin;

        public Panel PMain;
        public Panel PPlayerHand;
        public PictureBox[] PBPlayerHand;
        public Panel POpponentHand;
        public PictureBox[] PBOpponentHand;

        public TabControl TCInfo;
        public PictureBox PBCardView;
        public RichTextBox RTBGameLog;

        public Panel PPlayerBattleboard;
        public PictureBox[] PBPlayerBattleboard;
        public Panel PPlayer;
        public PictureBox PBPlayerWeapon;
        public TextBox TBPlayerWeaponDurability;
        public PictureBox PBPlayerHero;
        public TextBox TBPlayerAttack;
        public TextBox TBPlayerHealth;
        public PictureBox PBPlayerHeroPower;
        public PictureBox PBPlayerDeck;
        public TextBox TBPlayerDeckSize;

        public Panel POpponentBattleboard;
        public PictureBox[] PBOpponentBattleboard;
        public Panel POpponent;
        public PictureBox PBOpponentWeapon;
        public TextBox TBOpponentWeaponDurability;
        public PictureBox PBOpponentHero;
        public TextBox TBOpponentAttack;
        public TextBox TBOpponentHealth;
        public PictureBox PBOpponentHeroPower;
        public PictureBox PBOpponentDeck;
        public TextBox TBOpponentDeckSize;

        public HSGameControlManager(Form form)
        {
            InitializeControls();

            form.Controls.Add(PMain);
        }
    }
}

