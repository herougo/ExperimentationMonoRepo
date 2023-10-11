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
            SelectedGridCell = new Tuple<int, int>(0, 0);
            SelectGridCell(SelectedGridCell, false);
        }

        public void SelectGridCell(Tuple<int, int> newSelectedGridCell, bool notify = true)
        {
            
        }
    }
}
