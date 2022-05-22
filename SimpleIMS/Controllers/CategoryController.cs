using Microsoft.AspNetCore.Mvc;

using SimpleIMS.Data.Entities;
using SimpleIMS.Models;
using SimpleIMS.Repositories;

namespace SimpleIMS.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IActionResult> Index()
		{
			var categories = await _categoryRepository.GetCategoriesAsync();
			var vm = new CategoryListViewModel
			{
				Categories = categories.Select(s => new CategoryViewModel
				{
					Id = s.Id,
					Name = s.Name,
					ProductByCategory = s.Products?.Count ?? 0
				}).ToList()
			};

			return View(vm);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CategoryViewModel vm)
		{
			if (!ModelState.IsValid)
				return View(vm);

			var category = new Category
			{
				Name = vm.Name
			};
			await _categoryRepository.AddCategoryAsync(category);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var category = _categoryRepository.GetCategoryByIdAsync(id);
			if (category == null)
				return NotFound();

			return View(category);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(CategoryViewModel vm)
		{
			if (!ModelState.IsValid)
				return View(vm);

			var category = new Category
			{
				Id = vm.Id,
				Name = vm.Name
			};
			await _categoryRepository.UpdateCategoryAsync(category);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _categoryRepository.DeleteCategoryAsync(id);


			return RedirectToAction("Index");
		}
	}
}
