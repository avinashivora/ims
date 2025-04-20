using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace ims.UI.Controls
{
    partial class BarcodeInputPanel
    {
        private Label lblTitle;
        private Guna2TextBox txtBarcode;
        private Guna2Button btnAddItem;
        private Guna2Button btnUploadBarcode;
        private Label lblScannerInfo;
        private Label lblStatus;
        private OpenFileDialog openFileDialog;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtBarcode = new Guna2TextBox();
            this.btnAddItem = new Guna2Button();
            this.btnUploadBarcode = new Guna2Button();
            this.lblScannerInfo = new Label();
            this.lblStatus = new Label();
            this.openFileDialog = new OpenFileDialog();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(150, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Item by Barcode";

            // txtBarcode
            this.txtBarcode.BorderRadius = 3;
            this.txtBarcode.Cursor = Cursors.IBeam;
            this.txtBarcode.DefaultText = "";
            this.txtBarcode.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            this.txtBarcode.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            this.txtBarcode.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            this.txtBarcode.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            this.txtBarcode.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            this.txtBarcode.Font = new Font("Segoe UI", 9F);
            this.txtBarcode.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            this.txtBarcode.Location = new Point(10, 40);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PasswordChar = '\0';
            this.txtBarcode.PlaceholderText = "Enter barcode or scan item";
            this.txtBarcode.SelectedText = "";
            this.txtBarcode.Size = new Size(280, 36);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.KeyDown += new KeyEventHandler(this.TxtBarcode_KeyDown);

            // btnAddItem
            this.btnAddItem.BorderRadius = 3;
            this.btnAddItem.FillColor = Color.FromArgb(94, 148, 255);
            this.btnAddItem.Font = new Font("Segoe UI", 9F);
            this.btnAddItem.ForeColor = Color.White;
            this.btnAddItem.Location = new Point(300, 40);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new Size(100, 36);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);

            // btnUploadBarcode
            this.btnUploadBarcode.BorderRadius = 3;
            this.btnUploadBarcode.FillColor = Color.FromArgb(94, 148, 255);
            this.btnUploadBarcode.Font = new Font("Segoe UI", 9F);
            this.btnUploadBarcode.ForeColor = Color.White;
            this.btnUploadBarcode.Location = new Point(410, 40);
            this.btnUploadBarcode.Name = "btnUploadBarcode";
            this.btnUploadBarcode.Size = new Size(130, 36);
            this.btnUploadBarcode.TabIndex = 3;
            this.btnUploadBarcode.Text = "Upload Barcode";
            this.btnUploadBarcode.Click += new System.EventHandler(this.BtnUploadBarcode_Click);

            // lblScannerInfo
            this.lblScannerInfo.AutoSize = true;
            this.lblScannerInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblScannerInfo.ForeColor = Color.Gray;
            this.lblScannerInfo.Location = new Point(10, 85);
            this.lblScannerInfo.Name = "lblScannerInfo";
            this.lblScannerInfo.Size = new Size(400, 13);
            this.lblScannerInfo.TabIndex = 4;
            this.lblScannerInfo.Text = "You can use a barcode scanner directly, enter the barcode manually, or upload a barcode image";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = Color.Gray;
            this.lblStatus.Location = new Point(10, 105);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(0, 15);
            this.lblStatus.TabIndex = 5;

            // BarcodeInputPanel
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnUploadBarcode);
            this.Controls.Add(this.lblScannerInfo);
            this.Controls.Add(this.lblStatus);
            this.Name = "BarcodeInputPanel";
            this.Size = new Size(550, 130);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
