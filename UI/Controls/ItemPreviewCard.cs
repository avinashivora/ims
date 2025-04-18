using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ims.Models;
using ims.Utils;

namespace ims.UI.Controls
{
    public partial class ItemPreviewCard : UserControl
    {
        private List<Image> _images;
        private int _imageIndex = 0;
        private Timer _carouselTimer;
        private const int HorizontalPadding = 10;
        private const int VerticalSpacing = 5;
        private const int ImageWidth = 120;
        private const int ImageHeight = 100;
        private const int FixedCardWidth = 680;
        private const int StockLabelWidth = 70;
        private const int PriceLabelOffsetFromRight = 250;
        private const int DeleteButtonSize = 30;
        private const int DeleteButtonRightOffset = 10;
        private const int DeleteButtonTopOffset = 10;

        public Item ItemData { get; private set; }
        public event Action<Item> ItemClicked;
        public event Action<Item> ItemDeleteRequested;

        public ItemPreviewCard(Item item)
        {
            InitializeComponent();
            this.Width = FixedCardWidth;
            ItemData = item;
            LoadItemDetails();

            this.Click += ItemPreviewCard_Click;
            foreach (Control ctl in this.Controls)
                ctl.Click += ItemPreviewCard_Click;

            this.Disposed += ItemPreviewCard_Disposed;
        }

        private void ItemPreviewCard_Disposed(object sender, EventArgs e)
        {
            if (_images != null)
            {
                foreach (var image in _images)
                {
                    image?.Dispose();
                }
                _images.Clear();
                _images = null;
            }
            _carouselTimer?.Stop();
            _carouselTimer?.Dispose();
            _carouselTimer = null;
        }

        private void ItemPreviewCard_Click(object sender, EventArgs e)
        {
            // Prevent click on the delete button from triggering the item click
            if (sender != btnDeleteItem)
            {
                ItemClicked?.Invoke(ItemData);
            }
        }

        private void LoadItemDetails()
        {
            lblName.Text = ItemData.Name;
            lblQuantity.Text = $"In Stock: {ItemData.Quantity}";
            lblPrice.Text = $"Price: {ItemData.Price}";

            // Make "In Stock:" and "Price:" bold
            lblQuantity.Text = lblQuantity.Text.Replace("In Stock:", "<b>In Stock:</b>");
            lblPrice.Text = lblPrice.Text.Replace("Price:", "<b>Price:</b> ₹");

            // Load Images
            _images = new List<Image>();
            foreach (var base64 in ItemData.Images ?? [])
            {
                try
                {
                    var img = ImageUtils.Base64ToImage(base64);
                    if (img != null)
                        _images.Add(img);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image for {ItemData.Name}: {ex.Message}");
                }
            }

            // Configure PictureBox and Timer
            if (_images.Count > 0)
            {
                pictureBox.Image = _images[0];
                _carouselTimer = new Timer { Interval = 2000 };
                _carouselTimer.Tick += CarouselTimer_Tick;
                _carouselTimer.Start();
                pictureBox.Visible = true;
                pictureBox.Size = new Size(ImageWidth, ImageHeight);
            }
            else
            {
                pictureBox.Visible = false;
                _carouselTimer?.Stop();
                _carouselTimer?.Dispose();
                _carouselTimer = null;
            }

            // Set Description and Adjust Layout
            lblDescription.Text = string.IsNullOrWhiteSpace(ItemData.Description) ? "" : ItemData.Description;
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int currentY = HorizontalPadding;

            // Name
            lblName.Location = new Point(HorizontalPadding, currentY);
            currentY = lblName.Bottom + VerticalSpacing;

            // Stock and Price on the same line
            lblQuantity.Location = new Point(HorizontalPadding, currentY);
            lblPrice.Location = new Point(this.ClientSize.Width - PriceLabelOffsetFromRight, currentY);
            currentY = lblQuantity.Bottom + VerticalSpacing; // Move Y down after this line

            // Description
            lblDescription.Location = new Point(HorizontalPadding, currentY);
            lblDescription.AutoSize = true;
            lblDescription.MaximumSize = new Size(
                pictureBox.Visible ? this.ClientSize.Width - ImageWidth - 3 * HorizontalPadding - DeleteButtonSize - 5 : this.ClientSize.Width - 2 * HorizontalPadding - DeleteButtonSize - 5,
                0);
            currentY = lblDescription.Bottom + VerticalSpacing;

            // Position PictureBox
            if (pictureBox.Visible)
            {
                pictureBox.Location = new Point(this.ClientSize.Width - ImageWidth - HorizontalPadding, HorizontalPadding);
                currentY = Math.Max(currentY, pictureBox.Bottom + HorizontalPadding);
            }
            else
            {
                currentY += HorizontalPadding;
            }

            // Position Delete Button
            btnDeleteItem.Size = new Size(DeleteButtonSize, DeleteButtonSize);
            btnDeleteItem.Location = new Point(this.ClientSize.Width - DeleteButtonSize - DeleteButtonRightOffset, DeleteButtonTopOffset);

            this.Height = currentY;
        }

        private void CarouselTimer_Tick(object sender, EventArgs e)
        {
            if (_images.Count == 0 || pictureBox.IsDisposed) return;
            _imageIndex = (_imageIndex + 1) % _images.Count;
            if (!pictureBox.IsDisposed)
            {
                pictureBox.Image = _images[_imageIndex];
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = FixedCardWidth;
            lblDescription.MaximumSize = new Size(
                pictureBox.Visible ? this.ClientSize.Width - ImageWidth - 3 * HorizontalPadding - DeleteButtonSize - 5 : this.ClientSize.Width - 2 * HorizontalPadding - DeleteButtonSize - 5,
                0);
            // Keep the price label's X position consistent relative to the right
            lblPrice.Location = new Point(this.ClientSize.Width - PriceLabelOffsetFromRight, lblQuantity.Location.Y);
            // Keep the delete button's position consistent relative to the right
            btnDeleteItem.Location = new Point(this.ClientSize.Width - DeleteButtonSize - DeleteButtonRightOffset, DeleteButtonTopOffset);
            AdjustLayout();
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            ItemDeleteRequested?.Invoke(ItemData);
        }
    }
}