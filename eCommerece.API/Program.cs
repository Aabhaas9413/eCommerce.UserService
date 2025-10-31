using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerece.API.Middleware;

var builder = WebApplication.CreateBuilder(args);


//Add Infrastructure Services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore(builder.Configuration);

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
