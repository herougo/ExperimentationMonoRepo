using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WebFormView
{
    internal class ControlManager
    {
        Form Form;
        public PictureBox[,] PictureBoxes = new PictureBox[2,2];
        Dictionary<string, Tuple<int, int>> _nameToIndex;

        public ControlManager(Form form)
        {
            Form = form;
            _nameToIndex = new Dictionary<string, Tuple<int, int>>();
            InitializePictureBoxes();
        }

        private void InitializePictureBoxes()
        {
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    int index = row * 2 + column;
                    int locationX = 12 + column * 106;
                    int locationY = 12 + row * 106;
                    PictureBox pictureBox = CreatePictureBox(locationX, locationY, index);
                    PictureBoxes[row, column] = pictureBox;
                    Form.Controls.Add(pictureBox);
                    _nameToIndex.Add(pictureBox.Name, new Tuple<int, int>(row, column));
                }
            }
        }

        private PictureBox CreatePictureBox(int locationX, int locationY, int index)
        {
            PictureBox result = new PictureBox();
            result.BackColor = System.Drawing.SystemColors.ControlDark;
            result.Location = new System.Drawing.Point(locationX, locationY);
            result.Name = "PictureBoxes" + index;
            result.Size = new System.Drawing.Size(100, 100);
            result.TabIndex = index;
            result.TabStop = false;
            return result;
        }

        public Tuple<int, int> ControlToIndex(Control control)
        {
            return _nameToIndex[control.Name];
        }
    }
}
