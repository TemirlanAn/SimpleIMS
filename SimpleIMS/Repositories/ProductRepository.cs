using Microsoft.EntityFrameworkCore;

using SimpleIMS.Data;
using SimpleIMS.Data.Entities;

namespace SimpleIMS.Repositories
{
	public interface IProductRepository
	{
		Task<List<Product>> GetProductsAsync();
		Task<Product> GetProductByIdAsync(int id);
		Task<Product> GetProductByNameAsync(string name);
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
		public Task AddProductAsync(Product product)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProductAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetProductByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetProductByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await _dbContext.Products.Include(p => p.Category).ToListAsync();
		}

		public Task UpdateProductAsync(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
