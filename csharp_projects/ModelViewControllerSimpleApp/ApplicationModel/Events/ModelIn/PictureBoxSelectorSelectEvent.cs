using ApplicationModel.Events.Enums;
using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationModel.Events.ModelIn
{
    public class PictureBoxSelectorSelectEvent : ModelInEvent
    {
        public Tuple<int, int> NewSelectedGridCell { get; }

        public PictureBoxSelectorSelectEvent(Tuple<int, int> newSelected)
        {
            NewSelectedGridCell = newSelected;
        }

        public override ModelInEvents GetEnum()
        {
            return ModelInEvents.PictureBoxSelected;
        }
    }
}
