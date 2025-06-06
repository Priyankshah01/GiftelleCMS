using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMSbackend.DTOs
{
    public class ProductDTO
    {
        public required int ProductId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int VendorId { get; set; }
    }
}