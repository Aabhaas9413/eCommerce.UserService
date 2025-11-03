using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerece.API.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//Add Infrastructure Services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore(builder.Configuration);

// Add controllers and configure JSON to use string enums (disable integer values)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(null, allowIntegerValues: false));
    });

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
