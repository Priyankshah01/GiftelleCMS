using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMS.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int VendorId { get; set; }
    }
}