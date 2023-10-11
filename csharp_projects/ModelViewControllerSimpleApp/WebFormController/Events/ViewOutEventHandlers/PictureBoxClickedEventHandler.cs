using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationModel;
using ApplicationModel.Events.ModelIn;
using Core.MVC;
using WebFormView.Events.ViewOut;

namespace WebFormController.Events.ViewOutEventHandlers
{
    internal class PictureBoxClickedEventHandler : ViewOutEventHandler
    {
        MainWebFormController _controller;
        public PictureBoxClickedEventHandler(MainWebFormController controller)
        {
            _controller = controller;
        }

        public override void Handle(MvcViewOutEvent untypedEvent)
        {
            PictureBoxClickedEvent e = (PictureBoxClickedEvent)untypedEvent;
            MvcModelInEvent newEvent = new PictureBoxSelectorSelectEvent(e.Index);
            _controller.SendModelEvent(newEvent);
        }
    }
}
