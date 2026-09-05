using Resturaunt_Manage_System_Business_Layer;
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
    public partial class ManageMenu : Form
    {
        public ManageMenu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = new MenuItem();
            flowLayoutPanel1.Controls.Add(menuItem);

            menuItem.OnAddingMenuItem += ManageMenu_Load;
        }

        private void ManageMenu_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in clsMenuItem.GetAll()) 
            {
                MenuItem menuItem = new MenuItem(item);
                flowLayoutPanel1.Controls.Add(menuItem);
            }
        }
    }
}
