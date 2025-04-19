using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class BillingService
    {
        private readonly IMongoCollection<Bill> _bills;
        private readonly IMongoCollection<Item> _itemCollection;
        private readonly InventoryService _inventoryService;

        public BillingService(InventoryService inventoryService)
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var database = client.GetDatabase(Constants.DatabaseName);
            _inventoryService = inventoryService;
            _itemCollection = database.GetCollection<Item>(Constants.ItemCollection);
            _bills = database.GetCollection<Bill>(Constants.BillCollection);
        }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            // Generate bill number
            bill.BillNumber = GenerateBillNumber();
            bill.BillDate = DateTime.Now;

            // Validate stock and calculate amounts
            await ValidateStockAsync(bill);
            CalculateBillAmounts(bill);

            // Save bill to database
            await _bills.InsertOneAsync(bill);

            // Update inventory
            await UpdateInventoryAsync(bill);

            return bill;
        }

        private string GenerateBillNumber()
        {
            // Format: BILL-YYYYMMDD-HHMMSS
            return $"BILL-{DateTime.Now:yyyyMMdd-HHmmss}";
        }

        private async Task ValidateStockAsync(Bill bill)
        {
            foreach (var item in bill.Items)
            {
                var inventoryItem = await _inventoryService.GetItemByBarcodeAsync(item.Barcode) ?? throw new Exception($"Item with barcode {item.Barcode} not found in inventory.");
                if (inventoryItem.Quantity < item.Quantity)
                {
                    throw new Exception($"Insufficient stock for {inventoryItem.Name}. Available: {inventoryItem.Quantity}, Requested: {item.Quantity}");
                }

                // Update item details from inventory
                item.ItemId = inventoryItem.Id;
                item.ItemName = inventoryItem.Name;
                item.UnitPrice = inventoryItem.Price;
                item.TotalPrice = item.UnitPrice * item.Quantity;
            }
        }

        private void CalculateBillAmounts(Bill bill)
        {
            // Calculate subtotal
            bill.SubTotal = 0;
            foreach (var item in bill.Items)
            {
                bill.SubTotal += item.TotalPrice;
            }

            // Calculate discount
            if (bill.DiscountType == (int)DiscountType.Flat)
            {
                bill.DiscountAmount = bill.DiscountValue;
            }
            else // Percentage discount
            {
                bill.DiscountAmount = bill.SubTotal * (bill.DiscountValue / 100);
            }

            // Ensure discount doesn't exceed subtotal
            if (bill.DiscountAmount > bill.SubTotal)
            {
                bill.DiscountAmount = bill.SubTotal;
            }

            // Calculate tax
            decimal taxableAmount = bill.SubTotal - bill.DiscountAmount;
            bill.TaxAmount = taxableAmount * (bill.TaxRate / 100);

            // Calculate grand total
            bill.GrandTotal = taxableAmount + bill.TaxAmount;
        }

        private async Task UpdateInventoryAsync(Bill bill)
        {
            foreach (var item in bill.Items)
            {
                await _inventoryService.UpdateStockQuantityAsync(item.ItemId, -item.Quantity);
            }
        }

        public async Task<Bill> GetBillByIdAsync(string id)
        {
            return await _bills.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Bill>> GetRecentBillsAsync(int limit = 50)
        {
            return await _bills.Find(_ => true)
                               .SortByDescending(b => b.BillDate)
                               .Limit(limit)
                               .ToListAsync();
        }
    }
}