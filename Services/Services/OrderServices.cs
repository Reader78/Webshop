using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OrderServices
    {
        private readonly WebShopDbContext _context;

        public OrderServices(WebShopDbContext context)
        {
            _context = context;
        }
        //Get
        public async Task<List<Order>> GetOrderAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        // Get id alapján
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
        //Put id alapján
        public async Task UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Post
        public async Task<Order> AddOrderAsycn(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order; //TODO: megkérdezni Balázst?
        }

        //Delete

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
