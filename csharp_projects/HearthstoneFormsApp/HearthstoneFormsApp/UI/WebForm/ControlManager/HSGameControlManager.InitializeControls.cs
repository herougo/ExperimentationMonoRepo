using System.Windows.Forms;

namespace HearthstoneFormsApp.UI.WebForm.ControlManager
{
    internal partial class HSGameControlManager
    {
        private void InitializeControls()
        {
            _margin = _mainHeight / 100;

            const int _numNonMainPanels = 6;
            const int _numVerticalMargins = 15;
            // 2 * (hand (4) + player (1) + battleboard (2.5))
            const int _baseCardHeight = 200;
            const int _baseCardWidth = 140;
            const int _handLimit = 10;

            int mainHeightMinusMargins = _mainHeight - _numVerticalMargins * _margin;
            int panelHeight = mainHeightMinusMargins / _numNonMainPanels;
            int pbCardHeight = panelHeight - 2 * _margin;
            int pbCardWidth = (pbCardHeight * _baseCardWidth) / _baseCardHeight;
            int handPanelWidth = _margin * (_handLimit + 1) + pbCardWidth * _handLimit;

            // PMain
            PMain = new Panel();
            PMain.Location = new System.Drawing.Point(0, 0);
            PMain.Name = "pMain";
            PMain.Size = new System.Drawing.Size(_mainWidth, _mainHeight);

            #region OpponentHand
            // POpponentHand
            POpponentHand = new Panel();
            POpponentHand.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            POpponentHand.Location = new System.Drawing.Point(_margin, _margin);
            POpponentHand.Name = "pOpponentHand";
            POpponentHand.Size = new System.Drawing.Size(handPanelWidth, panelHeight);

            // PBOpponentHand
            PBOpponentHand = new PictureBox[_handLimit];
            
            for (int i = 0; i < _handLimit; i++)
            {
                int panelXOffset = i * (pbCardWidth + _margin) + _margin;
                PBOpponentHand[i] = new PictureBox();
                PBOpponentHand[i].Location = new System.Drawing.Point(panelXOffset, _margin);
                PBOpponentHand[i].Name = "pbOpponentHand" + i;
                PBOpponentHand[i].Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
                PBOpponentHand[i].BackColor = System.Drawing.Color.LightGray; // TODO: remove

                POpponentHand.Controls.Add(PBOpponentHand[i]);
            }

            PMain.Controls.Add(POpponentHand);
            #endregion

            int offsetAfterOpponentHand = _margin * 2 + panelHeight;
            int offsetAfterOpponent = offsetAfterOpponentHand + _margin + panelHeight;
            int offsetAfterOpponentBattleboard = offsetAfterOpponent + _margin + panelHeight;
            int offsetAfterPlayerBattleboard = offsetAfterOpponentBattleboard + _margin + panelHeight;
            int offsetAfterPlayer = offsetAfterPlayerBattleboard + _margin + panelHeight;

            #region PlayerHand
            // PPlayerHand
            PPlayerHand = new Panel();
            PPlayerHand.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            PPlayerHand.Location = new System.Drawing.Point(_margin, offsetAfterPlayer);
            PPlayerHand.Name = "pOpponentHand";
            PPlayerHand.Size = new System.Drawing.Size(handPanelWidth, panelHeight);

            // PBPlayerHand
            PBPlayerHand = new PictureBox[_handLimit];

            for (int i = 0; i < _handLimit; i++)
            {
                int panelXOffset = i * (pbCardWidth + _margin) + _margin;
                PBPlayerHand[i] = new PictureBox();
                PBPlayerHand[i].Location = new System.Drawing.Point(panelXOffset, _margin);
                PBPlayerHand[i].Name = "pbOpponentHand" + i;
                PBPlayerHand[i].Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
                PBPlayerHand[i].BackColor = System.Drawing.Color.LightGray; // TODO: remove

                PPlayerHand.Controls.Add(PBPlayerHand[i]);
            }

            PMain.Controls.Add(PPlayerHand);
            #endregion
            /*
            
            PMain.Controls.Add(PPlayerHand);
            PMain.Controls.Add(POpponentHand);
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
             */
        }
    }
}