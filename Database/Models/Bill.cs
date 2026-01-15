using System;
using System.Collections.Generic;

namespace CanteenBillingSystem.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<BillItem> Items { get; set; } = new List<BillItem>();
    }

    public class BillItem
    {
        public required Product Product { get; set; }  // Fixed: mark as required
        public int Quantity { get; set; }
        public decimal SubTotal => Product.Price * Quantity;
    }
}
