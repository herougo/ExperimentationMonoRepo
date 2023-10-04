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
        protected MvcModel model;
        protected MvcView view;
        public void ReceiveModelEvent(ModelOutEvent e)
        {
            view.ReceiveEvent(e);
        }
        public abstract void ReceiveViewEvent(ViewOutEvent e);
    }
}
