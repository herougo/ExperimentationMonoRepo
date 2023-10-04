using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    abstract class MvcController
    {
        protected MvcModel _model;
        protected MvcView _view;
        public void ReceiveModelEvent(ModelOutEvent e)
        {
            _view.ReceiveEvent(e);
        }
        public abstract void ReceiveViewEvent(ViewOutEvent e);
    }
}
