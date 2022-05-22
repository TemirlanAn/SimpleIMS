using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleIMS.Migrations
{
    public partial class ProductAndCategoryDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7336), "Laptops", new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7337) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7341), "Phones", new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7342), "Accessories", new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7343) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7366), "Asus VivoBook S14 is a Windows 10 Home laptop with a 14.00-inch display that has a resolution of 1920x1080 pixels. It is powered by a Core i5 processor and it comes with 8GB of RAM. The Asus VivoBook S14 packs 128GB of SSD storage. Graphics are powered by Intel Integrated UHD Graphics 620. Connectivity options include Wi-Fi 802.11 ac, Bluetooth and it comes with 4 USB ports (2 x USB 2.0, 1 x USB 3.0), Mic In ports.", "ASUS VivoBook S14", 215000m, 5, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7366) },
                    { 2, 1, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7371), "The most powerful MacBook Pro ever is here. With the blazing-fast M1 Pro or M1 Max chip — the first Apple silicon designed for pros — you get groundbreaking performance and amazing battery life. Add to that a stunning Liquid Retina XDR display, the best camera and audio ever in a Mac notebook, and all the ports you need. The first notebook of its kind, this MacBook Pro is a beast.", "MacBook Pro 16-inch", 1475000m, 3, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7371) },
                    { 3, 1, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7372), "Powered by an Intel® Core™ processor, the Victus by HP 16.1 inch laptop has all the features to handle your gaming and daily needs. Increase your gaming flexibility with an all-purpose gaming keyboard and enjoy a tear-free fast refresh rate display. Power through the heat of every game with a cooling system that prevents overheating. Elevate your gaming experience beyond your hardware with the OMEN Gaming Hub.", "HP Victus 16-e0043ur", 426000m, 10, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7373) },
                    { 4, 2, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7374), "Apple's iPhone 13 features a ceramic shield front, Super Retina XDR display with True Tone and an A15 Bionic chip. The first design change users will notice is the smaller notch. After years of using the same-sized notch to house the Face ID components, Apple has finally reduced its size by 20%.", "iPhone 13", 480000m, 25, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7374) },
                    { 5, 2, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7375), "The Samsung Galaxy S21 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series.", "Samsung Galaxy S21", 300000m, 25, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7375) },
                    { 6, 2, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7378), "Xiaomi Mi 11 smartphone comes with a transparent silicone case, adapter from Type-C to 3.5 mm audio jack, power adapter and charging cable.", "Xiaomi Mi 11", 170000m, 40, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7378) },
                    { 7, 3, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7379), "The AirPods Pro are the more premium version of Apple's standard AirPods. They feature two audio modes for filtering outside sounds, changeable ear tips, and the H1 processor. Gyroscopes in the earpieces enable users to move their head 'around' within an audio space using a feature called Spatial Audio.", "AirPods Pro", 95000m, 30, new DateTime(2022, 5, 22, 10, 31, 37, 769, DateTimeKind.Utc).AddTicks(7380) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
