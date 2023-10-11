using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationModel;
using WebFormView;
using WebFormController.Events;

namespace WebFormController
{
    public class MainWebFormController : MvcController
    {
        Form _form;

        public MainWebFormController(Form form) {
            MainModel model = new MainModel(this);
            MainWebFormView view = new MainWebFormView(this, model, form);
            _model = model;
            _view = view;
            _form = form;
            _eventHandlerFactory = new ViewOutEventHandlerFactory(this);
            view.UpdateFullView();
        }
    }
}
