using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace ims.UI.Controls
{
    partial class ItemFormControl
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2TextBox txtName;
        private Guna2TextBox txtDescription;
        private Guna2TextBox txtPrice;
        private NumericUpDown numQuantity;
        private Guna2ComboBox cmbCategory;
        private Guna2ComboBox cmbBarcodeType;
        private Guna2Button btnSave;
        private Guna2Button btnDownloadBarcode;
        private Guna2Button btnAddImage;
        private Guna2Button btnDeleteImage;
        private Guna2Button btnNext;
        private Guna2Button btnPrev;
        private PictureBox pbBarcode;
        private PictureBox pbImagePreview;
        private Label lblImageIndex;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new Guna2TextBox();
            this.txtDescription = new Guna2TextBox();
            this.txtPrice = new Guna2TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbCategory = new Guna2ComboBox();
            this.cmbBarcodeType = new Guna2ComboBox();
            this.btnSave = new Guna2Button();
            this.btnDownloadBarcode = new Guna2Button();
            this.btnAddImage = new Guna2Button();
            this.btnDeleteImage = new Guna2Button();
            this.btnNext = new Guna2Button();
            this.btnPrev = new Guna2Button();
            this.pbBarcode = new System.Windows.Forms.PictureBox();
            this.pbImagePreview = new System.Windows.Forms.PictureBox();
            this.lblImageIndex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Item Name";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(250, 36);
            this.txtName.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(20, 70);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description (optional)";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(250, 36);
            this.txtDescription.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrice.Location = new System.Drawing.Point(20, 170);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "Price";
            this.txtPrice.SelectedText = "";
            this.txtPrice.Size = new System.Drawing.Size(250, 36);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.TxtPrice_Leave);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(20, 220);
            this.numQuantity.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(250, 26);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.ValueChanged += new System.EventHandler(this.NumQuantity_ValueChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCategory.ItemHeight = 30;
            this.cmbCategory.Location = new System.Drawing.Point(20, 120);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(250, 36);
            this.cmbCategory.TabIndex = 4;
            // 
            // cmbBarcodeType
            // 
            this.cmbBarcodeType.BackColor = System.Drawing.Color.Transparent;
            this.cmbBarcodeType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcodeType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbBarcodeType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBarcodeType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBarcodeType.ItemHeight = 30;
            this.cmbBarcodeType.Location = new System.Drawing.Point(20, 270);
            this.cmbBarcodeType.Name = "cmbBarcodeType";
            this.cmbBarcodeType.Size = new System.Drawing.Size(250, 36);
            this.cmbBarcodeType.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(300, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(300, 45);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDownloadBarcode
            // 
            this.btnDownloadBarcode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDownloadBarcode.ForeColor = System.Drawing.Color.White;
            this.btnDownloadBarcode.Location = new System.Drawing.Point(20, 410);
            this.btnDownloadBarcode.Name = "btnDownloadBarcode";
            this.btnDownloadBarcode.Size = new System.Drawing.Size(250, 36);
            this.btnDownloadBarcode.TabIndex = 7;
            this.btnDownloadBarcode.Text = "Download Barcode";
            this.btnDownloadBarcode.Visible = false;
            this.btnDownloadBarcode.Click += new System.EventHandler(this.BtnDownloadBarcode_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(300, 250);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(140, 36);
            this.btnAddImage.TabIndex = 12;
            this.btnAddImage.Text = "Add Images";
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteImage.ForeColor = System.Drawing.Color.White;
            this.btnDeleteImage.Location = new System.Drawing.Point(460, 250);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(140, 36);
            this.btnDeleteImage.TabIndex = 13;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.Click += new System.EventHandler(this.BtnDeleteImage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(460, 205);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(45, 30);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(410, 205);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(45, 30);
            this.btnPrev.TabIndex = 10;
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // pbBarcode
            // 
            this.pbBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBarcode.Location = new System.Drawing.Point(20, 320);
            this.pbBarcode.Name = "pbBarcode";
            this.pbBarcode.Size = new System.Drawing.Size(250, 80);
            this.pbBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBarcode.TabIndex = 6;
            this.pbBarcode.TabStop = false;
            // 
            // pbImagePreview
            // 
            this.pbImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagePreview.Location = new System.Drawing.Point(300, 20);
            this.pbImagePreview.Name = "pbImagePreview";
            this.pbImagePreview.Size = new System.Drawing.Size(300, 180);
            this.pbImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagePreview.TabIndex = 8;
            this.pbImagePreview.TabStop = false;
            // 
            // lblImageIndex
            // 
            this.lblImageIndex.Location = new System.Drawing.Point(300, 205);
            this.lblImageIndex.Name = "lblImageIndex";
            this.lblImageIndex.Size = new System.Drawing.Size(100, 20);
            this.lblImageIndex.TabIndex = 9;
            // 
            // ItemFormControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbBarcodeType);
            this.Controls.Add(this.pbBarcode);
            this.Controls.Add(this.btnDownloadBarcode);
            this.Controls.Add(this.pbImagePreview);
            this.Controls.Add(this.lblImageIndex);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.btnSave);
            this.Name = "ItemFormControl";
            this.Size = new System.Drawing.Size(630, 480);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePreview)).EndInit();
            this.ResumeLayout(false);

        }
    }
}