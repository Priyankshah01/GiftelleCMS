using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GiftelleCMSbackend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
