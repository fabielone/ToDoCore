using Microsoft.EntityFrameworkCore;
using TodoListCore.Models; // Replace YourNamespace with the actual namespace of your project where the AppDbContext class is located.



var builder = WebApplication.CreateBuilder(args);

// Add the DbContext configuration here
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    {
        var sqlConnectionStringBuilder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(connectionString)
        {
            Encrypt = false,
            TrustServerCertificate = true
        };

        connectionString = sqlConnectionStringBuilder.ConnectionString;
    }

    options.UseSqlServer(connectionString);
});


// Add the controllers
builder.Services.AddControllers();

var app = builder.Build();

// Map the controllers
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();