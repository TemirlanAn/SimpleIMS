namespace SimpleIMS.Data.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public Category? Category { get; set; }
	}
}
