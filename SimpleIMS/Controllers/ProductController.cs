using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using SimpleIMS.Data.Entities;
using SimpleIMS.Models;
using SimpleIMS.Repositories;

namespace SimpleIMS.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productRepository.GetProductsAsync();
			var vm = new ProductListViewModel
			{
				Products = products.Select(x => new ProductViewModel
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Price = x.Price,
					Quantity = x.Quantity,
					CategoryName = x.Category?.Name ?? ""
				})
				.ToList()
			};

			return View(vm);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var categories = await _categoryRepository.GetCategoriesAsync();
			var vm = new ProductViewModel
			{
				Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name))
			};

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductViewModel vm)
		{
			if (!ModelState.IsValid)
				return View(vm);

			var product = new Product
			{
				Id = vm.Id,
				CategoryId = vm.CategoryId,
				Name = vm.Name,
				Description = vm.Description ?? "",
				Price = vm.Price,
				Quantity = vm.Quantity,
			};

			await _productRepository.AddProductAsync(product);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var product = await _productRepository.GetProductByIdAsync(id);
			if (product == null) 
				return NotFound();

			var categories = await _categoryRepository.GetCategoriesAsync();

			var vm = new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				Description = product.Description,
				Quantity = product.Quantity,
				CategoryId = product.CategoryId,
				Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name))
			};

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductViewModel vm)
		{
			if (!ModelState.IsValid) 
				return View(vm);

			var product = new Product
			{
				Id = vm.Id,
				CategoryId = vm.CategoryId,
				Name = vm.Name,
				Description = vm.Description ?? "",
				Price = vm.Price,
				Quantity = vm.Quantity,
				UpdatedAt = DateTime.UtcNow
			};

			await _productRepository.UpdateProductAsync(product);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _productRepository.DeleteProductAsync(id);

			return RedirectToAction("Index");
		}
	}
}
