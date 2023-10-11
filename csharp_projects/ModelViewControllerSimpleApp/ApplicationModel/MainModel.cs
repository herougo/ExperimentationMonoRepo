using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.MVC;

using ApplicationModel.Events.ModelOut;
using ApplicationModel.Events;

namespace ApplicationModel
{
    public class MainModel : MvcModel
    {
        public bool[,] IsSelected;
        public Tuple<int, int> SelectedGridCell;

        public MainModel(MvcController controller)
        {
            _controller = controller;
            _eventHandlerFactory = new ModelInEventHandlerFactory(this);

            IsSelected = new bool[2, 2];
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    IsSelected[row, col] = false;
                }
            }
            SelectedGridCell = new Tuple<int, int>(0, 0);
            IsSelected[SelectedGridCell.Item1, SelectedGridCell.Item2] = true;
        }
    }
}
