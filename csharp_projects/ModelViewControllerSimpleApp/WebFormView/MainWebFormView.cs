using ApplicationModel;
using Core.MVC;
using WebFormView.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebFormView
{
    public class MainWebFormView : MvcView
    {
        Form Form;
        ControlManager ControlManager;
        InputReceiver InputReceiver;
        MainModel _model;

        public MainWebFormView(MvcController controller, MainModel model, Form form)
        {
            _controller = controller;
            _eventHandlerFactory = new ModelOutEventHandlerFactory(this);

            _model = model;
            Form = form;
            ControlManager = new ControlManager(form);
            InputReceiver = new InputReceiver(controller, ControlManager);
        }

        public void UpdateFullView()
        {
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    UpdateView(row, column);
                }
            }
        }

        public void UpdateView(int row, int column)
        {
            bool val = _model.IsSelected[row, column];
            PictureBox selectedPictureBox = ControlManager.PictureBoxes[row, column];
            if (val)
            {
                selectedPictureBox.BackColor = System.Drawing.SystemColors.Highlight;
            }
            else
            {
                selectedPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            }
        }
    }
}
