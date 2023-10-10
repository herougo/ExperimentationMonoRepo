using ApplicationModel;
using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebFormView
{
    public class MainWebFormView : MvcView
    {
        public MainWebFormView(MvcController controller, MvcModel model)
        {
            _controller = controller;
            _model = model;
            _eventHandlerFactory = new ??? ModelOutEventHandlerFactory(this);
        }
    }
}
