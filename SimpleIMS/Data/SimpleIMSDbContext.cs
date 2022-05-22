using Microsoft.EntityFrameworkCore;

using SimpleIMS.Data.Entities;

namespace SimpleIMS.Data
{
	public class SimpleIMSDbContext : DbContext
	{
		public SimpleIMSDbContext(DbContextOptions<SimpleIMSDbContext> options) 
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasKey(p => p.Id);

			modelBuilder.Entity<Product>()
				.Property(p => p.Name)
				.HasColumnType("nvarchar(256)");

			modelBuilder.Entity<Category>()
				.HasKey(p => p.Id);

			modelBuilder.Entity<Category>()
				.HasMany(p => p.Products)
				.WithOne(p => p.Category);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
