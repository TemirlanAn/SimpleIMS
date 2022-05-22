using Microsoft.EntityFrameworkCore;

using SimpleIMS.Data;
using SimpleIMS.Data.Entities;

namespace SimpleIMS.Repositories
{
	public interface IProductRepository
	{
		Task<List<Product>> GetProductsAsync();
		Task<Product?> GetProductByIdAsync(int id);
		Task<Product?> GetProductByNameAsync(string name);
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
	}

	public class ProductRepository : IProductRepository
	{
		private readonly SimpleIMSDbContext _dbContext;

		public ProductRepository(SimpleIMSDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task AddProductAsync(Product product)
		{
			_dbContext.Products.Add(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int id)
		{
			var product = await _dbContext.Products.FindAsync(id);
			if (product != null)
			{
				_dbContext.Products.Remove(product);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<Product?> GetProductByIdAsync(int id)
		{
			return await _dbContext.Products.FindAsync(id);
		}

		public Task<Product?> GetProductByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await _dbContext.Products.Include(p => p.Category).ToListAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			_dbContext.Products.Update(product);
			await _dbContext.SaveChangesAsync();
		}
	}
}
