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
            _model = model;
            _view = new MainWebFormView(this, model, form);
            _form = form;
            _eventHandlerFactory = new ViewOutEventHandlerFactory(this);
        }
    }
}
