using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftelleCMS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

