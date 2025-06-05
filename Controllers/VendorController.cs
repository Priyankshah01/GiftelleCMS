using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMS.Data;
using GiftelleCMS.Models;
using GiftelleCMS.DTOs;

namespace GiftelleCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly GiftelleDbContext _context;

        public VendorController(GiftelleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetVendors()
        {
            return await _context.Vendors
                .Select(v => new VendorDTO
                {
                    VendorId = v.VendorId,
                    Name = v.Name,
                    ContactEmail = v.ContactEmail
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendorDTO>> GetVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
                return NotFound();

            return new VendorDTO
            {
                VendorId = vendor.VendorId,
                Name = vendor.Name,
                ContactEmail = vendor.ContactEmail
            };
        }

        [HttpPost]
        public async Task<ActionResult<VendorDTO>> CreateVendor(VendorDTO dto)
        {
            var vendor = new Vendor
            {
                Name = dto.Name,
                ContactEmail = dto.ContactEmail
            };

            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            dto.VendorId = vendor.VendorId;
            return CreatedAtAction(nameof(GetVendor), new { id = vendor.VendorId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(int id, VendorDTO dto)
        {
            if (id != dto.VendorId)
                return BadRequest();

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
                return NotFound();

            vendor.Name = dto.Name;
            vendor.ContactEmail = dto.ContactEmail;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
                return NotFound();

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
