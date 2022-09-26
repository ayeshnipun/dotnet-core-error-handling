using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProductsAsync();
        Guid SaveProductAsync(Product product);

    }
}
