using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ims.Models;
using ims.Services;
using ims.UI.Controls;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class BillingForm : Form
    {
        private readonly BillingService _billingService;
        private readonly InventoryService _inventoryService;
        private readonly BarcodeService _barcodeService;
        private readonly PdfGenerator _pdfGenerator;
        private readonly string _organizationId;
        private readonly string _userName;

        private readonly List<BillItem> _billItems;
        private decimal _taxRate = 0;
        private decimal _discountValue = 0;
        private DiscountType _discountType = DiscountType.Flat;

        private readonly String pdfPath = CacheManager.BillSavePath;

        public BillingForm()
        {
            InitializeComponent();

            _organizationId = CacheManager.CurrentOrganizationId;
            _userName = CacheManager.CurrentUserId;

            // Initialize services
            _inventoryService = new InventoryService();
            _billingService = new BillingService(_inventoryService);
            _barcodeService = new BarcodeService();
            _pdfGenerator = new PdfGenerator();

            // Initialize bill items list
            _billItems = [];

            InitializeCustomControls();

            // Set up UI components
            InitializeUIComponents();
            UpdateBillSummary();
        }

        private void InitializeCustomControls()
        {
            // Create and add BarcodeInputPanel
            var barcodeInputPanel = new BarcodeInputPanel(_barcodeService)
            {
                Dock = DockStyle.Fill,
                Name = "barcodeInputPanel",
                TabIndex = 0
            };
            barcodeInputPanel.BarcodeDetected += BarcodeInputPanel_BarcodeDetected;
            this.panelScanner.Controls.Add(barcodeInputPanel);

            // Create and add TaxSelector
            var taxSelector = new TaxSelector
            {
                Dock = DockStyle.Fill,
                Name = "taxSelector",
                TabIndex = 1
            };
            taxSelector.TaxSelected += TaxSelector_TaxSelected;
            this.panelTax.Controls.Add(taxSelector);
        }

        private void InitializeUIComponents()
        {
            // Set discount type radio buttons event
            rbDiscountFlat.CheckedChanged += DiscountType_CheckedChanged;
            rbDiscountPercentage.CheckedChanged += DiscountType_CheckedChanged;

            // Set discount value changed event
            txtDiscountValue.TextChanged += TxtDiscountValue_TextChanged;

            // Set organization and user info
            lblOrganizationInfo.Text = $"Organization ID: {_organizationId}";
            lblUserInfo.Text = $"Billed By: {_userName}";
        }

        private async void BarcodeInputPanel_BarcodeDetected(object sender, BarcodeInputPanel.BarcodeReadEventArgs e)
        {
            if (e.Success)
            {
                await ProcessBarcodeAsync(e.Barcode);
            }
            else
            {
                ShowError(e.ErrorMessage);
            }
        }

        private async Task ProcessBarcodeAsync(string barcode)
        {
            try
            {
                // Show loading indicator
                ShowLoading(true);

                // Get item from inventory by barcode
                var item = await _inventoryService.GetItemByBarcodeAsync(barcode);

                if (item == null)
                {
                    ShowError($"Item with barcode {barcode} not found in inventory.");
                    return;
                }

                // Check if item already exists in bill
                var existingItem = _billItems.Find(i => i.Barcode == barcode);
                if (existingItem != null)
                {
                    // Increment quantity instead of adding new item
                    existingItem.Quantity += 1;
                    existingItem.TotalPrice = existingItem.UnitPrice * existingItem.Quantity;

                    // Update UI
                    RefreshItemsPanel();
                }
                else
                {
                    // Create new bill item
                    var billItem = new BillItem
                    {
                        ItemId = item.Id,
                        Barcode = item.Barcode.BarcodeString,
                        ItemName = item.Name,
                        Quantity = 1,
                        UnitPrice = item.Price,
                        TotalPrice = item.Price
                    };

                    // Add to list
                    _billItems.Add(billItem);

                    // Update UI
                    AddItemToPanel(billItem);
                }

                // Update bill summary
                UpdateBillSummary();
            }
            catch (Exception ex)
            {
                ShowError($"Error processing barcode: {ex.Message}");
            }
            finally
            {
                // Hide loading indicator
                ShowLoading(false);
            }
        }

        private void AddItemToPanel(BillItem billItem)
        {
            var itemControl = new BillItemControl(billItem);
            itemControl.QuantityChanged += ItemControl_QuantityChanged;
            itemControl.RemoveItem += ItemControl_RemoveItem;

            // Add to flow layout panel
            flpItemsPanel.Controls.Add(itemControl);
        }

        private void RefreshItemsPanel()
        {
            // Clear panel
            flpItemsPanel.Controls.Clear();

            // Add all items
            foreach (var item in _billItems)
            {
                AddItemToPanel(item);
            }
        }

        private void ItemControl_QuantityChanged(object sender, BillItemControl.BillItemEventArgs e)
        {
            // Update bill summary
            UpdateBillSummary();
        }

        private void ItemControl_RemoveItem(object sender, BillItemControl.BillItemEventArgs e)
        {
            // Remove item from list
            _billItems.Remove(e.BillItem);

            // Remove control from panel
            flpItemsPanel.Controls.Remove((Control)sender);

            // Update bill summary
            UpdateBillSummary();
        }

        private void TaxSelector_TaxSelected(object sender, TaxSelector.TaxSelectedEventArgs e)
        {
            _taxRate = e.TaxRate;
            UpdateBillSummary();
        }

        private void DiscountType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDiscountFlat.Checked)
            {
                _discountType = DiscountType.Flat;
                lblDiscountSign.Text = "₹";
            }
            else
            {
                _discountType = DiscountType.Percentage;
                lblDiscountSign.Text = "%";
            }

            UpdateBillSummary();
        }

        private void TxtDiscountValue_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDiscountValue.Text, out decimal value))
            {
                _discountValue = value;

                // Validate percentage discount doesn't exceed 100%
                if (_discountType == DiscountType.Percentage && _discountValue > 100)
                {
                    _discountValue = 100;
                    txtDiscountValue.Text = "100";
                }

                UpdateBillSummary();
            }
            else
            {
                _discountValue = 0;
                UpdateBillSummary();
            }
        }

        private void UpdateBillSummary()
        {
            decimal subtotal = 0;
            foreach (var item in _billItems)
            {
                subtotal += item.TotalPrice;
            }

            // Calculate discount
            decimal discountAmount;
            if (_discountType == DiscountType.Flat)
            {
                discountAmount = _discountValue;

                // Ensure discount doesn't exceed subtotal
                if (discountAmount > subtotal)
                {
                    discountAmount = subtotal;
                    txtDiscountValue.Text = subtotal.ToString("0.00");
                }
            }
            else // Percentage discount
            {
                discountAmount = subtotal * (_discountValue / 100);
            }

            // Calculate tax
            decimal taxableAmount = subtotal - discountAmount;
            decimal taxAmount = taxableAmount * (_taxRate / 100);

            // Calculate grand total
            decimal grandTotal = taxableAmount + taxAmount;

            // Update UI
            lblSubTotalValue.Text = subtotal.ToString("C");
            lblDiscountAmountValue.Text = discountAmount.ToString("C");
            lblTaxAmountValue.Text = taxAmount.ToString("C");
            lblGrandTotalValue.Text = grandTotal.ToString("C");

            // Update item count
            int totalItems = 0;
            foreach (var item in _billItems)
            {
                totalItems += item.Quantity;
            }
            lblItemCount.Text = $"Items: {_billItems.Count} (Qty: {totalItems})";

            // Enable/disable buttons based on items
            btnCheckout.Enabled = _billItems.Count > 0;
            btnClearBill.Enabled = _billItems.Count > 0;
        }

        private Task<string> BtnSetBillSavePath()
        {
            try
            {
                if (string.IsNullOrEmpty(CacheManager.BillSavePath) || !Directory.Exists(CacheManager.BillSavePath))
                {
                    using var folderBrowser = new FolderBrowserDialog();
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        CacheManager.BillSavePath = folderBrowser.SelectedPath;
                        MessageBox.Show("Bill save path set to: " + CacheManager.BillSavePath);
                    }
                }

                return Task.FromResult(CacheManager.BillSavePath);
            }
            catch (Exception ex)
            {
                ShowError($"Error setting bill save path: {ex.Message}");
                return Task.FromResult<string>(null);
            }
        }

        private async void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (_billItems.Count == 0)
            {
                ShowError("Please add items to the bill before checkout.");
                return;
            }

            try
            {
                ShowLoading(true);

                var bill = CreateBillFromCurrentState();
                bill.IsCheckedOut = true;
                bill = await _billingService.CreateBillAsync(bill);

                string selectedPath = await BtnSetBillSavePath();
                if (string.IsNullOrEmpty(selectedPath))
                {
                    ShowError("Checkout aborted: No valid save path selected.");
                    return;
                }

                string fullPath = _pdfGenerator.GenerateBillPdf(bill, selectedPath);
                bill.BillPath = fullPath;

                ShowSuccess($"Checkout completed successfully. Bill Number: {bill.BillNumber}");

                if (MessageBox.Show("Checkout completed. Do you want to print the receipt?", "Success",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fullPath);
                }

                _billItems.Clear();
                flpItemsPanel.Controls.Clear();
                txtDiscountValue.Text = "0";
                UpdateBillSummary();
            }
            catch (Exception ex)
            {
                ShowError($"Error during checkout: {ex.Message}");
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private Bill CreateBillFromCurrentState()
        {
            // Remove currency symbol from values
            string subTotalString = lblSubTotalValue.Text.Replace("₹", "").Replace("₹", "");
            string discountAmountString = lblDiscountAmountValue.Text.Replace("₹", "").Replace("₹", "");
            string taxAmountString = lblTaxAmountValue.Text.Replace("₹", "").Replace("₹", "");
            string grandTotalString = lblGrandTotalValue.Text.Replace("₹", "").Replace("₹", "");

            return new Bill
            {
                OrganizationId = _organizationId,
                BilledBy = _userName,
                Items = [.. _billItems], // Create a copy of the list
                SubTotal = decimal.Parse(subTotalString),
                TaxRate = _taxRate,
                TaxAmount = decimal.Parse(taxAmountString),
                DiscountType = (decimal)_discountType,
                DiscountValue = _discountValue,
                DiscountAmount = decimal.Parse(discountAmountString),
                GrandTotal = decimal.Parse(grandTotalString),
                BillDate = DateTime.Now
            };
        }

        private void BtnClearBill_Click(object sender, EventArgs e)
        {
            if (_billItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to clear all items?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _billItems.Clear();
                    flpItemsPanel.Controls.Clear();
                    txtDiscountValue.Text = "0";
                    UpdateBillSummary();
                }
            }
        }

        private void ShowLoading(bool isLoading)
        {
            if (isLoading)
            {
                Cursor = Cursors.WaitCursor;
                panelLoading.Visible = true;
                panelLoading.BringToFront();
            }
            else
            {
                Cursor = Cursors.Default;
                panelLoading.Visible = false;
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}