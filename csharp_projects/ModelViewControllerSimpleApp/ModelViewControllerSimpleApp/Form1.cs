using ModelViewControllerSimpleApp.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelViewControllerSimpleApp
{
    public partial class Form1 : Form
    {
        readonly GameController _controller;

        public Form1()
        {
            _controller = new GameController(this);
            InitializeComponent();
        }
    }
}
