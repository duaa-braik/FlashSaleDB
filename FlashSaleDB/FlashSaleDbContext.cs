using FlashSaleDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashSaleDB;

public class FlashSaleDbContext: DbContext
{
    public DbSet<User> User { get; set; }

    public DbSet<Cart> Cart { get; set; }

    public DbSet<Product> Product { get; set; }

    public DbSet<Inventory> Inventory { get; set; }

    public DbSet<Sale> Sale { get; set; }

    public DbSet<Reservation> Reservation { get; set; }

    public DbSet<Payment> Payment { get; set; }

    public FlashSaleDbContext(DbContextOptions<FlashSaleDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Carts)
            .WithMany(c => c.Products)
            .UsingEntity<CartItem>(
                r => r.HasOne<Cart>().WithMany().HasForeignKey(e => e.CartId),
                l => l.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId));
        
        modelBuilder.Entity<Inventory>()
            .HasKey(i => new { i.Id, i.ProductId });

        modelBuilder.Entity<Cart>()
            .Property(c => c.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Payment>()
            .Property(p => p.Id)
            .HasMaxLength(36);

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasMaxLength(100);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Category)
            .HasMaxLength(50);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .HasMaxLength(2048);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .HasMaxLength(100);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(100);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasMaxLength(500);
    }
}