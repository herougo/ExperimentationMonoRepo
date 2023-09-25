using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelViewControllerSimpleApp.Model;
using ModelViewControllerSimpleApp.View;

namespace ModelViewControllerSimpleApp.Controller
{
    internal class GameController
    {
        GameModel model;
        GameView view;

        public GameController(Form1 form)
        {
            model = new GameModel(this);
            view = new GameView(this, model, form);
        }

        public void Notify(int row, int column)
        {
            view.UpdateView(row, column);
        }
    }
}
