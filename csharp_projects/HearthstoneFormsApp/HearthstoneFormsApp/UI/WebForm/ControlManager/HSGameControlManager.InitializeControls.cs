﻿using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            const int _boardLimit = 7;

            int mainHeightMinusMargins = _mainHeight - _numVerticalMargins * _margin;
            int panelHeight = mainHeightMinusMargins / _numNonMainPanels;
            int pbCardHeight = panelHeight - 2 * _margin;
            int pbCardWidth = (pbCardHeight * _baseCardWidth) / _baseCardHeight;
            int handPanelWidth = _margin * (_handLimit + 1) + pbCardWidth * _handLimit;
            int battleboardPanelWidth = _margin * (_boardLimit + 1) + pbCardWidth * _boardLimit;
            int battleboardPanelXOffset = _margin * 2 + pbCardWidth;

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

            int offsetXAfterHands = handPanelWidth + 2 * _margin;

            int offsetYAfterOpponentHand = _margin * 2 + panelHeight;
            
            #region Opponent
            POpponent = new Panel();
            POpponent.Location = new System.Drawing.Point(battleboardPanelXOffset, offsetYAfterOpponentHand);
            POpponent.Name = "pOpponent";
            POpponent.Size = new System.Drawing.Size(battleboardPanelWidth, panelHeight);

            PBOpponentWeapon = new PictureBox();
            PBOpponentWeapon.Location = new System.Drawing.Point(_margin, _margin);
            PBOpponentWeapon.Name = "pbOpponentWeapon";
            PBOpponentWeapon.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBOpponentWeapon.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            POpponent.Controls.Add(PBOpponentWeapon);

            int pOpponentOffsetXAfterWeapon = pbCardWidth + _margin * 2;

            int tbWeaponDurabilityHeight = 69;
            TBOpponentWeaponDurability = new TextBox();
            TBOpponentWeaponDurability.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBOpponentWeaponDurability.ForeColor = System.Drawing.Color.Red;
            TBOpponentWeaponDurability.Text = "300";
            TBOpponentWeaponDurability.ReadOnly = true;
            TBOpponentWeaponDurability.Location = new System.Drawing.Point(
                pOpponentOffsetXAfterWeapon,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBOpponentWeaponDurability.Name = "tbOpponentWeaponDurability";
            TBOpponentWeaponDurability.Size = new System.Drawing.Size(61, tbWeaponDurabilityHeight);
            TBOpponentWeaponDurability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            POpponent.Controls.Add(TBOpponentWeaponDurability);


            /*
        public Panel POpponent;
        public PictureBox PBOpponentWeapon;
        public TextBox TBOpponentWeaponDurability;
        public PictureBox PBOpponentHero;
        public TextBox TBOpponentAttack;
        public TextBox TBOpponentHealth;
        public PictureBox PBOpponentHeroPower;
             */
            PMain.Controls.Add(POpponent);
            #endregion

            int offsetYAfterOpponent = offsetYAfterOpponentHand + _margin + panelHeight;
            int offsetYAfterOpponentBattleboard = offsetYAfterOpponent + _margin + panelHeight;
            int offsetYAfterPlayerBattleboard = offsetYAfterOpponentBattleboard + _margin + panelHeight;
            int offsetYAfterPlayer = offsetYAfterPlayerBattleboard + _margin + panelHeight;

            #region PlayerHand
            // PPlayerHand
            PPlayerHand = new Panel();
            PPlayerHand.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            PPlayerHand.Location = new System.Drawing.Point(_margin, offsetYAfterPlayer);
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

            #region Tab Control
            int tcInfoHeight = offsetYAfterPlayer - _margin - offsetYAfterOpponentHand;
            int tcInfoWidth = (tcInfoHeight * _baseCardWidth) / _baseCardHeight;
            TCInfo = new TabControl();
            TabPage tpCardView = new TabPage();
            TabPage tpGameLog = new TabPage();
            int pageContentsHeight = tcInfoHeight - _margin * 2 - 10 - 3*2;
            int pageContentsWidth = tcInfoWidth - _margin * 2 - 3*2;

            TCInfo.Controls.Add(tpCardView);
            TCInfo.Controls.Add(tpGameLog);
            TCInfo.Size = new System.Drawing.Size(tcInfoWidth, tcInfoHeight);
            TCInfo.Name = "tcInfo";
            TCInfo.SelectedIndex = 0;
            TCInfo.Location = new System.Drawing.Point(offsetXAfterHands, _margin);

            tpCardView.Name = "tpCardView";
            tpCardView.Location = new System.Drawing.Point(10, 47);
            tpCardView.Padding = new System.Windows.Forms.Padding(3);
            tpCardView.Text = "Card View";

            PBCardView = new PictureBox();
            PBCardView.Location = new System.Drawing.Point(_margin, _margin);
            PBCardView.Name = "pbCardView";
            PBCardView.Size = new System.Drawing.Size(pageContentsWidth, pageContentsHeight);
            PBCardView.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            tpCardView.Controls.Add(PBCardView);

            tpGameLog.Name = "tpGameLog";
            tpGameLog.Location = new System.Drawing.Point(10, 47);
            tpGameLog.Padding = new System.Windows.Forms.Padding(3);
            tpGameLog.Text = "Game Log";

            PMain.Controls.Add(TCInfo);
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