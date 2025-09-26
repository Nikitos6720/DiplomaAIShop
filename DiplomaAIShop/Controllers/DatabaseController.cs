using DiplomaAIShop.Models;

using Microsoft.EntityFrameworkCore;

namespace DiplomaAIShop.Controllers;

public class DatabaseController : DbContext, IDisposable
{
    public DbSet<ProductCategory>? Categories { get; set; }
    
    public DbSet<Product>? Products { get; set; }
    
    public DbSet<Check>? Checks { get; set; }
    
    public DbSet<CheckLine> Lines { get; set; }

    public DbSet<SellsHistory> Sales { get; set; }

    public DatabaseController(DbContextOptions<DatabaseController> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=shop.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>()
            .HasMany(c => c.Products)
            .WithOne(p => p.ProductCategory)
            .HasForeignKey(p => p.ProductCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Sales)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Check>()
            .HasMany(c => c.Lines)
            .WithOne(l => l.Check)
            .HasForeignKey(l => l.CheckId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Check>()
            .HasOne(c => c.History)
            .WithMany(s => s.Checks)
            .HasForeignKey(c => c.SellsHistoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SellsHistory>()
            .Property(s => s.Date)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Check>()
            .Property(c => c.Date)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        base.OnModelCreating(modelBuilder);
    }
}