using MVC.Intro.Data;
using MVC.Intro.Models;

namespace MVC.Intro.Services
{
    public class ProductService : IProductService
    {
        private const string ProductPrefix = "PRD_";
        private readonly ILogger<ProductService> _logger;
        private readonly AppDbContext _context;

        public ProductService(ILogger<ProductService> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Product? GetProductById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            var toAdd = new Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
                ImagePath = product.ImagePath
            };

            if (!toAdd.Name.StartsWith(ProductPrefix, StringComparison.Ordinal))
            {
                DecorateProductName(toAdd);
            }

            _logger.LogInformation("Adding product: {ProductName} with price {ProductPrice}", toAdd.Name, toAdd.Price);
            _context.Products.Add(toAdd);
            _context.SaveChanges();
            return toAdd;
        }

        public bool DeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                existingProduct.ImagePath = product.ImagePath;
            }

            _context.SaveChanges();
            return true;
        }

        private static void DecorateProductName(Product product)
        {
            product.Name = ProductPrefix + product.Name;
        }
    }
}
