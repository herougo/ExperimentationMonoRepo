using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationModel;
using WebFormView;

namespace WebFormController
{
    public class MainWebFormController : MvcController
    {
        Form _form;

        public MainWebFormController(Form form) {
            _model = new MainModel(this);
            _view = new MainWebFormView(this, _model);
            _form = form;
        }
    }
}
