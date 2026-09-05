using Resturaunt_Manage_System_Business_Layer;
using Resturaunt_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
//using TextBox = System.Windows.Forms.TextBox;

namespace Resturaunt_System
{
    public partial class SetEditMenuItem : Form
    {
        enum enMode {Add , Update};

        enMode _Mode;
        clsMenuItem _MenuItem = null;

        public SetEditMenuItem()
        {
            InitializeComponent();
            _MenuItem = new clsMenuItem();
            _Mode = enMode.Add;
        }

        public SetEditMenuItem(clsMenuItem MenuItem)
        {
            InitializeComponent();
            _MenuItem = MenuItem;

            _Mode = enMode.Update;
        }

        public void Reset() 
        {
            lbTitile.Text = "Set Menu Item";

            cbType.Items.Add("Italian");
            cbType.Items.Add("Spanish");
            cbType.Items.Add("French");

            // Clear all text fields
            txtName.Clear(); // Name
            txtPrice.Clear(); // Price
            txtDecription.Clear(); // Description

            // Reset ComboBox to the first item
         
            cbType.SelectedIndex = 0;
            

            // Uncheck the CheckBox
            CheckBoxIsAvilable.Checked = false;

            // Clear the image preview (PictureBox)
            pbMealImage.Image = null;

            // Optional: Reset focus to the first input
            txtName.Focus();

        }

        public void LoadInfo()
        {
            if (_MenuItem == null)
            {
                MessageBox.Show("No MenuItem with Name : " + _MenuItem.Name, " Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lbTitile.Text = "Update Menu Item";

            txtName.Text = _MenuItem.Name;
            txtDecription.Text = _MenuItem.Description;
            txtPrice.Text = _MenuItem.Price.ToString();

            CheckBoxIsAvilable.Checked = _MenuItem.IsAvailable;

            switch (_MenuItem.type)
            {
                case clsMenuItem.enType.Italian:
                    cbType.Text = "Italian";
                    break;
                case clsMenuItem.enType.Spanish:
                    cbType.Text = "Spanish";
                    break;
                case clsMenuItem.enType.Frenech:
                    cbType.Text = "Frenech";
                    break;
                default:
                    cbType.Text = "";
                    break;
            }

            if (_MenuItem.ImageLink != "")
                pbMealImage.ImageLocation = _MenuItem.ImageLink;
        }

        private void SetEditMenuItem_Load(object sender, EventArgs e)
        {
            Reset();

            if (_Mode == enMode.Update)
                LoadInfo();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleMealImage())
                return;

            _MenuItem.Name = txtName.Text;
            _MenuItem.Description = txtDecription.Text;
            _MenuItem.Price = decimal.Parse(txtPrice.Text);
            _MenuItem.IsAvailable = CheckBoxIsAvilable.Checked;
            _MenuItem.type = (clsMenuItem.enType) (cbType.SelectedIndex + 1);
            _MenuItem.ImageLink = pbMealImage.ImageLocation != null ? pbMealImage.ImageLocation : "";
            _MenuItem.SupplierId = 1;
            _MenuItem.CreatedAt = DateTime.Now;
            _MenuItem.UpdatedAt = DateTime.Now;


            if (_MenuItem.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool _HandleMealImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_MenuItem.ImageLink != pbMealImage.ImageLocation)
            {
                if (_MenuItem.ImageLink != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_MenuItem.ImageLink);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbMealImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbMealImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbMealImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbMealImage.ImageLocation = null;
            linkLabelRemove.Visible = false;
        }

        private void linkLabelSetEditImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbMealImage.Load(selectedFilePath);
                linkLabelRemove.Visible = true;
                // ...
            }
        }

      

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, arrows, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits and one decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block invalid characters
            }

            // Block a second decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true; // Block the second dot
            }
        }
    
    }
}
