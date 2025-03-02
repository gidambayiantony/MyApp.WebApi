using Microsoft.EntityFrameworkCore;
using MyApp.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

 

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AffiliateDB"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services before building the application
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:8100","http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Seed Dummy Data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
// Use the CORS policy
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();
app.Run();

 void SeedData(AppDbContext context)
{
    if (!context.Affiliates.Any())
    {
        var affiliate1 = new Affiliate
        {
            Id = "1",
            Username = "JohnAffiliate",
            EmailAddress = "john@example.com",
            Location = "Kisumu",
            PhoneNumber = "+254700112233"
        };

        var affiliate2 = new Affiliate
        {
            Id = "2",
            Username = "AliceAffiliate",
            EmailAddress = "alice@example.com",
            Location = "Eldoret",
            PhoneNumber = "+254799223344"
        };

        var customer1 = new Customer
        {
            Id = 1,
            UserId = "C001",
            Username = "Alex Njoroge",
            PhoneNumber = "+254711223344",
            LastSeen = DateTime.UtcNow,
            DateJoined = DateTime.UtcNow.AddDays(-30),
            AppVersion = "1.0.0",
            Country = "Kenya",
            AffId = affiliate1.Id // Link to Affiliate
        };

        var customer2 = new Customer
        {
            Id = 2,
            UserId = "C002",
            Username = "Anthony Gidambayi",
            PhoneNumber = "+254722334455",
            LastSeen = DateTime.UtcNow.AddDays(-2),
            DateJoined = DateTime.UtcNow.AddDays(-40),
            AppVersion = "1.2.0",
            Country = "Tanzania",
            AffId = affiliate2.Id // Link to Affiliate
        };

         var customer3 = new Customer
        {
            Id = 3,
            UserId = "C002",
            Username = "Maxwell Kishada",
            PhoneNumber = "+254722334455",
            LastSeen = DateTime.UtcNow.AddDays(-2),
            DateJoined = DateTime.UtcNow.AddDays(-40),
            AppVersion = "1.2.0",
            Country = "Tanzania",
            
        };

        var shops = new List<Shop>
        {
            new Shop
            {
                ShopId = 1,
                ShopName = "TechHub Store",
                DaysLeft = 30,
                Location = "Nairobi",
                Attendants = 3,
                DateJoined = DateTime.UtcNow.AddDays(-10),
                LastSeen = DateTime.UtcNow,
                Customer = customer1 // Belongs to JaneDoe
            },
            new Shop
            {
                ShopId = 2,
                ShopName = "Gadget World",
                DaysLeft = 60,
                Location = "Mombasa",
                Attendants = 5,
                DateJoined = DateTime.UtcNow.AddDays(-20),
                LastSeen = DateTime.UtcNow.AddDays(-1),
                Customer = customer1 // Belongs to JaneDoe
            },
            new Shop
            {
                ShopId = 3,
                ShopName = "ElectroMart",
                DaysLeft = 45,
                Location = "Kisumu",
                Attendants = 2,
                DateJoined = DateTime.UtcNow.AddDays(-15),
                LastSeen = DateTime.UtcNow.AddDays(-3),
                Customer = customer2 // Belongs to MikeSmith
            },
              new Shop
            {
                ShopId = 4,
                ShopName = "Kishada Baze",
                DaysLeft = 45,
                Location = "Kisumu",
                Attendants = 2,
                DateJoined = DateTime.UtcNow.AddDays(-15),
                LastSeen = DateTime.UtcNow.AddDays(-3),
                Customer = customer3 // Belongs to MikeSmith
            }
        };

        // Save to DB
        context.Affiliates.AddRange( );
        context.Customers.AddRange( );
        context.Shops.AddRange(shops);
        context.SaveChanges();
    }
}
