using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebFormController;

namespace HearthstoneFormsApp
{
    public partial class HearthstoneForm : Form
    {
        MvcWebFormController _controller;
        public HearthstoneForm()
        {
            _controller = new MvcWebFormController(this);
            InitializeComponent();
        }
    }
}
