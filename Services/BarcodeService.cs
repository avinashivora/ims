using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;

namespace ims.Services
{
    public class BarcodeService
    {
        public string DecodeBarcode(string imagePath)
        {
            try
            {
                var reader = new BarcodeReader
                {
                    Options = new DecodingOptions
                    {
                        TryHarder = true,
                        PossibleFormats = new[] { BarcodeFormat.All_1D }
                    }
                };

                using (var bitmap = new Bitmap(imagePath))
                {
                    var result = reader.Decode(bitmap);
                    return result?.Text;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error decoding barcode: {ex.Message}");
            }
        }

        public async Task<string> DecodeBarcodeAsync(Stream imageStream)
        {
            try
            {
                var reader = new BarcodeReader
                {
                    Options = new DecodingOptions
                    {
                        TryHarder = true,
                        PossibleFormats = new[] { BarcodeFormat.All_1D }
                    }
                };

                using (var memoryStream = new MemoryStream())
                {
                    await imageStream.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;

                    using (var bitmap = new Bitmap(memoryStream))
                    {
                        var result = reader.Decode(bitmap);
                        return result?.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error decoding barcode: {ex.Message}");
            }
        }
    }
}