using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerece.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add Infrastructure Services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore(builder.Configuration);

// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use exception handling middleware
app.UseExceptionHandlingMiddleware();

// Enable middleware to serve generated Swagger as a JSON endpoint and the Swagger UI (in Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
