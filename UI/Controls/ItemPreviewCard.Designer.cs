using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Controls
{
    partial class ItemPreviewCard
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblName;
        private Guna2HtmlLabel lblDescription;
        private Guna2HtmlLabel lblQuantity;
        private Guna2HtmlLabel lblPrice;
        private Guna2PictureBox pictureBox;
        private Guna2Button btnDeleteItem;
        private Guna2Button btnAddStock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new Guna2HtmlLabel();
            this.lblDescription = new Guna2HtmlLabel();
            this.lblQuantity = new Guna2HtmlLabel();
            this.pictureBox = new Guna2PictureBox();
            this.lblPrice = new Guna2HtmlLabel();
            this.btnDeleteItem = new Guna2Button();
            this.btnAddStock = new Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            //
            // lblName
            //
            this.lblName.AutoSize = false;
            this.lblName.BackColor = Color.Transparent;
            this.lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblName.Location = new Point(10, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(200, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Item Name";
            //
            // lblDescription
            //
            this.lblDescription.BackColor = Color.Transparent;
            this.lblDescription.Font = new Font("Segoe UI", 9F);
            this.lblDescription.Location = new Point(10, 90);
            this.lblDescription.MaximumSize = new Size(470, 0); // Initial max width, adjusted in code
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(93, 27);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            //
            // lblQuantity
            //
            this.lblQuantity.AutoSize = false;
            this.lblQuantity.BackColor = Color.Transparent;
            this.lblQuantity.Font = new Font("Segoe UI", 9F);
            this.lblQuantity.Location = new Point(10, 40);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new Size(150, 27);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "In Stock: 0";
            this.lblQuantity.TextAlignment = ContentAlignment.MiddleLeft;
            //
            // pictureBox
            //
            this.pictureBox.BorderRadius = 10;
            this.pictureBox.ImageRotate = 0F;
            this.pictureBox.Location = new Point(this.ClientSize.Width - 180, 40); // Moved more to the left
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(120, 100);
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            //
            // lblPrice
            //
            this.lblPrice.AutoSize = false;
            this.lblPrice.BackColor = Color.Transparent;
            this.lblPrice.Font = new Font("Segoe UI", 9F);
            this.lblPrice.Location = new Point(this.ClientSize.Width - 160, 40);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(130, 27);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price: ₹ ";
            this.lblPrice.TextAlignment = ContentAlignment.MiddleLeft;
            //
            // btnDeleteItem
            //
            this.btnDeleteItem.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnDeleteItem.FillColor = Color.Firebrick;
            this.btnDeleteItem.Font = new Font("Segoe UI", 9F);
            this.btnDeleteItem.ForeColor = Color.White;
            this.btnDeleteItem.Location = new Point(this.ClientSize.Width - 30, 10);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new Size(30, 30);
            this.btnDeleteItem.TabIndex = 6;
            this.btnDeleteItem.Text = "🗑";
            this.btnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            //
            // btnAddStock
            //
            this.btnAddStock.FillColor = Color.ForestGreen;
            this.btnAddStock.Font = new Font("Segoe UI", 8F);
            this.btnAddStock.ForeColor = Color.White;
            this.btnAddStock.Location = new Point(150, 10);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new Size(80, 30);
            this.btnAddStock.TabIndex = 7;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.Click += new System.EventHandler(this.BtnAddStock_Click);
            //
            // ItemPreviewCard
            //
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.pictureBox);
            this.Cursor = Cursors.Hand;
            this.Margin = new Padding(5);
            this.Name = "ItemPreviewCard";
            this.Padding = new Padding(10);
            this.Size = new Size(608, 178); // Initial size (will be adjusted)
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}