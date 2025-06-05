using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMS.Data;
using GiftelleCMS.Models;
using GiftelleCMS.DTOs;

namespace GiftelleCMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly GiftelleDbContext _context;

        public OrderItemController(GiftelleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDTO>>> GetOrderItems()
        {
            return await _context.OrderItems
                .Select(oi => new OrderItemDTO
                {
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToListAsync();
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItem(int orderId, int productId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderId, productId);
            if (orderItem == null)
                return NotFound();

            return new OrderItemDTO
            {
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDTO>> CreateOrderItem(OrderItemDTO dto)
        {
            var orderItem = new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderItem), new { orderId = dto.OrderId, productId = dto.ProductId }, dto);
        }

        [HttpPut("{orderId}/{productId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderId, int productId, OrderItemDTO dto)
        {
            if (orderId != dto.OrderId || productId != dto.ProductId)
                return BadRequest();

            var orderItem = await _context.OrderItems.FindAsync(orderId, productId);
            if (orderItem == null)
                return NotFound();

            orderItem.Quantity = dto.Quantity;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderId, int productId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderId, productId);
            if (orderItem == null)
                return NotFound();

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
