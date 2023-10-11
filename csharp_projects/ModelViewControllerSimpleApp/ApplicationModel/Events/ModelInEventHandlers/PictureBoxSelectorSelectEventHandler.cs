using ApplicationModel.Events.ModelIn;
using ApplicationModel.Events.ModelOut;
using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationModel.Events.ModelInEventHandlers
{
    internal class PictureBoxSelectorSelectEventHandler : ModelInEventHandler
    {
        MainModel _model;

        public PictureBoxSelectorSelectEventHandler(MainModel model)
        {
            _model = model;
        }

        public override void Handle(MvcModelInEvent eventUntyped)
        {
            PictureBoxSelectorSelectEvent e = (PictureBoxSelectorSelectEvent)eventUntyped;
            Tuple<int, int> oldSelectedGridCell = _model.SelectedGridCell;
            _model.IsSelected[oldSelectedGridCell.Item1, oldSelectedGridCell.Item2] = false;
            _model.IsSelected[e.NewSelectedGridCell.Item1, e.NewSelectedGridCell.Item2] = true;
            _model.SelectedGridCell = e.NewSelectedGridCell;
            
            PictureBoxSelectorUpdatedEvent updateEvent = new PictureBoxSelectorUpdatedEvent(
                oldSelectedGridCell, e.NewSelectedGridCell
            );
            _model.SendEvent(updateEvent);
        }
    }
}
