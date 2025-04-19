using System;
using System.Windows.Forms;
using ims.Models;

namespace ims.UI.Controls
{
    public partial class BillItemControl : UserControl
    {
        private BillItem _billItem;

        public event EventHandler<BillItemEventArgs> QuantityChanged;
        public event EventHandler<BillItemEventArgs> RemoveItem;

        public class BillItemEventArgs : EventArgs
        {
            public BillItem BillItem { get; set; }
        }

        public BillItemControl(BillItem billItem)
        {
            InitializeComponent();
            _billItem = billItem;

            // Set values
            lblItemName.Text = billItem.ItemName;
            lblBarcode.Text = billItem.Barcode;
            lblUnitPrice.Text = billItem.UnitPrice.ToString("C");
            nudQuantity.Value = billItem.Quantity;
            lblTotalPrice.Text = billItem.TotalPrice.ToString("C");
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            _billItem.Quantity = (int)nudQuantity.Value;
            _billItem.TotalPrice = _billItem.UnitPrice * _billItem.Quantity;
            lblTotalPrice.Text = _billItem.TotalPrice.ToString("C");

            QuantityChanged?.Invoke(this, new BillItemEventArgs { BillItem = _billItem });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveItem?.Invoke(this, new BillItemEventArgs { BillItem = _billItem });
        }
    }
}
