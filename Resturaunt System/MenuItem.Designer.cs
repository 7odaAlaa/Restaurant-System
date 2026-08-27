namespace Resturaunt_System
{
    partial class MenuItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbMeal = new System.Windows.Forms.PictureBox();
            this.contextMenuStripMenuItemDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setItemDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbItemName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeal)).BeginInit();
            this.contextMenuStripMenuItemDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMeal
            // 
            this.pbMeal.Location = new System.Drawing.Point(3, 3);
            this.pbMeal.Name = "pbMeal";
            this.pbMeal.Size = new System.Drawing.Size(258, 127);
            this.pbMeal.TabIndex = 0;
            this.pbMeal.TabStop = false;
            // 
            // contextMenuStripMenuItemDetails
            // 
            this.contextMenuStripMenuItemDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.setItemDetailsToolStripMenuItem});
            this.contextMenuStripMenuItemDetails.Name = "contextMenuStripMenuItemDetails";
            this.contextMenuStripMenuItemDetails.Size = new System.Drawing.Size(156, 48);
            this.contextMenuStripMenuItemDetails.Text = "MenuItemDetails";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // setItemDetailsToolStripMenuItem
            // 
            this.setItemDetailsToolStripMenuItem.Name = "setItemDetailsToolStripMenuItem";
            this.setItemDetailsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.setItemDetailsToolStripMenuItem.Text = "Set Item Details";
            this.setItemDetailsToolStripMenuItem.Click += new System.EventHandler(this.setOrEditItemDetailsToolStripMenuItem_Click);
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemName.Location = new System.Drawing.Point(110, 133);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(50, 27);
            this.lbItemName.TabIndex = 2;
            this.lbItemName.Text = "[???]";
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStripMenuItemDetails;
            this.Controls.Add(this.lbItemName);
            this.Controls.Add(this.pbMeal);
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(264, 166);
            ((System.ComponentModel.ISupportInitialize)(this.pbMeal)).EndInit();
            this.contextMenuStripMenuItemDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbMeal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMenuItemDetails;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.ToolStripMenuItem setItemDetailsToolStripMenuItem;
    }
}
