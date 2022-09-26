using Newtonsoft.Json;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.EndPoints
{
    public class EndPointsWithDI
    {
        private readonly ILogger<EndPointsWithDI> _logger;
        private readonly IProductService _productService;

        public EndPointsWithDI(ILogger<EndPointsWithDI> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void GetProducts(WebApplication app)
        {
            app.MapGet("/GetProducts", () =>
            {
                _logger.LogInformation("Starting the API Call GetProducts");
                var products = _productService.GetProductsAsync();

                _logger.LogInformation("Received products {Response}", JsonConvert.SerializeObject(products));
                return products;
            }).WithName("GetProducts");
        }

        public void SaveProduct(WebApplication app)
        {
            app.MapPost("/SaveProduct", (Product product) =>
            {
                _logger.LogInformation("Starting the API Call SaveProduct");
                var id = _productService.SaveProductAsync(product);

                _logger.LogInformation("Received result {Response}", JsonConvert.SerializeObject(id));
                return id;
            }).WithName("SaveProduct");
        }
    }
}