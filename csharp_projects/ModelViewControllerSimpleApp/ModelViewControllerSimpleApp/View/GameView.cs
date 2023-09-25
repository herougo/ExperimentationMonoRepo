using ModelViewControllerSimpleApp.Controller;
using ModelViewControllerSimpleApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelViewControllerSimpleApp.View
{
    internal class GameView
    {
        GameController Controller;
        GameModel GameModel;
        Form1 Form;
        ControlManager ControlManager;
        InputReceiver InputReceiver;

        public GameView(GameController controller, GameModel gameModel, Form1 form)
        {
            Controller = controller;
            GameModel = gameModel;
            Form = form;
            ControlManager = new ControlManager(form);
            InputReceiver = new InputReceiver(controller, ControlManager);
        }

        public void UpdateFullView()
        {
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    UpdateView(row, column);
                }
            }
        }

        public void UpdateView(int row, int column)
        {
            bool val = GameModel.IsSelected[row, column];
            PictureBox selectedPictureBox = ControlManager.PictureBoxes[row, column];
            if (val)
            {
                selectedPictureBox.BackColor = System.Drawing.SystemColors.Highlight;
            } else {
                selectedPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            }
        }
    }
}
