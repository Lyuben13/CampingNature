using MVC.Intro.Models;

namespace MVC.Intro.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductById(Guid id);
        Product AddProduct(Product product);
        bool DeleteProduct(Guid id);
        bool UpdateProduct(Product product);
    }
}
