using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartServices _cartServices;

        public CartsController(CartServices cartServices)
        {
            _cartServices = cartServices;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> Getcarts()
        {
            return await _cartServices.GetCartAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _cartServices.GetCartByIdAsync(id);

            return cart == null ? cart : NotFound();
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }
            await _cartServices.UpdateCartAsync(cart);
            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Cart cart)
        {
            await _cartServices.AddCartAsycn(cart);
            return CreatedAtAction("GetCustomer", new { id = cart.Id }, cart);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _cartServices.GetCartByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            await _cartServices.DeleteCartAsync(cart);
            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _cartServices.GetCartByIdAsync(id) is not null;
        }
    }
}
