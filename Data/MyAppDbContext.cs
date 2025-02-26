using Microsoft.EntityFrameworkCore;
using MyApp.WebApi.Models;

public class AppDbContext : DbContext
{
    public DbSet<Affiliate> Affiliates { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Shop> Shops { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>()
            .HasOne(s => s.Customer)
            .WithMany(c => c.Shops)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Affiliate)
            .WithMany(a => a.Customers)
            .HasForeignKey(c => c.AffId);
    }
}
