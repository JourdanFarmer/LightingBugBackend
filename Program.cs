var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    // Define a CORS policy
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Your frontend URL
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Add controller services
builder.Services.AddControllers();

var app = builder.Build();

// Enable CORS
app.UseCors("AllowReactApp");

// Enable routing
app.UseRouting();

// Enable authorization middleware (optional, based on your needs)
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

app.Run();