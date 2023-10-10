using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public abstract class ModelInEventHandler : IEventHandler<ModelInEvent>
    {
        protected MvcModel _model;
        
        public ModelInEventHandler(MvcModel model)
        {
            _model = model;
        }

        public abstract void Handle(ModelInEvent e);
    }

    public abstract class ModelOutEventHandler : IEventHandler<ModelOutEvent>
    {
        protected MvcController _controller;

        public ModelOutEventHandler(MvcController controller)
        {
            _controller = controller;
        }

        public abstract void Handle(ModelOutEvent e);
    }
    public abstract class ViewOutEventHandler : IEventHandler<ViewOutEvent>
    {
        protected MvcController _controller;

        public ViewOutEventHandler(MvcController controller)
        {
            _controller = controller;
        }

        public abstract void Handle(ViewOutEvent e);
    }
}
