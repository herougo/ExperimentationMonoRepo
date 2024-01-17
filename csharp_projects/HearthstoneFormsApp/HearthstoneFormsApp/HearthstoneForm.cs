using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebFormView.UI.WebForm.ControlManager;

namespace HearthstoneFormsApp
{
    public partial class HearthstoneForm : Form
    {
        HSGameControlManager HearthstoneControlManager;

        public HearthstoneForm()
        {
            HearthstoneControlManager = new HSGameControlManager(this);
            InitializeComponent();
        }
    }
}
