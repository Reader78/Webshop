using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderServices _orderServices;

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _orderServices.GetOrderAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderServices.GetOrderByIdAsync(id);

            return order == null ? order : NotFound();
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            await _orderServices.UpdateOrderAsync(order);
            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _orderServices.AddOrderAsycn(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderServices.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderServices.GetOrderByIdAsync(order.Id);
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _orderServices.GetOrderByIdAsync(id) is not null;
        }
    }
}
