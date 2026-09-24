using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using MVC.Intro.Data;
using MVC.Intro.Models;
using MVC.Intro.Services;

namespace MVC.Intro.Tests
{
    public class ProductServiceTests
    {
        private static ProductService CreateService(string databaseName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            var context = new AppDbContext(options);
            return new ProductService(NullLogger<ProductService>.Instance, context);
        }

        [Fact]
        public void AddProduct_WithValidProduct_ShouldPrefixNameAndPersist()
        {
            var service = CreateService(nameof(AddProduct_WithValidProduct_ShouldPrefixNameAndPersist));
            var product = new Product
            {
                Name = "Test Product",
                Price = 100.00m
            };

            var added = service.AddProduct(product);
            var retrieved = service.GetProductById(added.Id);

            Assert.NotNull(retrieved);
            Assert.Equal("PRD_Test Product", retrieved!.Name);
            Assert.Equal(product.Price, retrieved.Price);
        }

        [Fact]
        public void GetProductById_WhenMissing_ReturnsNull()
        {
            var service = CreateService(nameof(GetProductById_WhenMissing_ReturnsNull));

            var result = service.GetProductById(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public void UpdateProduct_ChangesPrice()
        {
            var service = CreateService(nameof(UpdateProduct_ChangesPrice));
            var added = service.AddProduct(new Product { Name = "Tent", Price = 50m });

            added.Price = 80m;
            var updated = service.UpdateProduct(added);

            Assert.True(updated);
            Assert.Equal(80m, service.GetProductById(added.Id)!.Price);
        }

        [Fact]
        public void DeleteProduct_RemovesItem()
        {
            var service = CreateService(nameof(DeleteProduct_RemovesItem));
            var added = service.AddProduct(new Product { Name = "Tent", Price = 50m });

            var deleted = service.DeleteProduct(added.Id);

            Assert.True(deleted);
            Assert.Null(service.GetProductById(added.Id));
        }
    }
}
