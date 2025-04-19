using System;
using System.Drawing;
using System.IO;
using BarcodeStandard;
using ims.Models;
using SkiaSharp;

namespace ims.Utils
{
    public static class BarcodeHelper
    {
        public static BarcodeData GenerateBarcode(string value, string type)
        {
            BarcodeStandard.Type barcodeType = type switch
            {
                "Code128" => BarcodeStandard.Type.Code128,
                _ => BarcodeStandard.Type.Code93,
            };

            var barcode = new Barcode
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.Center,
                LabelFont = new SKFont(SKTypeface.FromFamilyName("Arial"), 10)
            };

            SKImage image = barcode.Encode(barcodeType, value, SKColors.Black, SKColors.White, 300, 100);
            string base64 = ImageToBase64(image);
            return new BarcodeData { Type = type, BarcodeString = value, BarcodeImage = base64 };
        }

        public static string GenerateUniqueBarcodeString(string itemName, string organizationId)
        {
            // 1. Basic Item Name Abbreviation (up to 5 characters)
            string namePart = itemName.Length <= 5 ? itemName.ToUpper() : itemName.Substring(0, 5).ToUpper();

            // 2. Organization ID Abbreviation (up to 3 characters)
            string orgPart = organizationId.Length <= 3 ? organizationId.ToUpper() : organizationId.Substring(0, 3).ToUpper();

            // 3. Timestamp (Milliseconds - last 3 digits for brevity and likely uniqueness within short bursts)
            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 3);

            // 4. Random Digit (to further increase uniqueness)
            Random random = new();
            int randomDigit = random.Next(0, 9);

            // Combine and truncate to max 12 characters
            string combined = $"{namePart}{orgPart}{timePart}{randomDigit}";
            return combined.Substring(0, Math.Min(12, combined.Length));
        }

        public static string ImageToBase64(SKImage image)
        {
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return Convert.ToBase64String(data.ToArray());
        }

        public static Image Base64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }
    }
}
