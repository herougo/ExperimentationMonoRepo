using Core.MVC;
using GameModel;
using GameModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebFormController.Events;
using WebFormView;

namespace WebFormController
{
    public class MvcWebFormController
    {
        EventSender _eventSender;
        MvcGameModel _model;
        MvcWebFormView _view;
        Form _form;

        public MvcWebFormController(Form form) {
            _form = form;
            _eventSender = new EventSender();
            WebFormControllerEventReceiver controllerEventReceiver = new WebFormControllerEventReceiver(this);
            
            EventSender modelEventSender = new EventSender();
            _model = new MvcGameModel(modelEventSender);
            GameModelEventReceiver modelEventReceiver = new GameModelEventReceiver(_model);

            EventSender viewEventSender = new EventSender();
            _view = new MvcWebFormView(viewEventSender, _model, form);
            WebFormViewEventReceiver viewEventReceiver = new WebFormViewEventReceiver(_view);
            
            // model -> view -> controller -> model
            modelEventSender.AddReceiver(viewEventReceiver);
            viewEventSender.AddReceiver(controllerEventReceiver);
            _eventSender.AddReceiver(modelEventReceiver);
        }
    }
}
