using ModelViewControllerSimpleApp.Controller;
using ModelViewControllerSimpleApp.Model;
using System;
using System.Collections.Generic;
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

        public GameView(GameController controller, GameModel gameModel, Form1 form)
        {
            Controller = controller;
            GameModel = gameModel;
            Form = form;
        }

        public void UpdateView(int row, int column)
        {
            bool val = GameModel.IsSelected[row, column];
            
        }
    }
}
