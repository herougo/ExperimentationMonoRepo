using ModelViewControllerSimpleApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelViewControllerSimpleApp.View
{
    internal class InputReceiver
    {
        GameController _controller;
        ControlManager _controlManager;

        public InputReceiver(GameController controller, ControlManager controlManager)
        {
            _controller = controller;
            _controlManager = controlManager;
            foreach (PictureBox pictureBox in controlManager.PictureBoxes)
            {
                pictureBox.Click += new System.EventHandler(pictureBox_Click);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Tuple<int, int> index = _controlManager.ControlToIndex(control);
            _controller.ReceiveInputClick(index);
        }
    }
}
