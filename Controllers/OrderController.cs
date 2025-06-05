using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMS.Data;
using GiftelleCMS.Models;
using GiftelleCMS.DTOs;

namespace GiftelleCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly GiftelleDbContext _context;

        public OrderController(GiftelleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            return await _context.Orders
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            return new OrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                CustomerName = order.CustomerName
            };
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO dto)
        {
            var order = new Order
            {
                OrderDate = dto.OrderDate,
                CustomerName = dto.CustomerName
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            dto.OrderId = order.OrderId;
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO dto)
        {
            if (id != dto.OrderId)
                return BadRequest();

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            order.OrderDate = dto.OrderDate;
            order.CustomerName = dto.CustomerName;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
