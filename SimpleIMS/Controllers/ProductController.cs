using Microsoft.AspNetCore.Mvc;

using SimpleIMS.Models;
using SimpleIMS.Repositories;

namespace SimpleIMS.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
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
				})
				.ToList()
			};

			return View(vm);
		}
	}
}
