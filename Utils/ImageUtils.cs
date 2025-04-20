using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.Utils
{
    public static class ImageUtils
    {
        // Resize original image to fit max dimensions
        public static Image ResizeImageToFit(Image originalImage, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / originalImage.Width;
            var ratioY = (double)maxHeight / originalImage.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(originalImage.Width * ratio);
            var newHeight = (int)(originalImage.Height * ratio);

            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        // Resize and return base64
        public static string ResizeAndConvertToBase64(string filePath, int maxWidth, int maxHeight)
        {
            using var originalImage = Image.FromFile(filePath);
            using var resizedImage = ResizeImageToFit(originalImage, maxWidth, maxHeight);
            using var ms = new MemoryStream();
            resizedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.ToArray());
        }

        // Convert base64 to Image
        public static Image Base64ToImage(string base64)
        {
            byte[] imageBytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(imageBytes);
            return Image.FromStream(ms);
        }

        // Convert Image to base64
        public static string ImageToBase64(Image image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
        }

        // Check if base64 image already exists
        public static bool IsDuplicateImage(string newBase64, List<string> existingImages)
        {
            return existingImages.Contains(newBase64);
        }

        // Load carousel-style image into Guna2PictureBox
        public static void LoadCarouselImage(List<string> base64Images, Guna2PictureBox pictureBox, Label counterLabel, Button deleteButton, ref int currentIndex)
        {
            if (base64Images.Count == 0)
            {
                pictureBox.Image = null;
                counterLabel.Text = "0 / 0";
                deleteButton.Enabled = false;
                return;
            }

            try
            {
                pictureBox.Image = Base64ToImage(base64Images[currentIndex]);
                counterLabel.Text = $"{currentIndex + 1} / {base64Images.Count}";
                deleteButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}