using System.Linq.Expressions;
using FlashSaleDB.Entities;
using FlashSaleDB.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

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
        modelBuilder.Entity<CartItem>()
            .HasKey(ci => new { ci.CartId, ci.ProductId });

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(ci => ci.ProductId);
        
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Inventory)
            .WithOne(i => i.Product)
            .HasForeignKey<Inventory>(i => i.ProductId);
        
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
            .Property(u => u.PasswordHash)
            .HasMaxLength(500);

        configurePropertyGenerator<User, Guid, UuidGenerator>(modelBuilder, e => e.Id);
        
        configurePropertyGenerator<Cart, Guid, UuidGenerator>(modelBuilder, e => e.Id);
        
        configurePropertyGenerator<Order, Guid, UuidGenerator>(modelBuilder, e => e.Id);
        
        configurePropertyGenerator<Payment, Guid, UuidGenerator>(modelBuilder, e => e.Id);
        
        configurePropertyGenerator<Product, Guid, UuidGenerator>(modelBuilder, e => e.Id);
        
        configurePropertyGenerator<Order, Guid, UuidGenerator>(modelBuilder, e => e.Id);
        
        configurePropertyGenerator<User, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Cart, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Inventory, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Order, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Payment, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Product, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Reservation, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
        
        configurePropertyGenerator<Sale, DateTime, TimestampGenerator>(modelBuilder, e => e.CreatedAt);
    }
    
    private static void configurePropertyGenerator<TEntity,TProperty, TGenerator>(ModelBuilder modelBuilder, Expression<Func<TEntity,TProperty>> property)
        where TEntity : class where TGenerator : ValueGenerator
    {
        modelBuilder.Entity<TEntity>()
            .Property(property)
            .HasValueGenerator<TGenerator>()
            .ValueGeneratedOnAdd();
    }
}