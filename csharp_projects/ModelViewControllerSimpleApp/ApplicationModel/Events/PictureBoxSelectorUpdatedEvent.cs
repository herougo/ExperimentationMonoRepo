using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.MVC;

namespace ApplicationModel.Events
{
    public class PictureBoxSelectorUpdatedEvent : ModelOutEvent
    {
        public readonly Tuple<int, int> OldSelectedGridCell;
        public readonly Tuple<int, int> NewSelectedGridCell;

        public PictureBoxSelectorUpdatedEvent(Tuple<int, int> oldSelected, Tuple<int, int> newSelected)
        {
            OldSelectedGridCell = oldSelected;
            NewSelectedGridCell = newSelected;
        }
    }
}
