using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturaunt_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void menuDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageMenu frmManageMenu = new ManageMenu();
            frmManageMenu.ShowDialog();
        }
    }
}
