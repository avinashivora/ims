using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Forms
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.panelItems = new Guna.UI2.WinForms.Guna2Panel();
            this.flpItemsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblItemsTitle = new System.Windows.Forms.Label();
            this.panelScanner = new Guna.UI2.WinForms.Guna2Panel();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.panelBillActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.btnClearBill = new Guna.UI2.WinForms.Guna2Button();
            this.panelBillSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGrandTotalValue = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTaxAmountValue = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblDiscountAmountValue = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblSubTotalValue = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblBillSummaryTitle = new System.Windows.Forms.Label();
            this.panelDiscount = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDiscountSign = new System.Windows.Forms.Label();
            this.txtDiscountValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.rbDiscountPercentage = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbDiscountFlat = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblDiscountTitle = new System.Windows.Forms.Label();
            this.panelTax = new Guna.UI2.WinForms.Guna2Panel();
            this.panelBillInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblOrganizationInfo = new System.Windows.Forms.Label();
            this.lblBillingTitle = new System.Windows.Forms.Label();
            this.panelLoading = new Guna.UI2.WinForms.Guna2Panel();
            this.progressLoading = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.lblLoadingText = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelItems.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBillActions.SuspendLayout();
            this.panelBillSummary.SuspendLayout();
            this.panelDiscount.SuspendLayout();
            this.panelBillInfo.SuspendLayout();
            this.panelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1440, 720);
            this.panelMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BorderColor = System.Drawing.Color.LightGray;
            this.panelLeft.BorderThickness = 1;
            this.panelLeft.Controls.Add(this.panelItems);
            this.panelLeft.Controls.Add(this.panelScanner);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(840, 720);
            this.panelLeft.TabIndex = 1;
            // 
            // panelItems
            // 
            this.panelItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItems.Controls.Add(this.flpItemsPanel);
            this.panelItems.Controls.Add(this.lblItemsTitle);
            this.panelItems.Location = new System.Drawing.Point(11, 240);
            this.panelItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelItems.Name = "panelItems";
            this.panelItems.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelItems.Size = new System.Drawing.Size(818, 470);
            this.panelItems.TabIndex = 2;
            // 
            // flpItemsPanel
            // 
            this.flpItemsPanel.AutoScroll = true;
            this.flpItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpItemsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpItemsPanel.Location = new System.Drawing.Point(9, 40);
            this.flpItemsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpItemsPanel.Name = "flpItemsPanel";
            this.flpItemsPanel.Padding = new System.Windows.Forms.Padding(4);
            this.flpItemsPanel.Size = new System.Drawing.Size(800, 422);
            this.flpItemsPanel.TabIndex = 3;
            this.flpItemsPanel.WrapContents = false;
            // 
            // lblItemsTitle
            // 
            this.lblItemsTitle.AutoSize = true;
            this.lblItemsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblItemsTitle.Location = new System.Drawing.Point(9, 8);
            this.lblItemsTitle.Name = "lblItemsTitle";
            this.lblItemsTitle.Size = new System.Drawing.Size(120, 32);
            this.lblItemsTitle.TabIndex = 2;
            this.lblItemsTitle.Text = "Bill Items";
            // 
            // panelScanner
            // 
            this.panelScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScanner.BorderColor = System.Drawing.Color.LightGray;
            this.panelScanner.BorderThickness = 1;
            this.panelScanner.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelScanner.Location = new System.Drawing.Point(11, 10);
            this.panelScanner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelScanner.Name = "panelScanner";
            this.panelScanner.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelScanner.Size = new System.Drawing.Size(818, 226);
            this.panelScanner.TabIndex = 3;
            // 
            // panelRight
            // 
            this.panelRight.BorderColor = System.Drawing.Color.LightGray;
            this.panelRight.BorderThickness = 1;
            this.panelRight.Controls.Add(this.panelBillActions);
            this.panelRight.Controls.Add(this.panelBillSummary);
            this.panelRight.Controls.Add(this.panelDiscount);
            this.panelRight.Controls.Add(this.panelTax);
            this.panelRight.Controls.Add(this.panelBillInfo);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(840, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(600, 720);
            this.panelRight.TabIndex = 4;
            // 
            // panelBillActions
            // 
            this.panelBillActions.Controls.Add(this.btnCheckout);
            this.panelBillActions.Controls.Add(this.btnClearBill);
            this.panelBillActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBillActions.Location = new System.Drawing.Point(0, 640);
            this.panelBillActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBillActions.Name = "panelBillActions";
            this.panelBillActions.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelBillActions.Size = new System.Drawing.Size(600, 80);
            this.panelBillActions.TabIndex = 5;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.BorderRadius = 3;
            this.btnCheckout.Enabled = false;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(338, 14);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(178, 48);
            this.btnCheckout.TabIndex = 8;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);
            // 
            // btnClearBill
            // 
            this.btnClearBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearBill.BorderRadius = 3;
            this.btnClearBill.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClearBill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClearBill.ForeColor = System.Drawing.Color.White;
            this.btnClearBill.Location = new System.Drawing.Point(114, 14);
            this.btnClearBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearBill.Name = "btnClearBill";
            this.btnClearBill.Size = new System.Drawing.Size(135, 48);
            this.btnClearBill.TabIndex = 6;
            this.btnClearBill.Text = "Clear Bill";
            this.btnClearBill.Click += new System.EventHandler(this.BtnClearBill_Click);
            // 
            // panelBillSummary
            // 
            this.panelBillSummary.BorderColor = System.Drawing.Color.LightGray;
            this.panelBillSummary.BorderThickness = 1;
            this.panelBillSummary.Controls.Add(this.lblGrandTotalValue);
            this.panelBillSummary.Controls.Add(this.lblGrandTotal);
            this.panelBillSummary.Controls.Add(this.lblTaxAmountValue);
            this.panelBillSummary.Controls.Add(this.lblTaxAmount);
            this.panelBillSummary.Controls.Add(this.lblDiscountAmountValue);
            this.panelBillSummary.Controls.Add(this.lblDiscountAmount);
            this.panelBillSummary.Controls.Add(this.lblSubTotalValue);
            this.panelBillSummary.Controls.Add(this.lblSubTotal);
            this.panelBillSummary.Controls.Add(this.lblBillSummaryTitle);
            this.panelBillSummary.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelBillSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBillSummary.Location = new System.Drawing.Point(0, 440);
            this.panelBillSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBillSummary.Name = "panelBillSummary";
            this.panelBillSummary.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelBillSummary.Size = new System.Drawing.Size(600, 280);
            this.panelBillSummary.TabIndex = 8;
            // 
            // lblGrandTotalValue
            // 
            this.lblGrandTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotalValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalValue.Location = new System.Drawing.Point(393, 156);
            this.lblGrandTotalValue.Name = "lblGrandTotalValue";
            this.lblGrandTotalValue.Size = new System.Drawing.Size(189, 45);
            this.lblGrandTotalValue.TabIndex = 9;
            this.lblGrandTotalValue.Text = "₹0.00";
            this.lblGrandTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(18, 156);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(177, 38);
            this.lblGrandTotal.TabIndex = 10;
            this.lblGrandTotal.Text = "Grand Total:";
            // 
            // lblTaxAmountValue
            // 
            this.lblTaxAmountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaxAmountValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxAmountValue.Location = new System.Drawing.Point(393, 120);
            this.lblTaxAmountValue.Name = "lblTaxAmountValue";
            this.lblTaxAmountValue.Size = new System.Drawing.Size(189, 30);
            this.lblTaxAmountValue.TabIndex = 11;
            this.lblTaxAmountValue.Text = "₹0.00";
            this.lblTaxAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxAmount.Location = new System.Drawing.Point(18, 120);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(119, 28);
            this.lblTaxAmount.TabIndex = 12;
            this.lblTaxAmount.Text = "Tax Amount:";
            // 
            // lblDiscountAmountValue
            // 
            this.lblDiscountAmountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountAmountValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountAmountValue.Location = new System.Drawing.Point(393, 88);
            this.lblDiscountAmountValue.Name = "lblDiscountAmountValue";
            this.lblDiscountAmountValue.Size = new System.Drawing.Size(189, 30);
            this.lblDiscountAmountValue.TabIndex = 13;
            this.lblDiscountAmountValue.Text = "₹0.00";
            this.lblDiscountAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountAmount.Location = new System.Drawing.Point(18, 88);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(93, 28);
            this.lblDiscountAmount.TabIndex = 14;
            this.lblDiscountAmount.Text = "Discount:";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotalValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTotalValue.Location = new System.Drawing.Point(393, 56);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(189, 30);
            this.lblSubTotalValue.TabIndex = 15;
            this.lblSubTotalValue.Text = "₹0.00";
            this.lblSubTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTotal.Location = new System.Drawing.Point(18, 56);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(97, 28);
            this.lblSubTotal.TabIndex = 16;
            this.lblSubTotal.Text = "Sub Total:";
            // 
            // lblBillSummaryTitle
            // 
            this.lblBillSummaryTitle.AutoSize = true;
            this.lblBillSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBillSummaryTitle.Location = new System.Drawing.Point(18, 16);
            this.lblBillSummaryTitle.Name = "lblBillSummaryTitle";
            this.lblBillSummaryTitle.Size = new System.Drawing.Size(166, 32);
            this.lblBillSummaryTitle.TabIndex = 17;
            this.lblBillSummaryTitle.Text = "Bill Summary";
            // 
            // panelDiscount
            // 
            this.panelDiscount.BorderColor = System.Drawing.Color.LightGray;
            this.panelDiscount.BorderThickness = 1;
            this.panelDiscount.Controls.Add(this.lblDiscountSign);
            this.panelDiscount.Controls.Add(this.txtDiscountValue);
            this.panelDiscount.Controls.Add(this.rbDiscountPercentage);
            this.panelDiscount.Controls.Add(this.rbDiscountFlat);
            this.panelDiscount.Controls.Add(this.lblDiscountTitle);
            this.panelDiscount.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelDiscount.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDiscount.Location = new System.Drawing.Point(0, 320);
            this.panelDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDiscount.Name = "panelDiscount";
            this.panelDiscount.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelDiscount.Size = new System.Drawing.Size(600, 120);
            this.panelDiscount.TabIndex = 18;
            // 
            // lblDiscountSign
            // 
            this.lblDiscountSign.AutoSize = true;
            this.lblDiscountSign.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountSign.Location = new System.Drawing.Point(407, 60);
            this.lblDiscountSign.Name = "lblDiscountSign";
            this.lblDiscountSign.Size = new System.Drawing.Size(23, 28);
            this.lblDiscountSign.TabIndex = 19;
            this.lblDiscountSign.Text = "₹";
            // 
            // txtDiscountValue
            // 
            this.txtDiscountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountValue.BorderRadius = 3;
            this.txtDiscountValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscountValue.DefaultText = "0";
            this.txtDiscountValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiscountValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiscountValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscountValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscountValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscountValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiscountValue.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscountValue.Location = new System.Drawing.Point(437, 52);
            this.txtDiscountValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiscountValue.Name = "txtDiscountValue";
            this.txtDiscountValue.PlaceholderText = "";
            this.txtDiscountValue.SelectedText = "";
            this.txtDiscountValue.Size = new System.Drawing.Size(150, 36);
            this.txtDiscountValue.TabIndex = 20;
            // 
            // rbDiscountPercentage
            // 
            this.rbDiscountPercentage.AutoSize = true;
            this.rbDiscountPercentage.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDiscountPercentage.CheckedState.BorderThickness = 0;
            this.rbDiscountPercentage.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDiscountPercentage.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDiscountPercentage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbDiscountPercentage.Location = new System.Drawing.Point(211, 56);
            this.rbDiscountPercentage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDiscountPercentage.Name = "rbDiscountPercentage";
            this.rbDiscountPercentage.Size = new System.Drawing.Size(166, 32);
            this.rbDiscountPercentage.TabIndex = 21;
            this.rbDiscountPercentage.Text = "Percentage (%)";
            this.rbDiscountPercentage.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDiscountPercentage.UncheckedState.BorderThickness = 2;
            this.rbDiscountPercentage.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDiscountPercentage.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbDiscountFlat
            // 
            this.rbDiscountFlat.AutoSize = true;
            this.rbDiscountFlat.Checked = true;
            this.rbDiscountFlat.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDiscountFlat.CheckedState.BorderThickness = 0;
            this.rbDiscountFlat.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDiscountFlat.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDiscountFlat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbDiscountFlat.Location = new System.Drawing.Point(39, 56);
            this.rbDiscountFlat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDiscountFlat.Name = "rbDiscountFlat";
            this.rbDiscountFlat.Size = new System.Drawing.Size(145, 32);
            this.rbDiscountFlat.TabIndex = 22;
            this.rbDiscountFlat.TabStop = true;
            this.rbDiscountFlat.Text = "Flat Amount";
            this.rbDiscountFlat.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDiscountFlat.UncheckedState.BorderThickness = 2;
            this.rbDiscountFlat.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDiscountFlat.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // lblDiscountTitle
            // 
            this.lblDiscountTitle.AutoSize = true;
            this.lblDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiscountTitle.Location = new System.Drawing.Point(18, 16);
            this.lblDiscountTitle.Name = "lblDiscountTitle";
            this.lblDiscountTitle.Size = new System.Drawing.Size(116, 32);
            this.lblDiscountTitle.TabIndex = 23;
            this.lblDiscountTitle.Text = "Discount";
            // 
            // panelTax
            // 
            this.panelTax.BorderColor = System.Drawing.Color.LightGray;
            this.panelTax.BorderThickness = 1;
            this.panelTax.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelTax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTax.Location = new System.Drawing.Point(0, 200);
            this.panelTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTax.Name = "panelTax";
            this.panelTax.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelTax.Size = new System.Drawing.Size(600, 120);
            this.panelTax.TabIndex = 24;
            // 
            // panelBillInfo
            // 
            this.panelBillInfo.BorderColor = System.Drawing.Color.LightGray;
            this.panelBillInfo.BorderThickness = 1;
            this.panelBillInfo.Controls.Add(this.lblItemCount);
            this.panelBillInfo.Controls.Add(this.lblUserInfo);
            this.panelBillInfo.Controls.Add(this.lblOrganizationInfo);
            this.panelBillInfo.Controls.Add(this.lblBillingTitle);
            this.panelBillInfo.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelBillInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBillInfo.Location = new System.Drawing.Point(0, 0);
            this.panelBillInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBillInfo.Name = "panelBillInfo";
            this.panelBillInfo.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelBillInfo.Size = new System.Drawing.Size(600, 200);
            this.panelBillInfo.TabIndex = 26;
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblItemCount.Location = new System.Drawing.Point(18, 144);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(148, 28);
            this.lblItemCount.TabIndex = 27;
            this.lblItemCount.Text = "Items: 0 (Qty: 0)";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInfo.Location = new System.Drawing.Point(18, 112);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(134, 28);
            this.lblUserInfo.TabIndex = 28;
            this.lblUserInfo.Text = "Billed By: User";
            // 
            // lblOrganizationInfo
            // 
            this.lblOrganizationInfo.AutoSize = true;
            this.lblOrganizationInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrganizationInfo.Location = new System.Drawing.Point(18, 80);
            this.lblOrganizationInfo.Name = "lblOrganizationInfo";
            this.lblOrganizationInfo.Size = new System.Drawing.Size(233, 28);
            this.lblOrganizationInfo.TabIndex = 29;
            this.lblOrganizationInfo.Text = "Organization ID: ORG123";
            // 
            // lblBillingTitle
            // 
            this.lblBillingTitle.AutoSize = true;
            this.lblBillingTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBillingTitle.Location = new System.Drawing.Point(18, 16);
            this.lblBillingTitle.Name = "lblBillingTitle";
            this.lblBillingTitle.Size = new System.Drawing.Size(231, 45);
            this.lblBillingTitle.TabIndex = 30;
            this.lblBillingTitle.Text = "Billing System";
            // 
            // panelLoading
            // 
            this.panelLoading.BackColor = System.Drawing.Color.Transparent;
            this.panelLoading.Controls.Add(this.progressLoading);
            this.panelLoading.Controls.Add(this.lblLoadingText);
            this.panelLoading.CustomBorderColor = System.Drawing.Color.Transparent;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(1440, 720);
            this.panelLoading.TabIndex = 31;
            this.panelLoading.UseTransparentBackground = true;
            this.panelLoading.Visible = false;
            // 
            // progressLoading
            // 
            this.progressLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLoading.AutoStart = true;
            this.progressLoading.CircleSize = 1F;
            this.progressLoading.Location = new System.Drawing.Point(675, 320);
            this.progressLoading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.Size = new System.Drawing.Size(90, 80);
            this.progressLoading.TabIndex = 32;
            // 
            // lblLoadingText
            // 
            this.lblLoadingText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoadingText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLoadingText.Location = new System.Drawing.Point(540, 400);
            this.lblLoadingText.Name = "lblLoadingText";
            this.lblLoadingText.Size = new System.Drawing.Size(360, 40);
            this.lblLoadingText.TabIndex = 33;
            this.lblLoadingText.Text = "Processing, please wait...";
            this.lblLoadingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 720);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLoading);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1082, 651);
            this.Name = "BillingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelItems.ResumeLayout(false);
            this.panelItems.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelBillActions.ResumeLayout(false);
            this.panelBillSummary.ResumeLayout(false);
            this.panelBillSummary.PerformLayout();
            this.panelDiscount.ResumeLayout(false);
            this.panelDiscount.PerformLayout();
            this.panelBillInfo.ResumeLayout(false);
            this.panelBillInfo.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Guna2Panel panelMain;
        private Guna2Panel panelLeft;
        private Guna2Panel panelItems;
        private FlowLayoutPanel flpItemsPanel;
        private Label lblItemsTitle;
        private Guna2Panel panelScanner;
        private Guna2Panel panelRight;
        private Guna2Panel panelBillActions;
        private Guna2Button btnCheckout;
        private Guna2Button btnClearBill;
        private Guna2Panel panelBillSummary;
        private Label lblGrandTotalValue;
        private Label lblGrandTotal;
        private Label lblTaxAmountValue;
        private Label lblTaxAmount;
        private Label lblDiscountAmountValue;
        private Label lblDiscountAmount;
        private Label lblSubTotalValue;
        private Label lblSubTotal;
        private Label lblBillSummaryTitle;
        private Guna2Panel panelDiscount;
        private Label lblDiscountSign;
        private Guna2TextBox txtDiscountValue;
        private Guna2RadioButton rbDiscountPercentage;
        private Guna2RadioButton rbDiscountFlat;
        private Label lblDiscountTitle;
        private Guna2Panel panelTax;
        private Guna2Panel panelBillInfo;
        private Label lblItemCount;
        private Label lblUserInfo;
        private Label lblOrganizationInfo;
        private Label lblBillingTitle;
        private Guna2Panel panelLoading;
        private Guna2ProgressIndicator progressLoading;
        private Label lblLoadingText;
    }
}
