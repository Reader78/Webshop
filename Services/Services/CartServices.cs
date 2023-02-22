using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CartServices
    {
        private readonly WebShopDbContext _webShopDbContext;

        public CartServices(WebShopDbContext webShopDbContext)
        {
            _webShopDbContext = webShopDbContext;
        }

        public async Task<List<Cart>> GetCartAsync()
        {
            return await _webShopDbContext.Carts.ToListAsync();
        }

        public async Task<Cart?> GetCartByIdAsync(int id)
        {
            return await _webShopDbContext.Carts.FindAsync(id);
        }
        //Put id alapján
        public async Task UpdateCartAsync(Cart cart)
        {
            _webShopDbContext.Entry(cart).State = EntityState.Modified;
            await _webShopDbContext.SaveChangesAsync();
        }

        //Post
        public async Task<Cart> AddCartAsycn(Cart cart)
        {
            _webShopDbContext.Carts.Add(cart);
            await _webShopDbContext.SaveChangesAsync();

            return cart; //TODO: megkérdezni Balázst?
        }

        //Delete

        public async Task DeleteCartAsync(Cart cart)
        {
            _webShopDbContext.Carts.Remove(cart);
            await _webShopDbContext.SaveChangesAsync();
        }

    }

}
