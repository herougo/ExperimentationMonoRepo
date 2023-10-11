using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationModel;
using ApplicationModel.Events;
using ApplicationModel.Events.Enums;
using ApplicationModel.Events.ModelIn;
using ApplicationModel.Events.ModelOut;
using Core.MVC;

namespace WebFormView.Events.ModelOutEventHandlers
{
    public class PictureBoxSelectorUpdatedEventHandler : ModelOutEventHandler
    {
        MainWebFormView _view;

        public PictureBoxSelectorUpdatedEventHandler(MainWebFormView view)
        {
            _view = view;
        }

        public override void Handle(MvcModelOutEvent eventUntyped)
        {
            PictureBoxSelectorUpdatedEvent e = (PictureBoxSelectorUpdatedEvent)eventUntyped;
            _view.UpdateView(e.NewSelectedGridCell.Item1, e.NewSelectedGridCell.Item2);
            _view.UpdateView(e.OldSelectedGridCell.Item1, e.OldSelectedGridCell.Item2);
        }
    }
}
