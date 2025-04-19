using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Controls
{
    partial class BillItemControl
    {
        private Label lblItemName;
        private Label lblBarcode;
        private Label lblUnitPrice;
        private Guna2NumericUpDown nudQuantity;
        private Label lblTotalPrice;
        private Guna2Button btnRemove;

        private void InitializeComponent()
        {
            this.lblItemName = new Label();
            this.lblBarcode = new Label();
            this.lblUnitPrice = new Label();
            this.nudQuantity = new Guna2NumericUpDown();
            this.lblTotalPrice = new Label();
            this.btnRemove = new Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();

            // lblItemName
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(10, 10);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(200, 15);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Item Name";

            // lblBarcode
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBarcode.Location = new System.Drawing.Point(10, 30);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(100, 13);
            this.lblBarcode.TabIndex = 1;
            this.lblBarcode.Text = "Barcode";

            // lblUnitPrice
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnitPrice.Location = new System.Drawing.Point(220, 10);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(60, 15);
            this.lblUnitPrice.TabIndex = 2;
            this.lblUnitPrice.Text = "₹0.00";

            // nudQuantity
            this.nudQuantity.BackColor = System.Drawing.Color.Transparent;
            this.nudQuantity.Cursor = Cursors.IBeam;
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantity.Location = new System.Drawing.Point(290, 10);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(60, 30);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.UpDownButtonFillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Minimum = 1;
            this.nudQuantity.Maximum = 1000;
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);

            // lblTotalPrice
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.Location = new System.Drawing.Point(360, 10);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(80, 15);
            this.lblTotalPrice.TabIndex = 4;
            this.lblTotalPrice.Text = "₹0.00";

            // btnRemove
            this.btnRemove.BorderRadius = 3;
            this.btnRemove.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(450, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 30);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "X";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // BillItemControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnRemove);
            this.Name = "BillItemControl";
            this.Size = new System.Drawing.Size(490, 50);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
