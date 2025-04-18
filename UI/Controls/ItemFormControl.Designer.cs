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
            this.numQuantity = new NumericUpDown();
            this.cmbCategory = new Guna2ComboBox();
            this.cmbBarcodeType = new Guna2ComboBox();
            this.btnSave = new Guna2Button();
            this.btnDownloadBarcode = new Guna2Button();
            this.btnAddImage = new Guna2Button();
            this.btnDeleteImage = new Guna2Button();
            this.btnNext = new Guna2Button();
            this.btnPrev = new Guna2Button();
            this.pbBarcode = new PictureBox();
            this.pbImagePreview = new PictureBox();
            this.lblImageIndex = new Label();

            this.SuspendLayout();

            // txtName
            this.txtName.PlaceholderText = "Item Name";
            this.txtName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Size = new System.Drawing.Size(250, 36);

            // txtDescription
            this.txtDescription.PlaceholderText = "Description (optional)";
            this.txtDescription.Location = new System.Drawing.Point(20, 70);
            this.txtDescription.Size = new System.Drawing.Size(250, 36);

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(20, 120);
            this.cmbCategory.Size = new System.Drawing.Size(250, 36);

            // txtPrice
            this.txtPrice.PlaceholderText = "Price";
            this.txtPrice.Location = new System.Drawing.Point(20, 170);
            this.txtPrice.Size = new System.Drawing.Size(250, 36);

            // numQuantity
            this.numQuantity.Location = new System.Drawing.Point(20, 220);
            this.numQuantity.Size = new System.Drawing.Size(250, 36);
            this.numQuantity.Minimum = 0;
            this.numQuantity.Maximum = 999999;

            // cmbBarcodeType
            this.cmbBarcodeType.Location = new System.Drawing.Point(20, 270);
            this.cmbBarcodeType.Size = new System.Drawing.Size(250, 36);

            // pbBarcode
            this.pbBarcode.Location = new System.Drawing.Point(20, 320);
            this.pbBarcode.Size = new System.Drawing.Size(250, 80);
            this.pbBarcode.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbBarcode.BorderStyle = BorderStyle.FixedSingle;

            // btnDownloadBarcode
            this.btnDownloadBarcode.Text = "Download Barcode";
            this.btnDownloadBarcode.Location = new System.Drawing.Point(20, 410);
            this.btnDownloadBarcode.Size = new System.Drawing.Size(250, 36);
            this.btnDownloadBarcode.Click += new System.EventHandler(this.BtnDownloadBarcode_Click);
            this.btnDownloadBarcode.Visible = false;

            // pbImagePreview
            this.pbImagePreview.Location = new System.Drawing.Point(300, 20);
            this.pbImagePreview.Size = new System.Drawing.Size(300, 180);
            this.pbImagePreview.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbImagePreview.BorderStyle = BorderStyle.FixedSingle;

            // lblImageIndex
            this.lblImageIndex.Location = new System.Drawing.Point(300, 205);
            this.lblImageIndex.Size = new System.Drawing.Size(100, 20);

            // btnPrev
            this.btnPrev.Text = "<";
            this.btnPrev.Location = new System.Drawing.Point(410, 205);
            this.btnPrev.Size = new System.Drawing.Size(45, 30);
            this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);

            // btnNext
            this.btnNext.Text = ">";
            this.btnNext.Location = new System.Drawing.Point(460, 205);
            this.btnNext.Size = new System.Drawing.Size(45, 30);
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);

            // btnAddImage
            this.btnAddImage.Text = "Add Images";
            this.btnAddImage.Location = new System.Drawing.Point(300, 250);
            this.btnAddImage.Size = new System.Drawing.Size(140, 36);
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);

            // btnDeleteImage
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.Location = new System.Drawing.Point(460, 250);
            this.btnDeleteImage.Size = new System.Drawing.Size(140, 36);
            this.btnDeleteImage.Click += new System.EventHandler(this.BtnDeleteImage_Click);

            // btnSave
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(300, 310);
            this.btnSave.Size = new System.Drawing.Size(300, 45);
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // ItemFormControl
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
            this.Size = new System.Drawing.Size(630, 480);
            this.BackColor = System.Drawing.Color.White;

            this.ResumeLayout(false);
        }
    }
}