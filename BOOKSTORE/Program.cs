using BOOKSTORE.Contexts;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using BOOKSTORE;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    options.UseInMemoryDatabase("BookStoreDb");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<BookStoreDbContext>();

        // Ensure the database is created
        context.Database.EnsureCreated();

        
        if (!context.Books.Any())
        {
            DataGenerator.Initialize(services);
        }
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
