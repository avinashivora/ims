﻿using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace ims.UI.Forms
{
    partial class AddStockForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2NumericUpDown numQuantity;
        private Guna2Button btnSave;
        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblItemName;
        private Guna2HtmlLabel lblCurrentStock;
        private Guna2HtmlLabel lblQuantityToAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.numQuantity = new Guna2NumericUpDown();
            this.btnSave = new Guna2Button();
            this.lblTitle = new Guna2HtmlLabel();
            this.lblItemName = new Guna2HtmlLabel();
            this.lblCurrentStock = new Guna2HtmlLabel();
            this.lblQuantityToAdd = new Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DodgerBlue;
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(154, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Stock";

            // lblItemName
            this.lblItemName.BackColor = Color.Transparent;
            this.lblItemName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblItemName.Location = new Point(30, 60);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new Size(154, 22);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Item: ";

            // lblCurrentStock
            this.lblCurrentStock.BackColor = Color.Transparent;
            this.lblCurrentStock.Font = new Font("Segoe UI", 10F);
            this.lblCurrentStock.Location = new Point(30, 90);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new Size(154, 22);
            this.lblCurrentStock.TabIndex = 2;
            this.lblCurrentStock.Text = "Current Stock: ";

            // lblQuantityToAdd
            this.lblQuantityToAdd.BackColor = Color.Transparent;
            this.lblQuantityToAdd.Font = new Font("Segoe UI", 10F);
            this.lblQuantityToAdd.Location = new Point(30, 130);
            this.lblQuantityToAdd.Name = "lblQuantityToAdd";
            this.lblQuantityToAdd.Size = new Size(154, 22);
            this.lblQuantityToAdd.TabIndex = 3;
            this.lblQuantityToAdd.Text = "Quantity to Add:";

            // numQuantity
            this.numQuantity.BackColor = Color.Transparent;
            this.numQuantity.BorderRadius = 6;
            this.numQuantity.Cursor = Cursors.IBeam;
            this.numQuantity.Font = new Font("Segoe UI", 10F);
            this.numQuantity.Location = new Point(30, 160);
            this.numQuantity.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new Size(300, 40);
            this.numQuantity.TabIndex = 4;
            this.numQuantity.UpDownButtonFillColor = Color.DodgerBlue;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnSave
            this.btnSave.BorderRadius = 6;
            this.btnSave.DisabledState.BorderColor = Color.DarkGray;
            this.btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            this.btnSave.FillColor = Color.DodgerBlue;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(30, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(300, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Add Stock";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // AddStockForm
            this.AutoScaleDimensions = new SizeF(8F, 18F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(364, 290);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantityToAdd);
            this.Controls.Add(this.lblCurrentStock);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblTitle);
            this.Font = new Font("Segoe UI", 9.75F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStockForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Stock";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}