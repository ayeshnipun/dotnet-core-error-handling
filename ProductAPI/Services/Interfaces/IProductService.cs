using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProductsAsync();
        IEnumerable<Product> GetProductByCategoryAsync(string category);
        Guid SaveProductAsync(Product product);

    }
}
