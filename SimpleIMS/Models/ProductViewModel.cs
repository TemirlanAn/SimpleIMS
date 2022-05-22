using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace SimpleIMS.Models
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(256)]
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		[Required]
		public int Quantity { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; } = string.Empty;

		public SelectList? Categories { get; set; }
	}
}
