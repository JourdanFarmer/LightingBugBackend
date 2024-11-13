var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Add controller services
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable CORS
app.UseCors("AllowReactApp");

// Enable serving static files
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable Swagger middleware if in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        // Optionally, serve Swagger UI at the application's root:
        c.RoutePrefix = string.Empty; // This makes Swagger UI served at the app's root URL
    });
}

// Enable authorization middleware (optional, based on your needs)
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

app.Run("http://localhost:5000");