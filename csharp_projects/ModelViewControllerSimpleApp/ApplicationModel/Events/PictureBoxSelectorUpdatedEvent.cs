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
        public Tuple<int, int> OldSelectedGridCell { get; }
        public Tuple<int, int> NewSelectedGridCell { get; }

        public PictureBoxSelectorUpdatedEvent(Tuple<int, int> oldSelected, Tuple<int, int> newSelected)
        {
            OldSelectedGridCell = oldSelected;
            NewSelectedGridCell = newSelected;
        }
    }
}
