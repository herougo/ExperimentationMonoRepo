using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.MVC;

using ApplicationModel.Events.ModelOut;

namespace ApplicationModel
{
    public class MainModel : MvcModel
    {
        public bool[,] IsSelected;
        Tuple<int, int> SelectedGridCell;
        MvcController _controller;

        public MainModel(MvcController controller)
        {
            _controller = controller;
            IsSelected = new bool[2, 2];
            SelectedGridCell = new Tuple<int, int>(0, 0);
            SelectGridCell(SelectedGridCell, false);
        }

        public void SelectGridCell(Tuple<int, int> newSelectedGridCell, bool notify = true)
        {
            Tuple<int, int> oldSelectedGridCell = SelectedGridCell;
            IsSelected[oldSelectedGridCell.Item1, oldSelectedGridCell.Item2] = false;
            IsSelected[newSelectedGridCell.Item1, newSelectedGridCell.Item2] = true;
            SelectedGridCell = newSelectedGridCell;
            if (notify)
            {
                PictureBoxSelectorUpdatedEvent updateEvent = new PictureBoxSelectorUpdatedEvent(
                    oldSelectedGridCell, newSelectedGridCell
                );
                SendEvent(updateEvent);
            }
        }
    }
}
