using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Services
{
    public class ProductServices
    {
        private readonly WebShopDbContext _context;

        public ProductServices(WebShopDbContext context)
        {
            _context = context;
        }
        //Get
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        // Get id alapján
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        //Put id alapján
        public async Task UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Post
        public async Task<Product> AddProductAsycn(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product; //TODO: megkérdezni Balázst?
        }

        //Delete

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}

