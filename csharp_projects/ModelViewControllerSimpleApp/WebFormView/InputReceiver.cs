using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebFormView.Events.ViewOut;

namespace WebFormView
{

    internal class InputReceiver
    {
        readonly MvcController _controller;
        readonly ControlManager _controlManager;

        public InputReceiver(MvcController controller, ControlManager controlManager)
        {
            _controller = controller;
            _controlManager = controlManager;
            foreach (PictureBox pictureBox in controlManager.PictureBoxes)
            {
                pictureBox.Click += new System.EventHandler(PictureBox_Click);
            }
        }

        private void PictureBox_Click(object sender, EventArgs eventArgs)
        {
            Control control = (Control)sender;
            Tuple<int, int> index = _controlManager.ControlToIndex(control);
            MvcViewOutEvent e = new PictureBoxClickedEvent(index);
            _controller.ReceiveViewEvent(e);
        }
    }
}