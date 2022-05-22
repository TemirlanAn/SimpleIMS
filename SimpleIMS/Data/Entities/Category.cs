﻿namespace SimpleIMS.Data.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		public ICollection<Product>? Products { get; set; }
	}
}
