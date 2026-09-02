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
    public partial class MenuItem : UserControl
    {
        clsMenuItem _AnItem = null;
        public MenuItem()
        {
            InitializeComponent();
            LoadInfo();
        }

        public MenuItem(clsMenuItem AnItem)
        {
            InitializeComponent();
            _AnItem = AnItem;

            LoadInfo(AnItem);
            
        }

       private void LoadInfo() 
       {
            setItemDetailsToolStripMenuItem.Text = "Set Details";
            detailsToolStripMenuItem.Enabled = false;
       }

        public void LoadInfo(clsMenuItem AnItem) 
        {
            setItemDetailsToolStripMenuItem.Text = "Update Details";
            pbMeal.ImageLocation = AnItem.ImageLink;
            lbItemName.Text = AnItem.Name;
        }
        
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(clsMenuItem.GetById(0).Description);
        }

        private void setOrEditItemDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SetEditMenuItem frm = new SetEditMenuItem(_AnItem);
            frm.ShowDialog();
        }
    }
}
