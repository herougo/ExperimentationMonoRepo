using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelViewControllerSimpleApp.Controller;

namespace ModelViewControllerSimpleApp.Model
{
    internal class GameModel
    {
        public bool[,] IsSelected;
        Tuple<int, int> _selectedGridCell;
        public GameController Controller = null;

        public GameModel(GameController controller)
        {
            IsSelected = new bool[2, 2];
            Controller = controller;
            _selectedGridCell = new Tuple<int, int>(0, 0);
            SelectGridCell(_selectedGridCell, false);
        }

        public void Notify(int row, int column)
        {
            Controller.Notify(row, column);
        }

        public void SelectGridCell(Tuple<int, int> newSelectedGridCell, bool notify = true)
        {
            Tuple<int, int> oldSelectedGridCell = _selectedGridCell;
            IsSelected[oldSelectedGridCell.Item1, oldSelectedGridCell.Item2] = false;
            IsSelected[newSelectedGridCell.Item1, newSelectedGridCell.Item2] = true;
            _selectedGridCell = newSelectedGridCell;
            if (notify)
            {
                Notify(oldSelectedGridCell.Item1, oldSelectedGridCell.Item2);
                Notify(newSelectedGridCell.Item1, newSelectedGridCell.Item2);
            }
        }
    }
}
