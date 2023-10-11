using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebFormView.Events;
using WebFormView.Events.Enums;

namespace WebFormView.Events.ViewOut
{
    public class PictureBoxClickedEvent : ViewOutEvent
    {
        public Tuple<int, int> Index { get; }

        public PictureBoxClickedEvent(Tuple<int, int> index) {
            Index = index;
        }

        public override ViewOutEvents GetEnum()
        {
            return ViewOutEvents.PictureBoxClicked;
        }
    }
}
