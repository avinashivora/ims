using System;
using System.Drawing;
using System.IO;
using System.Linq;
using BarcodeStandard;
using ims.Models;
using SkiaSharp;

namespace ims.Utils
{
    public static class BarcodeHelper
    {
        public static object[] GetSupportedBarcodeTypesList()
        {
            // Include all the relevant barcode types that should be attempted
            return
            [
                "Code11",
                "Code39",
                "Code93",
                "Code128",
                "Ean13",
                "Ean8",
                "Itf14",
                "Interleaved2Of5",
                "UpcA",
                "UpcE"
            ];
        }

        public static BarcodeData GenerateBarcode(string value, string type)
        {
            BarcodeStandard.Type barcodeType = type switch
            {
                "Code128" => BarcodeStandard.Type.Code128,
                "Code39" => BarcodeStandard.Type.Code39,
                "Code11" => BarcodeStandard.Type.Code11,
                "Ean13" => BarcodeStandard.Type.Ean13,
                "Ean8" => BarcodeStandard.Type.Ean8,
                "UpcA" => BarcodeStandard.Type.UpcA,
                "UpcE" => BarcodeStandard.Type.UpcE,
                "Itf14" => BarcodeStandard.Type.Itf14,
                "Interleaved2of5" => BarcodeStandard.Type.Interleaved2Of5,
                _ => BarcodeStandard.Type.Code93,
            };

            var barcode = new Barcode
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.Center,
                LabelFont = new SKFont(SKTypeface.FromFamilyName("Arial"), 10)
            };

            // Validate that the value is compatible with the barcode type
            string validatedValue = ValidateForBarcodeType(value, type);

            SKImage image = barcode.Encode(barcodeType, validatedValue, SKColors.Black, SKColors.White, 300, 100);
            string base64 = ImageToBase64(image);
            return new BarcodeData { Type = type, BarcodeString = validatedValue, BarcodeImage = base64 };
        }

        // Additional method to validate and correct barcode values if needed
        private static string ValidateForBarcodeType(string value, string type)
        {
            switch (type)
            {
                case "Ean13":
                    // Must be 13 digits
                    if (value.Length != 13 || !value.All(char.IsDigit))
                    {
                        // Generate a valid EAN-13
                        return GenerateEan13("PROD", "ORG");
                    }
                    break;

                case "Ean8":
                    // Must be 8 digits
                    if (value.Length != 8 || !value.All(char.IsDigit))
                    {
                        return GenerateEan8("PROD", "ORG");
                    }
                    break;

                case "UpcA":
                    // Must be 12 digits
                    if (value.Length != 12 || !value.All(char.IsDigit))
                    {
                        return GenerateUpcA("PROD", "ORG");
                    }
                    break;

                case "UpcE":
                    // Valid UPC-E is 8 digits with first digit being 0
                    if (!IsValidUpcE(value))
                    {
                        return GenerateUpcE("PROD", "ORG");
                    }
                    break;

                case "Itf14":
                    // Must be 14 digits
                    if (value.Length != 14 || !value.All(char.IsDigit))
                    {
                        return GenerateItf14("PROD", "ORG");
                    }
                    break;

                case "Interleaved2of5":
                    // Must be even number of digits
                    if (value.Length % 2 != 0 || !value.All(char.IsDigit))
                    {
                        return GenerateInterleaved2of5("PROD", "ORG");
                    }
                    break;

                case "Code39":
                    // Check for invalid characters
                    string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-. $/+%";
                    if (!value.ToUpper().All(c => validChars.Contains(c)))
                    {
                        return GenerateCode39("PROD", "ORG");
                    }
                    break;

                case "Code11":
                    // Must be digits and hyphens
                    if (!value.All(c => char.IsDigit(c) || c == '-'))
                    {
                        return GenerateCode11("PROD", "ORG");
                    }
                    break;
            }

            return value; // Return original if it passes validation
        }

        // Validation function for UPC-E
        private static bool IsValidUpcE(string code)
        {
            // UPC-E must be 8 digits long
            if (code.Length != 8 || !code.All(char.IsDigit))
                return false;

            // First digit must be 0
            if (code[0] != '0')
                return false;

            return true;
        }

        public static string GenerateUniqueBarcodeString(string itemName, string organizationId, string barcodeType = "Code128")
        {
            // Apply format-specific generation logic based on barcode type
            switch (barcodeType)
            {
                case "Ean13":
                    return GenerateEan13(itemName, organizationId);

                case "Ean8":
                    return GenerateEan8(itemName, organizationId);

                case "UpcA":
                    return GenerateUpcA(itemName, organizationId);

                case "UpcE":
                    return GenerateUpcE(itemName, organizationId);

                case "Code39":
                    return GenerateCode39(itemName, organizationId);

                case "Code11":
                    return GenerateCode11(itemName, organizationId);

                case "Itf14":
                    return GenerateItf14(itemName, organizationId);

                case "Interleaved2of5":
                    return GenerateInterleaved2of5(itemName, organizationId);

                case "Code93":
                    return GenerateCode93(itemName, organizationId);

                case "Code128":
                default:
                    return GenerateCode128(itemName, organizationId);
            }
        }

        // Code128 accepts all ASCII characters
        private static string GenerateCode128(string itemName, string organizationId)
        {
            // Code128 can handle any ASCII character, so the original logic works
            string namePart = itemName.Length <= 5 ? itemName.ToUpper() : itemName.Substring(0, 5).ToUpper();
            string orgPart = organizationId.Length <= 3 ? organizationId.ToUpper() : organizationId.Substring(0, 3).ToUpper();
            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 3);
            Random random = new();
            int randomDigit = random.Next(0, 9);

            string combined = $"{namePart}{orgPart}{timePart}{randomDigit}";
            return combined.Substring(0, Math.Min(16, combined.Length)); // Code128 can handle longer strings
        }

        // Code39 accepts [A-Z, 0-9, - . $ / + % space]
        private static string GenerateCode39(string itemName, string organizationId)
        {
            // Only use valid Code39 characters
            string namePart = CleanForCode39(itemName, 5);
            string orgPart = CleanForCode39(organizationId, 3);

            // Only use digits for time part
            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 3);
            Random random = new();
            int randomDigit = random.Next(0, 9);

            string combined = $"{namePart}{orgPart}{timePart}{randomDigit}";
            return combined.Substring(0, Math.Min(12, combined.Length));
        }

        // Helper method to clean strings for Code39
        private static string CleanForCode39(string input, int maxLength)
        {
            // Only keep valid Code39 characters: A-Z, 0-9, - . $ / + % space
            string cleaned = "";
            foreach (char c in input.ToUpper())
            {
                if ((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') ||
                    c == '-' || c == '.' || c == '$' || c == '/' || c == '+' || c == '%' || c == ' ')
                {
                    cleaned += c;
                }
            }

            return cleaned.Length <= maxLength ? cleaned : cleaned.Substring(0, maxLength);
        }

        // Code93 accepts [A-Z, 0-9, - . $ / + % space]
        private static string GenerateCode93(string itemName, string organizationId)
        {
            // Similar to Code39 but can be slightly longer
            string namePart = CleanForCode39(itemName, 5); // Using same clean function as Code39
            string orgPart = CleanForCode39(organizationId, 3);

            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 3);
            Random random = new();
            int randomDigit = random.Next(0, 9);

            string combined = $"{namePart}{orgPart}{timePart}{randomDigit}";
            return combined.Substring(0, Math.Min(12, combined.Length));
        }

        // Code11 accepts [0-9, -]
        private static string GenerateCode11(string itemName, string organizationId)
        {
            // Convert itemName to a numeric representation
            string numericName = ConvertToNumeric(itemName, 5);
            string numericOrg = ConvertToNumeric(organizationId, 3);

            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 3);
            Random random = new();
            int randomDigit = random.Next(0, 9);

            string combined = $"{numericName}-{numericOrg}{timePart}{randomDigit}";
            return combined.Substring(0, Math.Min(12, combined.Length));
        }

        // EAN-13 requires 13 numeric digits (12 + 1 check digit)
        private static string GenerateEan13(string itemName, string organizationId)
        {
            // For EAN-13, we need 12 numeric digits (last digit is check digit)

            // Use organization ID as country/manufacturer code (first 3 digits)
            string orgDigits = ConvertToNumeric(organizationId, 3).PadRight(3, '0');

            // Use item name for product code (next 4 digits)
            string itemDigits = ConvertToNumeric(itemName, 4).PadRight(4, '0');

            // Fill the remaining 5 digits with timestamp and random
            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 4);
            Random random = new();
            string randomDigit = random.Next(0, 9).ToString();

            // Combine to 12 digits
            string combined = $"{orgDigits}{itemDigits}{timePart}{randomDigit}";
            combined = combined.Substring(0, 12).PadRight(12, '0');

            // Calculate check digit (we're using a simplified method here)
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = int.Parse(combined[i].ToString());
                sum += (i % 2 == 0) ? digit : digit * 3;
            }
            int checkDigit = (10 - (sum % 10)) % 10;

            return combined + checkDigit;
        }

        // EAN-8 requires 8 numeric digits (7 + 1 check digit)
        private static string GenerateEan8(string itemName, string organizationId)
        {
            // For EAN-8, we need 7 numeric digits (last digit is check digit)

            // Use organization ID as country code (first 2 digits)
            string orgDigits = ConvertToNumeric(organizationId, 2).PadRight(2, '0');

            // Use item name for product code (next 2 digits)
            string itemDigits = ConvertToNumeric(itemName, 2).PadRight(2, '0');

            // Fill the remaining 3 digits with timestamp and random
            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 2);
            Random random = new();
            string randomDigit = random.Next(0, 9).ToString();

            // Combine to 7 digits
            string combined = $"{orgDigits}{itemDigits}{timePart}{randomDigit}";
            combined = combined.Substring(0, 7).PadRight(7, '0');

            // Calculate check digit (simplified method)
            int sum = 0;
            for (int i = 0; i < 7; i++)
            {
                int digit = int.Parse(combined[i].ToString());
                sum += (i % 2 == 0) ? digit * 3 : digit;
            }
            int checkDigit = (10 - (sum % 10)) % 10;

            return combined + checkDigit;
        }

        // UPC-A requires 12 numeric digits (11 + 1 check digit)
        private static string GenerateUpcA(string itemName, string organizationId)
        {
            // For UPC-A, we need 11 numeric digits (last digit is check digit)

            // Convert organization ID to numeric and use as first 5 digits
            string orgDigits = ConvertToNumeric(organizationId, 5).PadRight(5, '0');

            // Convert item name to numeric and use as next 5 digits
            string itemDigits = ConvertToNumeric(itemName, 5).PadRight(5, '0');

            // Add one more digit using timestamp
            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 1);

            // Combine to 11 digits
            string combined = $"{orgDigits}{itemDigits}{timePart}";
            combined = combined.Substring(0, 11).PadRight(11, '0');

            // Calculate check digit
            int sum = 0;
            for (int i = 0; i < 11; i++)
            {
                int digit = int.Parse(combined[i].ToString());
                sum += (i % 2 == 0) ? digit * 3 : digit;
            }
            int checkDigit = (10 - (sum % 10)) % 10;

            return combined + checkDigit;
        }

        // UPC-E is a compressed version of UPC-A (8 digits total including check digit)
        private static string GenerateUpcE(string itemName, string organizationId)
        {
            // UPC-E is a compressed version of UPC-A with specific rules
            // Format: First digit (always 0) + 6 data digits + check digit

            // Force number system to 0 for UPC-E
            string numberSystem = "0";

            // Generate 6 data digits based on input
            string manufacturerCode = ConvertToNumeric(organizationId, 2).PadRight(2, '0');
            string productCode = ConvertToNumeric(itemName, 4).PadRight(4, '0');

            // Combine to form 6 data digits
            string dataDigits = $"{manufacturerCode}{productCode}";
            dataDigits = dataDigits.Substring(0, 6);

            // Full UPC-E without check digit: number system (0) + 6 data digits
            string upcEWithoutCheck = $"{numberSystem}{dataDigits}";

            // Calculate check digit based on expanded UPC-A equivalent
            // This is a simplified implementation - in practice, UPC-E check digit 
            // calculation involves expanding to UPC-A first
            int sum = 0;
            for (int i = 0; i < 7; i++)
            {
                int digit = int.Parse(upcEWithoutCheck[i].ToString());
                sum += (i % 2 == 0) ? digit * 3 : digit;
            }
            int checkDigit = (10 - (sum % 10)) % 10;

            // Return the 8-digit UPC-E: number system (0) + 6 data digits + check digit
            return $"{numberSystem}{dataDigits}{checkDigit}";
        }

        // ITF-14 requires 14 numeric digits (13 + 1 check digit)
        private static string GenerateItf14(string itemName, string organizationId)
        {
            // For ITF-14, we typically use 13 numeric digits + 1 check digit
            // First digit is packaging indicator (0-8)
            Random random = new();
            string packagingIndicator = random.Next(0, 9).ToString();

            // Use an EAN-13 code (without check digit) for the next 12 digits
            string ean13WithoutCheck = GenerateEan13(itemName, organizationId).Substring(0, 12);

            // Combine to 13 digits
            string combined = $"{packagingIndicator}{ean13WithoutCheck}";

            // Calculate check digit
            int sum = 0;
            for (int i = 0; i < 13; i++)
            {
                int digit = int.Parse(combined[i].ToString());
                sum += (i % 2 == 0) ? digit : digit * 3;
            }
            int checkDigit = (10 - (sum % 10)) % 10;

            return combined + checkDigit;
        }

        // Interleaved 2 of 5 requires an even number of numeric digits
        private static string GenerateInterleaved2of5(string itemName, string organizationId)
        {
            // For Interleaved 2 of 5, we need an even number of digits
            string numericName = ConvertToNumeric(itemName, 4);
            string numericOrg = ConvertToNumeric(organizationId, 4);

            string timePart = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 4);

            // Combine to get an even number of digits
            string combined = $"{numericOrg}{numericName}{timePart}";
            if (combined.Length % 2 != 0)
            {
                combined += "0"; // Add a trailing zero if needed to make it even
            }

            return combined.Substring(0, Math.Min(14, combined.Length));
        }

        // Helper method to convert any string to numeric representation
        private static string ConvertToNumeric(string input, int maxLength)
        {
            string result = "";

            // Convert alphabetic characters to their ASCII values
            foreach (char c in input.ToUpper())
            {
                if (char.IsDigit(c))
                {
                    result += c;
                }
                else if (char.IsLetter(c))
                {
                    // Convert letter to a two-digit number (A=65, B=66, etc.)
                    int value = c - 'A' + 10; // A=10, B=11, etc.
                    result += value.ToString();
                }
            }

            // Trim or pad as needed
            if (result.Length > maxLength)
            {
                result = result.Substring(0, maxLength);
            }

            return result;
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
