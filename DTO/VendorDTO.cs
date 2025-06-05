using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMS.DTOs
{
    public class VendorDTO
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
    }
}