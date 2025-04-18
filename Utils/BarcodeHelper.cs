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
