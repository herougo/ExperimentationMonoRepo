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
        GameModel _model;
        GameView _view;

        public GameController(Form1 form)
        {
            _model = new GameModel(this);
            _view = new GameView(this, _model, form);
            _view.UpdateFullView();
        }

        public void Notify(int row, int column)
        {
            _view.UpdateView(row, column);
        }

        public void ReceiveInputClick(Tuple<int, int> pictureBoxIndex)
        {
            _model.SelectGridCell(pictureBoxIndex);
        }
    }
}
