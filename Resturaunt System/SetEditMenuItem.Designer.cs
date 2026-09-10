namespace Resturaunt_System
{
    partial class SetEditMenuItem
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDecription = new System.Windows.Forms.TextBox();
            this.pbMealImage = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbDecription = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.CheckBoxIsAvilable = new System.Windows.Forms.CheckBox();
            this.lbTitile = new System.Windows.Forms.Label();
            this.linkLabelSetEditImage = new System.Windows.Forms.LinkLabel();
            this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbMealImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(161, 83);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(205, 24);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(496, 114);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(121, 24);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtDecription
            // 
            this.txtDecription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecription.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDecription.Location = new System.Drawing.Point(161, 155);
            this.txtDecription.Multiline = true;
            this.txtDecription.Name = "txtDecription";
            this.txtDecription.Size = new System.Drawing.Size(456, 56);
            this.txtDecription.TabIndex = 0;
            // 
            // pbMealImage
            // 
            this.pbMealImage.Location = new System.Drawing.Point(662, 45);
            this.pbMealImage.Name = "pbMealImage";
            this.pbMealImage.Size = new System.Drawing.Size(229, 156);
            this.pbMealImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMealImage.TabIndex = 2;
            this.pbMealImage.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(52, 77);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(93, 33);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name : ";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.Location = new System.Drawing.Point(62, 111);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(83, 33);
            this.lbType.TabIndex = 3;
            this.lbType.Text = "Type : ";
            // 
            // lbDecription
            // 
            this.lbDecription.AutoSize = true;
            this.lbDecription.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDecription.Location = new System.Drawing.Point(6, 149);
            this.lbDecription.Name = "lbDecription";
            this.lbDecription.Size = new System.Drawing.Size(139, 33);
            this.lbDecription.TabIndex = 3;
            this.lbDecription.Text = "Decription : ";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(404, 109);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(86, 33);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Price : ";
            // 
            // CheckBoxIsAvilable
            // 
            this.CheckBoxIsAvilable.AutoSize = true;
            this.CheckBoxIsAvilable.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxIsAvilable.Location = new System.Drawing.Point(496, 72);
            this.CheckBoxIsAvilable.Name = "CheckBoxIsAvilable";
            this.CheckBoxIsAvilable.Size = new System.Drawing.Size(121, 37);
            this.CheckBoxIsAvilable.TabIndex = 1;
            this.CheckBoxIsAvilable.Text = "IsAvilable";
            this.CheckBoxIsAvilable.UseVisualStyleBackColor = true;
            // 
            // lbTitile
            // 
            this.lbTitile.AutoSize = true;
            this.lbTitile.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitile.Location = new System.Drawing.Point(297, 9);
            this.lbTitile.Name = "lbTitile";
            this.lbTitile.Size = new System.Drawing.Size(239, 51);
            this.lbTitile.TabIndex = 3;
            this.lbTitile.Text = "Set Menu Item";
            // 
            // linkLabelSetEditImage
            // 
            this.linkLabelSetEditImage.AutoSize = true;
            this.linkLabelSetEditImage.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSetEditImage.LinkColor = System.Drawing.Color.DarkSlateGray;
            this.linkLabelSetEditImage.Location = new System.Drawing.Point(700, 214);
            this.linkLabelSetEditImage.Name = "linkLabelSetEditImage";
            this.linkLabelSetEditImage.Size = new System.Drawing.Size(87, 22);
            this.linkLabelSetEditImage.TabIndex = 4;
            this.linkLabelSetEditImage.TabStop = true;
            this.linkLabelSetEditImage.Text = "Set Image";
            this.linkLabelSetEditImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSetEditImage_LinkClicked);
            // 
            // linkLabelRemove
            // 
            this.linkLabelRemove.AutoSize = true;
            this.linkLabelRemove.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelRemove.LinkColor = System.Drawing.Color.DarkSlateGray;
            this.linkLabelRemove.Location = new System.Drawing.Point(793, 214);
            this.linkLabelRemove.Name = "linkLabelRemove";
            this.linkLabelRemove.Size = new System.Drawing.Size(69, 22);
            this.linkLabelRemove.TabIndex = 4;
            this.linkLabelRemove.TabStop = true;
            this.linkLabelRemove.Text = "Remove";
            this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemove_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightCyan;
            this.btnSave.Font = new System.Drawing.Font("Segoe Script", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(22, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbType
            // 
            this.cbType.AutoCompleteCustomSource.AddRange(new string[] {
            "Italian ",
            "Spanish ",
            "French"});
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(161, 117);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(205, 26);
            this.cbType.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SetEditMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(906, 261);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.linkLabelRemove);
            this.Controls.Add(this.linkLabelSetEditImage);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbDecription);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbTitile);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pbMealImage);
            this.Controls.Add(this.CheckBoxIsAvilable);
            this.Controls.Add(this.txtDecription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Name = "SetEditMenuItem";
            this.Text = "SetEditMenuItem";
            this.Load += new System.EventHandler(this.SetEditMenuItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMealImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDecription;
        private System.Windows.Forms.PictureBox pbMealImage;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbDecription;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.CheckBox CheckBoxIsAvilable;
        private System.Windows.Forms.Label lbTitile;
        private System.Windows.Forms.LinkLabel linkLabelSetEditImage;
        private System.Windows.Forms.LinkLabel linkLabelRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}