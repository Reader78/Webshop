using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CustomerServices
    {
        private readonly WebShopDbContext _webShopDbContext;

        public CustomerServices(WebShopDbContext webShopDbContext)
        {
            _webShopDbContext = webShopDbContext;
        }
        //Get
        public async Task<List<Customer>> GetCustmersAsync()
        {
            return await _webShopDbContext.Customer.ToListAsync();
        }
        // Get id alapján
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _webShopDbContext.Customer.FindAsync(id);
        }
        //Put id alapján
        public async Task UpdateCustomerAsync(Customer customer)
        {
            _webShopDbContext.Entry(customer).State = EntityState.Modified;
            await _webShopDbContext.SaveChangesAsync();
        }

        //Post
        public async Task<Customer> AddCustomerAsycn(Customer customer)
        {
            _webShopDbContext.Customer.Add(customer);
            await _webShopDbContext.SaveChangesAsync();

            return customer; //TODO: megkérdezni Balázst?
        }

        //Delete

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _webShopDbContext.Customer.Remove(customer);
            await _webShopDbContext.SaveChangesAsync();
        }
    }
}
