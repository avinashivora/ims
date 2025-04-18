using System;
using System.Windows.Forms;
using ims.Models;
using ims.Services;

namespace ims.UI.Forms
{
    public partial class AddStockForm : Form
    {
        private readonly ItemService _itemService;
        private readonly Item _item;
        public Item UpdatedItem { get; private set; }

        public AddStockForm(Item item)
        {
            InitializeComponent();
            _itemService = new ItemService();
            _item = item;

            // Display item information
            lblItemName.Text = $"Item: {item.Name}";
            lblCurrentStock.Text = $"Current Stock: {item.Quantity}";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the quantity to add
                int quantityToAdd = (int)numQuantity.Value;

                if (quantityToAdd <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity to add.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a copy of the item with updated quantity
                var updatedItem = new Item
                {
                    Id = _item.Id,
                    Name = _item.Name,
                    Description = _item.Description,
                    CategoryId = _item.CategoryId,
                    Price = _item.Price,
                    Images = _item.Images,
                    Quantity = _item.Quantity + quantityToAdd, // Add to existing quantity
                    Barcode = _item.Barcode
                };

                // Update the item in the database
                await _itemService.UpdateItemAsync(_item.Id, updatedItem);

                // Set the updated item for the calling form
                UpdatedItem = updatedItem;

                MessageBox.Show($"Successfully added {quantityToAdd} to stock. New stock level: {updatedItem.Quantity}",
                    "Stock Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}