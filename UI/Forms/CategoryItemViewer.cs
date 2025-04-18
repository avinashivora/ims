using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Models;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class CategoryItemViewer : Form
    {
        public bool ProceedWithDeletion { get; private set; } = false;

        public CategoryItemViewer(List<Item> items)
        {
            InitializeComponent();
            RenderItems(items);
        }

        private void RenderItems(List<Item> items)
        {
            foreach (var item in items)
            {
                var label = new Label
                {
                    Text = $"• {item.Name} — Qty: {item.Quantity}, Price: {item.Price:C}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9),
                    Padding = new Padding(3)
                };

                flowItems.Controls.Add(label);
            }
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            ProceedWithDeletion = true;
            Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            ProceedWithDeletion = false;
            Close();
        }
    }
}
