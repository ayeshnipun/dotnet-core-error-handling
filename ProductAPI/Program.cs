using ProductAPI.EndPoints;
using ProductAPI.Middleware;
using ProductAPI.Services;
using ProductAPI.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddScoped<EndPointsWithDI>();

// remove default logging providers
builder.Logging.ClearProviders();
// Serilog configuration        
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
// Register Serilog
builder.Logging.AddSerilog(logger);

var app = builder.Build();

//Error handling
app.UseMiddleware<CustomExceptionHandlingMiddleware>(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider.GetService<EndPointsWithDI>();
    service.GetProducts(app);
    service.GetProductByCategory(app);
    service.SaveProduct(app);
}

app.Run();
