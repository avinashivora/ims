using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Models;
using ims.Services;
using ims.Utils;

namespace ims.UI.Controls
{
    public partial class ItemFormControl : UserControl
    {
        private readonly ItemService _itemService = new();
        private readonly CategoryService _categoryService = new();
        private readonly bool _isUpdate;
        private readonly Item _item;
        private BarcodeData _generatedBarcode;
        private string _selectedBarcodeType = "Code93";
        private List<string> _imageBase64List = [];
        private int _currentImageIndex = 0;
        public event Action<string> NewItemSaved;
        public Item UpdatedItem { get; private set; } // Made settable

        public event EventHandler ItemSaved;

        public ItemFormControl(Item item = null)
        {
            InitializeComponent();
            _item = item;
            _isUpdate = _item != null;
            this.Load += async (_, _) => await InitializeFormAsync();
        }

        private async Task InitializeFormAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            cmbBarcodeType.Items.AddRange(BarcodeHelper.GetSupportedBarcodeTypesList());
            cmbBarcodeType.SelectedItem = "Code93";
            cmbBarcodeType.SelectedIndexChanged += (_, _) => _selectedBarcodeType = cmbBarcodeType.SelectedItem?.ToString();

            if (_isUpdate)
            {
                PopulateFields();
            }
        }

        private void PopulateFields()
        {
            txtName.Text = _item.Name;
            txtDescription.Text = _item.Description;
            txtPrice.Text = _item.Price.ToString();
            numQuantity.Value = _item.Quantity;
            cmbCategory.SelectedValue = _item.CategoryId;
            cmbBarcodeType.SelectedItem = _item.Barcode?.Type ?? "Code93";
            pbBarcode.Image = BarcodeHelper.Base64ToImage(_item.Barcode?.BarcodeImage);
            _generatedBarcode = _item.Barcode;
            _imageBase64List = [.. _item.Images ?? []];
            LoadImagePreview();
            btnDownloadBarcode.Visible = true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            try
            {
                if (!ValidateInputs()) return;
                
                var item = new Item
                {
                    Id = _item?.Id,
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    CategoryId = cmbCategory.SelectedValue?.ToString(),
                    Quantity = (int)numQuantity.Value,
                    Price = decimal.TryParse(txtPrice.Text.Trim(), out var price) ? price : 0,
                    Images = _imageBase64List,
                    Barcode = _generatedBarcode,
                    OrganizationId = CacheManager.CurrentOrganizationId
                };

                if (!_isUpdate || IsBarcodeRegenerationRequested())
                {
                    _generatedBarcode = BarcodeHelper.GenerateBarcode(BarcodeHelper.GenerateUniqueBarcodeString(item.Name, item.OrganizationId), _selectedBarcodeType);
                    pbBarcode.Image = BarcodeHelper.Base64ToImage(_generatedBarcode.BarcodeImage);
                    item.Barcode = _generatedBarcode;

                    using var sfd = new SaveFileDialog
                    {
                        FileName = $"{item.Name} barcode.png",
                        Filter = "PNG Image|*.png"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var img = BarcodeHelper.Base64ToImage(_generatedBarcode.BarcodeImage);
                        img.Save(sfd.FileName);
                        MessageBox.Show("Barcode saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (!_isUpdate)
                {
                    await _itemService.AddItemAsync(item);
                    NewItemSaved?.Invoke(item.CategoryId);
                    MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (item.Quantity != _item.Quantity)
                    {
                        var confirmResult = MessageBox.Show("Quantity has changed. Do you want to update the stock?",
                            "Confirm Update",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (confirmResult == DialogResult.No)
                        {
                            numQuantity.Value = _item.Quantity; // Reset to original quantity   
                        }
                    }
                    await _itemService.UpdateItemAsync(item.Id, item);
                    UpdatedItem = item; // Now you can set it
                    MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ItemSaved?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private bool IsBarcodeRegenerationRequested()
        {
            return !_isUpdate || cmbBarcodeType.SelectedItem?.ToString() != _generatedBarcode?.Type;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Item name is required.");
                return false;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative price.");
                return false;
            }

            return true;
        }

        private void BtnDownloadBarcode_Click(object sender, EventArgs e)
        {
            if (_generatedBarcode == null) return;

            using var sfd = new SaveFileDialog
            {
                FileName = $"{_item?.Name ?? "barcode"}.png",
                Filter = "PNG Image|*.png"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var img = BarcodeHelper.Base64ToImage(_generatedBarcode.BarcodeImage);
                img.Save(sfd.FileName);
                MessageBox.Show("Barcode saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    if (_imageBase64List.Count >= 10)
                    {
                        MessageBox.Show("Maximum of 10 images allowed.", "Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    var base64 = ImageUtils.ResizeAndConvertToBase64(file, 300, 180);
                    if (!ImageUtils.IsDuplicateImage(base64, _imageBase64List))
                        _imageBase64List.Add(base64);
                }

                LoadImagePreview();
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_imageBase64List.Count == 0) return;
            _currentImageIndex = (_currentImageIndex - 1 + _imageBase64List.Count) % _imageBase64List.Count;
            LoadImagePreview();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_imageBase64List.Count == 0) return;
            _currentImageIndex = (_currentImageIndex + 1) % _imageBase64List.Count;
            LoadImagePreview();
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            if (_imageBase64List.Count == 0) return;
            _imageBase64List.RemoveAt(_currentImageIndex);
            _currentImageIndex = Math.Max(0, _currentImageIndex - 1);
            LoadImagePreview();
        }

        private void LoadImagePreview()
        {
            if (_imageBase64List.Count > 0)
            {
                pbImagePreview.Image = ImageUtils.Base64ToImage(_imageBase64List[_currentImageIndex]);
                lblImageIndex.Text = $"{_currentImageIndex + 1} / {_imageBase64List.Count}";
                btnDeleteImage.Enabled = true;
            }
            else
            {
                pbImagePreview.Image = null;
                lblImageIndex.Text = "0 / 0";
                btnDeleteImage.Enabled = false;
            }
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, decimal point, control characters (backspace, delete)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block the character
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as Guna2TextBox).Text.Contains('.'))
            {
                e.Handled = true; // Block the second decimal point
            }
        }

        private void TxtPrice_Leave(object sender, EventArgs e)
        {
            Guna2TextBox textBox = sender as Guna2TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (!float.TryParse(textBox.Text, out float value) || value < 0)
                {
                    MessageBox.Show("Please enter the Proper Price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Text = ""; // Clear the invalid input
                    textBox.Focus();     // Optionally set focus back to the textbox
                }
            }
        }

        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}