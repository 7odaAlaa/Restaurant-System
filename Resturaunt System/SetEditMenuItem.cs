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

namespace Resturaunt_System
{
    public partial class SetEditMenuItem : Form
    {
        clsMenuItem _MenuItem = null;

       
        public SetEditMenuItem(clsMenuItem MenuItem)
        {
            InitializeComponent();
            _MenuItem = MenuItem;
        }

        public void LoadInfo() 
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleMealImage())
                return;
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

        private void SetEditMenuItem_Load(object sender, EventArgs e)
        {
            if(_MenuItem != null) 
            {
                txtName.Text = _MenuItem.Name;
                txtDecription.Text = _MenuItem.Description;
                txtPrice.Text =_MenuItem.Price.ToString();

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
        }
    }
}
