using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelViewControllerSimpleApp.Controller;

namespace ModelViewControllerSimpleApp.Model
{
    internal class GameModel
    {
        public bool[,] IsSelected;
        public GameController Controller = null;

        public GameModel(GameController controller)
        {
            IsSelected = new bool[2, 2];
            IsSelected[0, 0] = true;
            IsSelected[0, 1] = false;
            IsSelected[1, 0] = false;
            IsSelected[1, 1] = false;
            Controller = controller;
        }

        public void Notify(int row, int column)
        {
            Controller.Notify(row, column);
        }

        void SetGridCell(int row, int column, bool value)
        {
            IsSelected[row, column] = value;
            Notify(row, column);
        }
    }
}
