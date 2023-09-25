using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelViewControllerSimpleApp.View
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
            // 
            // pictureBox0
            // 
            PictureBoxes[0, 0] = new PictureBox();
            PictureBoxes[0, 0].BackColor = System.Drawing.SystemColors.ControlDark;
            PictureBoxes[0, 0].Location = new System.Drawing.Point(12, 12);
            PictureBoxes[0, 0].Name = "PictureBoxes0";
            PictureBoxes[0, 0].Size = new System.Drawing.Size(100, 100);
            PictureBoxes[0, 0].TabIndex = 0;
            PictureBoxes[0, 0].TabStop = false;
            // 
            // pictureBox1
            // 
            PictureBoxes[0, 1] = new PictureBox();
            PictureBoxes[0, 1].BackColor = System.Drawing.SystemColors.Highlight;
            PictureBoxes[0, 1].Location = new System.Drawing.Point(118, 12);
            PictureBoxes[0, 1].Name = "PictureBoxes1";
            PictureBoxes[0, 1].Size = new System.Drawing.Size(100, 100);
            PictureBoxes[0, 1].TabIndex = 1;
            PictureBoxes[0, 1].TabStop = false;
            // 
            // pictureBox2
            // 
            PictureBoxes[1, 0] = new PictureBox();
            PictureBoxes[1, 0].BackColor = System.Drawing.SystemColors.ControlDark;
            PictureBoxes[1, 0].Location = new System.Drawing.Point(12, 118);
            PictureBoxes[1, 0].Name = "PictureBoxes2";
            PictureBoxes[1, 0].Size = new System.Drawing.Size(100, 100);
            PictureBoxes[1, 0].TabIndex = 3;
            PictureBoxes[1, 0].TabStop = false;
            // 
            // pictureBox3
            // 
            PictureBoxes[1, 1] = new PictureBox();
            this.PictureBoxes[1, 1].BackColor = System.Drawing.SystemColors.ControlDark;
            this.PictureBoxes[1, 1].Location = new System.Drawing.Point(118, 118);
            this.PictureBoxes[1, 1].Name = "PictureBoxes3";
            this.PictureBoxes[1, 1].Size = new System.Drawing.Size(100, 100);
            this.PictureBoxes[1, 1].TabIndex = 2;
            this.PictureBoxes[1, 1].TabStop = false;

            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    PictureBox pictureBox = PictureBoxes[row, column];
                    Form.Controls.Add(pictureBox);
                    _nameToIndex.Add(pictureBox.Name, new Tuple<int, int>(row, column));
                }
            }
        }

        public Tuple<int, int> ControlToIndex(Control control)
        {
            return _nameToIndex[control.Name];
        }
    }
}
