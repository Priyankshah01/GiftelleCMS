using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMS.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
    }
}