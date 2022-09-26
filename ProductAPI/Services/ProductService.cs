using Newtonsoft.Json;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public List<Product> GetProductsAsync()
        {
            _logger.LogInformation("Starting the service class method Call GetProductsAsync");
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "N1", Description = "D1", Price = 1},
                new Product { Id = 2, Name = "N2", Description = "D2", Price = 2},
                new Product { Id = 3, Name = "N3", Description = "D3", Price = 3},
                new Product { Id = 4, Name = "N4", Description = "D4", Price = 4},
                new Product { Id = 5, Name = "N5", Description = "D5", Price = 5},
                new Product { Id = 6, Name = "N6", Description = "D6", Price = 6},
                new Product { Id = 7, Name = "N7", Description = "D7", Price = 7},
                new Product { Id = 8, Name = "N8", Description = "D8", Price = 8},
                new Product { Id = 9, Name = "N9", Description = "D9", Price = 9},
            };

            _logger.LogInformation("Generated products {Response}", JsonConvert.SerializeObject(products));
            _logger.LogInformation("Completed the service class method Call GetProductsAsync");
            return products;
        }

        public Guid SaveProductAsync(Product product)
        {
            _logger.LogInformation("Starting the service class method Call SaveProductAsync");
            var productId = Guid.NewGuid();

            _logger.LogInformation("Generated product ID {Response}", JsonConvert.SerializeObject(productId));
            _logger.LogInformation("Completed the service class method Call SaveProductAsync");
            return productId;
        }
    }
}