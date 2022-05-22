using Microsoft.EntityFrameworkCore;

using SimpleIMS.Data;
using SimpleIMS.Data.Entities;

namespace SimpleIMS.Repositories
{
	public interface ICategoryRepository
	{
		Task<List<Category>> GetCategoriesAsync();
		Task<Category?> GetCategoryByIdAsync(int id);
		Task AddCategoryAsync(Category product);
		Task UpdateCategoryAsync(Category product);
		Task DeleteCategoryAsync(int id);
	}

	public class CategoryRepository : ICategoryRepository
	{
		private readonly SimpleIMSDbContext _dbContext;

		public CategoryRepository(SimpleIMSDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task AddCategoryAsync(Category product)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCategoryAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Category>> GetCategoriesAsync()
		{
			return await _dbContext.Categories.ToListAsync();
		}

		public Task<Category?> GetCategoryByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateCategoryAsync(Category product)
		{
			throw new NotImplementedException();
		}
	}
}
