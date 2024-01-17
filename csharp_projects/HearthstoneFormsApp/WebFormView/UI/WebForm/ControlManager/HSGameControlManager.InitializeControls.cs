using System.Drawing;
using System.Windows.Forms;

namespace WebFormView.UI.WebForm.ControlManager
{
    public partial class HSGameControlManager
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
            int textBoxWidth = 55;
            int tbWeaponDurabilityHeight = 32;

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
            int offsetXAfterBattleboard = battleboardPanelXOffset + battleboardPanelWidth;
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

            int pOpponentOffsetXAfterWeapon = pbCardWidth + _margin;

            TBOpponentWeaponDurability = new TextBox();
            TBOpponentWeaponDurability.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBOpponentWeaponDurability.ForeColor = System.Drawing.Color.Red;
            TBOpponentWeaponDurability.Text = "0";
            TBOpponentWeaponDurability.ReadOnly = true;
            TBOpponentWeaponDurability.Location = new System.Drawing.Point(
                pOpponentOffsetXAfterWeapon,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBOpponentWeaponDurability.Name = "tbOpponentWeaponDurability";
            TBOpponentWeaponDurability.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBOpponentWeaponDurability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            POpponent.Controls.Add(TBOpponentWeaponDurability);
            
            int pOpponentOffsetXHero = battleboardPanelWidth / 2 - pbCardWidth / 2;
            PBOpponentHero = new PictureBox();
            PBOpponentHero.Location = new System.Drawing.Point(pOpponentOffsetXHero, _margin);
            PBOpponentHero.Name = "pbOpponentHero";
            PBOpponentHero.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBOpponentHero.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            POpponent.Controls.Add(PBOpponentHero);

            TBOpponentAttack = new TextBox();
            TBOpponentAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBOpponentAttack.ForeColor = System.Drawing.Color.Red;
            TBOpponentAttack.Text = "0";
            TBOpponentAttack.ReadOnly = true;
            TBOpponentAttack.Location = new System.Drawing.Point(
                pOpponentOffsetXHero - textBoxWidth,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBOpponentAttack.Name = "tbOpponentAttack";
            TBOpponentAttack.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBOpponentAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            POpponent.Controls.Add(TBOpponentAttack);

            TBOpponentArmour = new TextBox();
            TBOpponentArmour.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBOpponentArmour.ForeColor = System.Drawing.Color.Red;
            TBOpponentArmour.Text = "0";
            TBOpponentArmour.ReadOnly = true;
            TBOpponentArmour.Location = new System.Drawing.Point(
                pOpponentOffsetXHero + pbCardWidth,
                _margin
            );
            TBOpponentArmour.Name = "tbOpponentArmour";
            TBOpponentArmour.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBOpponentArmour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            POpponent.Controls.Add(TBOpponentArmour);

            TBOpponentHealth = new TextBox();
            TBOpponentHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBOpponentHealth.ForeColor = System.Drawing.Color.Red;
            TBOpponentHealth.Text = "0";
            TBOpponentHealth.ReadOnly = true;
            TBOpponentHealth.Location = new System.Drawing.Point(
                pOpponentOffsetXHero + pbCardWidth,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBOpponentHealth.Name = "tbOpponentHealth";
            TBOpponentHealth.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBOpponentHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            POpponent.Controls.Add(TBOpponentHealth);

            PBOpponentHeroPower = new PictureBox();
            PBOpponentHeroPower.Location = new System.Drawing.Point(
                battleboardPanelWidth - _margin - pbCardWidth,
                _margin
            );
            PBOpponentHeroPower.Name = "pbOpponentHeroPower";
            PBOpponentHeroPower.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBOpponentHeroPower.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            POpponent.Controls.Add(PBOpponentHeroPower);

            PMain.Controls.Add(POpponent);
            #endregion

            int offsetYAfterOpponent = offsetYAfterOpponentHand + _margin + panelHeight;
            int offsetYAfterOpponentBattleboard = offsetYAfterOpponent + _margin + panelHeight;
            int offsetYAfterPlayerBattleboard = offsetYAfterOpponentBattleboard + _margin + panelHeight;
            int offsetYAfterPlayer = offsetYAfterPlayerBattleboard + _margin + panelHeight;

            #region Opponent Battleboard
            POpponentBattleboard = new Panel();
            POpponentBattleboard.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            POpponentBattleboard.Location = new System.Drawing.Point(
                battleboardPanelXOffset,
                offsetYAfterOpponent
            );
            POpponentBattleboard.Name = "pOpponentBattleboard";
            POpponentBattleboard.Size = new System.Drawing.Size(battleboardPanelWidth, panelHeight);

            PBOpponentBattleboard = new PictureBox[_boardLimit];
            for (int i = 0; i < _boardLimit; i++)
            {
                int panelXOffset = i * (pbCardWidth + _margin) + _margin;
                PBOpponentBattleboard[i] = new PictureBox();
                PBOpponentBattleboard[i].Location = new System.Drawing.Point(panelXOffset, _margin);
                PBOpponentBattleboard[i].Name = "pOpponentBattleboard" + i;
                PBOpponentBattleboard[i].Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
                PBOpponentBattleboard[i].BackColor = System.Drawing.Color.LightGray; // TODO: remove

                POpponentBattleboard.Controls.Add(PBOpponentBattleboard[i]);
            }

            PMain.Controls.Add(POpponentBattleboard);
            #endregion

            #region Player Battleboard
            PPlayerBattleboard = new Panel();
            PPlayerBattleboard.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            PPlayerBattleboard.Location = new System.Drawing.Point(
                battleboardPanelXOffset,
                offsetYAfterOpponentBattleboard
            );
            PPlayerBattleboard.Name = "pPlayerBattleboard";
            PPlayerBattleboard.Size = new System.Drawing.Size(battleboardPanelWidth, panelHeight);

            PBPlayerBattleboard = new PictureBox[_boardLimit];
            for (int i = 0; i < _boardLimit; i++)
            {
                int panelXOffset = i * (pbCardWidth + _margin) + _margin;
                PBPlayerBattleboard[i] = new PictureBox();
                PBPlayerBattleboard[i].Location = new System.Drawing.Point(panelXOffset, _margin);
                PBPlayerBattleboard[i].Name = "pPlayerBattleboard" + i;
                PBPlayerBattleboard[i].Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
                PBPlayerBattleboard[i].BackColor = System.Drawing.Color.LightGray; // TODO: remove

                PPlayerBattleboard.Controls.Add(PBPlayerBattleboard[i]);
            }

            PMain.Controls.Add(PPlayerBattleboard);
            #endregion

            #region Player
            PPlayer = new Panel();
            PPlayer.Location = new System.Drawing.Point(battleboardPanelXOffset, offsetYAfterPlayerBattleboard);
            PPlayer.Name = "pPlayer";
            PPlayer.Size = new System.Drawing.Size(battleboardPanelWidth, panelHeight);

            PBPlayerWeapon = new PictureBox();
            PBPlayerWeapon.Location = new System.Drawing.Point(_margin, _margin);
            PBPlayerWeapon.Name = "pbPlayerWeapon";
            PBPlayerWeapon.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBPlayerWeapon.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            PPlayer.Controls.Add(PBPlayerWeapon);

            int pPlayerOffsetXAfterWeapon = pbCardWidth + _margin;

            TBPlayerWeaponDurability = new TextBox();
            TBPlayerWeaponDurability.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBPlayerWeaponDurability.ForeColor = System.Drawing.Color.Red;
            TBPlayerWeaponDurability.Text = "0";
            TBPlayerWeaponDurability.ReadOnly = true;
            TBPlayerWeaponDurability.Location = new System.Drawing.Point(
                pPlayerOffsetXAfterWeapon,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBPlayerWeaponDurability.Name = "tbPlayerWeaponDurability";
            TBPlayerWeaponDurability.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBPlayerWeaponDurability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            PPlayer.Controls.Add(TBPlayerWeaponDurability);

            int pPlayerOffsetXHero = battleboardPanelWidth / 2 - pbCardWidth / 2;
            PBPlayerHero = new PictureBox();
            PBPlayerHero.Location = new System.Drawing.Point(pPlayerOffsetXHero, _margin);
            PBPlayerHero.Name = "pbPlayerHero";
            PBPlayerHero.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBPlayerHero.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            PPlayer.Controls.Add(PBPlayerHero);

            TBPlayerAttack = new TextBox();
            TBPlayerAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBPlayerAttack.ForeColor = System.Drawing.Color.Red;
            TBPlayerAttack.Text = "0";
            TBPlayerAttack.ReadOnly = true;
            TBPlayerAttack.Location = new System.Drawing.Point(
                pPlayerOffsetXHero - textBoxWidth,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBPlayerAttack.Name = "tbPlayerAttack";
            TBPlayerAttack.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBPlayerAttack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            PPlayer.Controls.Add(TBPlayerAttack);

            TBPlayerArmour = new TextBox();
            TBPlayerArmour.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBPlayerArmour.ForeColor = System.Drawing.Color.Red;
            TBPlayerArmour.Text = "0";
            TBPlayerArmour.ReadOnly = true;
            TBPlayerArmour.Location = new System.Drawing.Point(
                pPlayerOffsetXHero + pbCardWidth,
                _margin
            );
            TBPlayerArmour.Name = "tbPlayerArmour";
            TBPlayerArmour.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBPlayerArmour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            PPlayer.Controls.Add(TBPlayerArmour);

            TBPlayerHealth = new TextBox();
            TBPlayerHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBPlayerHealth.ForeColor = System.Drawing.Color.Red;
            TBPlayerHealth.Text = "0";
            TBPlayerHealth.ReadOnly = true;
            TBPlayerHealth.Location = new System.Drawing.Point(
                pPlayerOffsetXHero + pbCardWidth,
                panelHeight - _margin - tbWeaponDurabilityHeight
            );
            TBPlayerHealth.Name = "tbPlayerHealth";
            TBPlayerHealth.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBPlayerHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            PPlayer.Controls.Add(TBPlayerHealth);

            PBPlayerHeroPower = new PictureBox();
            PBPlayerHeroPower.Location = new System.Drawing.Point(
                battleboardPanelWidth - _margin - pbCardWidth,
                _margin
            );
            PBPlayerHeroPower.Name = "pbPlayerHeroPower";
            PBPlayerHeroPower.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBPlayerHeroPower.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            PPlayer.Controls.Add(PBPlayerHeroPower);

            PMain.Controls.Add(PPlayer);
            #endregion

            #region PlayerHand
            // PPlayerHand
            PPlayerHand = new Panel();
            PPlayerHand.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            PPlayerHand.Location = new System.Drawing.Point(_margin, offsetYAfterPlayer);
            PPlayerHand.Name = "pPlayerHand";
            PPlayerHand.Size = new System.Drawing.Size(handPanelWidth, panelHeight);

            // PBPlayerHand
            PBPlayerHand = new PictureBox[_handLimit];

            for (int i = 0; i < _handLimit; i++)
            {
                int panelXOffset = i * (pbCardWidth + _margin) + _margin;
                PBPlayerHand[i] = new PictureBox();
                PBPlayerHand[i].Location = new System.Drawing.Point(panelXOffset, _margin);
                PBPlayerHand[i].Name = "pbPlayerHand" + i;
                PBPlayerHand[i].Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
                PBPlayerHand[i].BackColor = System.Drawing.Color.LightGray; // TODO: remove

                PPlayerHand.Controls.Add(PBPlayerHand[i]);
            }

            PMain.Controls.Add(PPlayerHand);
            #endregion

            #region Decks
            PBPlayerDeck = new PictureBox();
            int pbPlayerDeckX = offsetXAfterBattleboard + (offsetXAfterHands - offsetXAfterBattleboard) / 2 - pbCardWidth / 2;
            int pbPlayerDeckY = offsetYAfterPlayerBattleboard + panelHeight / 2 - pbCardHeight / 2;
            PBPlayerDeck.Location = new System.Drawing.Point(pbPlayerDeckX, pbPlayerDeckY);
            PBPlayerDeck.Name = "pbPlayerDeck";
            PBPlayerDeck.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBPlayerDeck.BackColor = System.Drawing.Color.LightGray; // TODO: remove

            TBPlayerDeckSize = new TextBox();
            TBPlayerDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBPlayerDeckSize.ForeColor = System.Drawing.Color.Red;
            TBPlayerDeckSize.Text = "30";
            TBPlayerDeckSize.ReadOnly = true;
            TBPlayerDeckSize.Location = new System.Drawing.Point(
                pbPlayerDeckX + pbCardWidth / 2 - textBoxWidth / 2,
                pbPlayerDeckY - tbWeaponDurabilityHeight
            );
            TBPlayerDeckSize.Name = "tbPlayerDeckSize";
            TBPlayerDeckSize.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBPlayerDeckSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            PBOpponentDeck = new PictureBox();
            int pbOpponentDeckX = offsetXAfterBattleboard + (offsetXAfterHands - offsetXAfterBattleboard) / 2 - pbCardWidth / 2;
            int pbOpponentDeckY = offsetYAfterOpponentHand + panelHeight / 2 - pbCardHeight / 2;
            PBOpponentDeck.Location = new System.Drawing.Point(pbOpponentDeckX, pbOpponentDeckY);
            PBOpponentDeck.Name = "pbOpponentDeck";
            PBOpponentDeck.Size = new System.Drawing.Size(pbCardWidth, pbCardHeight);
            PBOpponentDeck.BackColor = System.Drawing.Color.LightGray; // TODO: remove

            TBOpponentDeckSize = new TextBox();
            TBOpponentDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TBOpponentDeckSize.ForeColor = System.Drawing.Color.Red;
            TBOpponentDeckSize.Text = "30";
            TBOpponentDeckSize.ReadOnly = true;
            TBOpponentDeckSize.Location = new System.Drawing.Point(
                pbOpponentDeckX + pbCardWidth / 2 - textBoxWidth / 2,
                pbOpponentDeckY + pbCardHeight
            );
            TBOpponentDeckSize.Name = "tbOpponentDeckSize";
            TBOpponentDeckSize.Size = new System.Drawing.Size(textBoxWidth, tbWeaponDurabilityHeight);
            TBOpponentDeckSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            PMain.Controls.Add(PBOpponentDeck);
            PMain.Controls.Add(TBOpponentDeckSize);
            PMain.Controls.Add(PBPlayerDeck);
            PMain.Controls.Add(TBPlayerDeckSize);
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

            RTBGameLog = new RichTextBox();
            RTBGameLog.Name = "rtbGameLog";
            RTBGameLog.Location = new System.Drawing.Point(_margin, _margin);
            RTBGameLog.Size = new System.Drawing.Size(pageContentsWidth, pageContentsHeight);
            RTBGameLog.ReadOnly = true;
            RTBGameLog.BackColor = System.Drawing.Color.LightGray; // TODO: remove
            tpGameLog.Controls.Add(RTBGameLog);

            PMain.Controls.Add(TCInfo);
            #endregion

            

            /*
            
            
        public PictureBox PBPlayerDeck;
        public TextBox TBPlayerDeckSize;

        public PictureBox PBOpponentDeck;
        public TextBox TBOpponentDeckSize;
             */
        }
    }
}