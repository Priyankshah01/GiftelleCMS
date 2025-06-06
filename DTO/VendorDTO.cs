using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMSbackend.DTOs
{
    public class VendorDTO
    {
        public required int VendorId { get; set; }
        public required string Name { get; set; }
        public required string ContactEmail { get; set; }
    }
}