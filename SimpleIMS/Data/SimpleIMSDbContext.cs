using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

			// Data seed
			modelBuilder.Entity<Category>()
				.HasData(new List<Category>
				{
					new Category { Id = 1, Name = "Laptops" },
					new Category { Id = 2, Name = "Phones" },
					new Category { Id = 3, Name = "Accessories" }
				});

			modelBuilder.Entity<Product>()
				.HasData(new List<Product>
				{
					new Product { Id = 1, CategoryId = 1, Name = "ASUS VivoBook S14", Description = "Asus VivoBook S14 is a Windows 10 Home laptop with a 14.00-inch display that has a resolution of 1920x1080 pixels. It is powered by a Core i5 processor and it comes with 8GB of RAM. The Asus VivoBook S14 packs 128GB of SSD storage. Graphics are powered by Intel Integrated UHD Graphics 620. Connectivity options include Wi-Fi 802.11 ac, Bluetooth and it comes with 4 USB ports (2 x USB 2.0, 1 x USB 3.0), Mic In ports.", Quantity = 5, Price = 215000 },
					new Product { Id = 2, CategoryId = 1, Name = "MacBook Pro 16-inch", Description = "The most powerful MacBook Pro ever is here. With the blazing-fast M1 Pro or M1 Max chip — the first Apple silicon designed for pros — you get groundbreaking performance and amazing battery life. Add to that a stunning Liquid Retina XDR display, the best camera and audio ever in a Mac notebook, and all the ports you need. The first notebook of its kind, this MacBook Pro is a beast.", Quantity = 3, Price = 1475000 },
					new Product { Id = 3, CategoryId = 1, Name = "HP Victus 16-e0043ur", Description = "Powered by an Intel® Core™ processor, the Victus by HP 16.1 inch laptop has all the features to handle your gaming and daily needs. Increase your gaming flexibility with an all-purpose gaming keyboard and enjoy a tear-free fast refresh rate display. Power through the heat of every game with a cooling system that prevents overheating. Elevate your gaming experience beyond your hardware with the OMEN Gaming Hub.", Quantity = 10, Price = 426000 },
					new Product { Id = 4, CategoryId = 2, Name = "iPhone 13", Description = "Apple's iPhone 13 features a ceramic shield front, Super Retina XDR display with True Tone and an A15 Bionic chip. The first design change users will notice is the smaller notch. After years of using the same-sized notch to house the Face ID components, Apple has finally reduced its size by 20%.", Quantity = 25, Price = 480000 },
					new Product { Id = 5, CategoryId = 2, Name = "Samsung Galaxy S21", Description = "The Samsung Galaxy S21 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series.", Quantity = 25, Price = 300000 },
					new Product { Id = 6, CategoryId = 2, Name = "Xiaomi Mi 11", Description = "Xiaomi Mi 11 smartphone comes with a transparent silicone case, adapter from Type-C to 3.5 mm audio jack, power adapter and charging cable.", Quantity = 40, Price = 170000 },
					new Product { Id = 7, CategoryId = 3, Name = "AirPods Pro", Description = "The AirPods Pro are the more premium version of Apple's standard AirPods. They feature two audio modes for filtering outside sounds, changeable ear tips, and the H1 processor. Gyroscopes in the earpieces enable users to move their head 'around' within an audio space using a feature called Spatial Audio.", Quantity = 30, Price = 95000 }
				});

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
