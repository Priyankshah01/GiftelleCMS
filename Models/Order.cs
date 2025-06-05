using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMS.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
