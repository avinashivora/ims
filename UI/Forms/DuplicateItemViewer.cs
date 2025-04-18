using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Models;
using ims.Utils;

namespace ims.UI.Forms
{
    public partial class DuplicateItemViewer : Form
    {
        public bool ProceedWithCreation { get; private set; } = false;
        private Panel _currentlyExpandedPanel = null;

        public DuplicateItemViewer(List<Item> duplicates, Dictionary<string, string> categoryNames)
        {
            InitializeComponent();
            RenderDuplicateItems(duplicates, categoryNames);
        }

        private void RenderDuplicateItems(List<Item> items, Dictionary<string, string> categoryNames)
        {
            foreach (var item in items)
            {
                var containerPanel = new Guna2Panel
                {
                    Width = flowLayoutPanel.Width - 30,
                    BorderRadius = 5,
                    BorderColor = Color.Gray,
                    BorderThickness = 1,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    AutoSize = true,
                    BackColor = Color.White
                };

                string categoryName = categoryNames.TryGetValue(item.CategoryId, out var name) ? name : "Unknown";
                string headerText = $"Category: {categoryName}\t\t{item.Name}";

                var headerButton = new Guna2Button
                {
                    Text = headerText,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    FillColor = Color.FromArgb(245, 245, 245),
                    ForeColor = Color.Black,
                    BorderRadius = 5,
                    Height = 40,
                    Cursor = Cursors.Hand
                };

                var detailPanel = new Panel
                {
                    Visible = false,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    BackColor = Color.White
                };

                headerButton.Click += (s, e) =>
                {
                    // Accordion logic: close others
                    if (_currentlyExpandedPanel != null && _currentlyExpandedPanel != detailPanel)
                        _currentlyExpandedPanel.Visible = false;

                    detailPanel.Visible = !detailPanel.Visible;
                    _currentlyExpandedPanel = detailPanel.Visible ? detailPanel : null;
                };

                // Split details into left and right sides
                var splitPanel = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    RowCount = 1,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                };
                splitPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                splitPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                // Left: text details
                var leftPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    Padding = new Padding(5)
                };

                leftPanel.Controls.Add(CreateLabel("Description: " + item.Description));
                leftPanel.Controls.Add(CreateLabel("Quantity: " + item.Quantity));
                leftPanel.Controls.Add(CreateLabel("Barcode Type: " + item.Barcode?.Type.ToString()));

                // Right: image carousel
                var rightPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    Padding = new Padding(5)
                };

                PictureBox imagePreview = new()
                {
                    Width = 300,
                    Height = 180,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var images = item.Images ?? new List<string>();
                int imgIndex = 0;

                if (images.Count > 0)
                    imagePreview.Image = BarcodeHelper.Base64ToImage(images[0]);

                var btnPrev = new Guna2Button { Text = "◀", Width = 60, Height = 30 };
                var btnNext = new Guna2Button { Text = "▶", Width = 60, Height = 30 };

                btnPrev.Click += (s, e) =>
                {
                    if (images.Count == 0) return;
                    imgIndex = (imgIndex - 1 + images.Count) % images.Count;
                    imagePreview.Image = BarcodeHelper.Base64ToImage(images[imgIndex]);
                };

                btnNext.Click += (s, e) =>
                {
                    if (images.Count == 0) return;
                    imgIndex = (imgIndex + 1) % images.Count;
                    imagePreview.Image = BarcodeHelper.Base64ToImage(images[imgIndex]);
                };

                var navPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true
                };
                navPanel.Controls.AddRange(new Control[] { btnPrev, btnNext });

                rightPanel.Controls.Add(imagePreview);
                rightPanel.Controls.Add(navPanel);

                splitPanel.Controls.Add(leftPanel, 0, 0);
                splitPanel.Controls.Add(rightPanel, 1, 0);

                detailPanel.Controls.Add(splitPanel);

                containerPanel.Controls.Add(detailPanel);
                containerPanel.Controls.Add(headerButton);

                flowLayoutPanel.Controls.Add(containerPanel);
            }
        }

        private Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Padding = new Padding(3)
            };
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            ProceedWithCreation = true;
            this.Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            ProceedWithCreation = false;
            this.Close();
        }
    }
}
