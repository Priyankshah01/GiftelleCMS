using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMS.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
