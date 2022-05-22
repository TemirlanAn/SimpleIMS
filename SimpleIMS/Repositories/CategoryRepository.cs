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

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _dbContext.Categories.FindAsync(id);
			if (category is not null)
			{
				_dbContext.Categories.Remove(category);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<Category>> GetCategoriesAsync()
		{
			return await _dbContext.Categories.Include(p => p.Products).ToListAsync();
		}

		public async Task<Category?> GetCategoryByIdAsync(int id)
		{
			return await _dbContext.Categories.FindAsync(id);
		}

		public async Task UpdateCategoryAsync(Category category)
		{
			_dbContext.Update(category);
			await _dbContext.SaveChangesAsync();
		}
	}
}
