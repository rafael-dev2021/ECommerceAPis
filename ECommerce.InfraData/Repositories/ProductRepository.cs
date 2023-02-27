using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.InfraData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _appDbContext.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            //voltar para alterar SingleOrDefaultAsync();
            return await _appDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetFavoritesAsync()
        {
            return await _appDbContext.Products.
                Where(x => x.Favorite).
                Include(x => x.Category).
                ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _appDbContext.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _appDbContext.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _appDbContext.Update(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }
    }
}
