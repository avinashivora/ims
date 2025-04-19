using System;
using System.Drawing;
using System.IO;
using System.Windows.Documents;
using ims.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfFont = iTextSharp.text.Font;
using PdfParagraph = iTextSharp.text.Paragraph;
using PdfRectangle = iTextSharp.text.Rectangle;

namespace ims.Utils
{
    public class PdfGenerator
    {
        public string GenerateBillPdf(Bill bill, string savePath)
        {
            try
            {
                // Create directory if it doesn't exist
                string directory = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Create a new PDF document
                Document doc = new(PageSize.A4, 50, 50, 50, 50);
                string fileName = $"Bill_{bill.BillNumber}.pdf";
                string fullPath = Path.Combine(savePath, fileName);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fullPath, FileMode.Create));
                doc.Open();

                // Set up fonts
                PdfFont titleFont = new(PdfFont.FontFamily.HELVETICA, 18, PdfFont.BOLD);
                PdfFont headingFont = new(PdfFont.FontFamily.HELVETICA, 12, PdfFont.BOLD);
                PdfFont normalFont = new(PdfFont.FontFamily.HELVETICA, 10, PdfFont.NORMAL);
                PdfFont smallFont = new(PdfFont.FontFamily.HELVETICA, 8, PdfFont.NORMAL);

                // Add company title
                PdfParagraph title = new("Inventory Management System", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(title);
                doc.Add(new PdfParagraph("\n"));

                // Add bill details
                PdfPTable detailsTable = new(2)
                {
                    WidthPercentage = 100
                };
                detailsTable.SetWidths([1f, 1f]);

                // Left column - Bill details
                PdfPCell leftCell = new()
                {
                    Border = PdfRectangle.NO_BORDER
                };
                leftCell.AddElement(new PdfParagraph($"Bill Number: {bill.BillNumber}", headingFont));
                leftCell.AddElement(new PdfParagraph($"Date: {bill.BillDate:dd/MM/yyyy HH:mm:ss}", normalFont));
                leftCell.AddElement(new PdfParagraph($"Organization ID: {bill.OrganizationId}", normalFont));
                leftCell.AddElement(new PdfParagraph($"Billed By: {bill.BilledBy}", normalFont));
                detailsTable.AddCell(leftCell);

                // Right column - empty for now or can add logo
                PdfPCell rightCell = new()
                {
                    Border = PdfRectangle.NO_BORDER
                };
                detailsTable.AddCell(rightCell);

                doc.Add(detailsTable);
                doc.Add(new PdfParagraph("\n"));

                // Add items table
                PdfPTable itemsTable = new(5)
                {
                    WidthPercentage = 100
                };
                itemsTable.SetWidths([0.5f, 2f, 0.5f, 1f, 1f]);

                // Add header row
                PdfPCell cell = new(new Phrase("Item Details", headingFont))
                {
                    Colspan = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    Padding = 5
                };
                itemsTable.AddCell(cell);

                // Add column headers
                itemsTable.AddCell(new PdfPCell(new Phrase("S.No", headingFont)));
                itemsTable.AddCell(new PdfPCell(new Phrase("Item Name", headingFont)));
                itemsTable.AddCell(new PdfPCell(new Phrase("Qty", headingFont)));
                itemsTable.AddCell(new PdfPCell(new Phrase("Price", headingFont)));
                itemsTable.AddCell(new PdfPCell(new Phrase("Total", headingFont)));

                // Add items
                int sno = 1;
                foreach (var item in bill.Items)
                {
                    itemsTable.AddCell(new PdfPCell(new Phrase(sno.ToString(), normalFont)));
                    itemsTable.AddCell(new PdfPCell(new Phrase(item.ItemName, normalFont)));
                    itemsTable.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString(), normalFont)));
                    itemsTable.AddCell(new PdfPCell(new Phrase(item.UnitPrice.ToString("C"), normalFont)));
                    itemsTable.AddCell(new PdfPCell(new Phrase(item.TotalPrice.ToString("C"), normalFont)));
                    sno++;
                }

                doc.Add(itemsTable);
                doc.Add(new PdfParagraph("\n"));

                // Add summary table
                PdfPTable summaryTable = new(2)
                {
                    WidthPercentage = 50,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                summaryTable.SetWidths([1f, 1f]);

                summaryTable.AddCell(new PdfPCell(new Phrase("Sub Total:", headingFont)));
                summaryTable.AddCell(new PdfPCell(new Phrase(bill.SubTotal.ToString("C"), normalFont)));

                // Add discount details if applicable
                if (bill.DiscountAmount > 0)
                {
                    string discountType = bill.DiscountType == (int)DiscountType.Flat ? "Flat Discount:" : "Discount (" + bill.DiscountValue + "%):";
                    summaryTable.AddCell(new PdfPCell(new Phrase(discountType, headingFont)));
                    summaryTable.AddCell(new PdfPCell(new Phrase("-" + bill.DiscountAmount.ToString("C"), normalFont)));
                }

                // Add tax details
                summaryTable.AddCell(new PdfPCell(new Phrase($"Tax ({bill.TaxRate}%):", headingFont)));
                summaryTable.AddCell(new PdfPCell(new Phrase(bill.TaxAmount.ToString("C"), normalFont)));

                // Add grand total
                PdfPCell grandTotalLabelCell = new(new Phrase("Grand Total:", headingFont))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY
                };
                summaryTable.AddCell(grandTotalLabelCell);

                PdfPCell grandTotalValueCell = new(new Phrase(bill.GrandTotal.ToString("C"), headingFont))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY
                };
                summaryTable.AddCell(grandTotalValueCell);

                doc.Add(summaryTable);
                doc.Add(new PdfParagraph("\n"));

                // Add footer
                PdfParagraph footer = new("Thank you for your business!", normalFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(footer);

                // Add terms and conditions
                PdfParagraph terms = new("This is a computer generated bill.", smallFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(terms);

                doc.Close();
                return fullPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error generating PDF: {ex.Message}");
            }
        }
    }
}