using Core.MVC;
using GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebFormView.UI.WebForm.ControlManager;

namespace WebFormView
{
    public class MvcWebFormView
    {
        EventSender _eventSender;
        MvcGameModel _model;
        Form _form;
        public HSGameControlManager HearthstoneControlManager;

        public MvcWebFormView(EventSender eventSender, MvcGameModel model, Form form)
        {
            _eventSender = eventSender;
            _model = model;
            _form = form;
            HearthstoneControlManager = new HSGameControlManager(form);

        }

        public void SendEvent(IEvent e)
        {
            _eventSender.Send(e);
        }


    }
}
