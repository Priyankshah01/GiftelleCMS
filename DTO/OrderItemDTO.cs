using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMSbackend.DTO
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
