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
        GameController Controller;

        public Form1()
        {
            Controller = new GameController(this);
            InitializeComponent();
        }
    }
}
