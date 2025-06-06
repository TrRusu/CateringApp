using CateringApp;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var connectionString =
            "server= <IP>; port=<port>; database=catering-dev; user=diversiteam; password=<Password>; Persist Security Info=False;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemIngredient> ItemIngredients { get; set; }
    public DbSet<ItemOrder> ItemOrders { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Table> Tables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemIngredient>()
            .HasKey(ii => new {ii.ItemId, ii.IngredientId});
        modelBuilder.Entity<ItemIngredient>()
            .HasOne(i => i.Item)
            .WithMany(ii => ii.ItemIngredients)
            .HasForeignKey(i => i.ItemId);
        modelBuilder.Entity<ItemIngredient>()
            .HasOne(i => i.Ingredient)
            .WithMany(ii => ii.ItemIngredients)
            .HasForeignKey(i => i.IngredientId);

        modelBuilder.Entity<ItemOrder>()
            .HasKey(io => new {io.ItemId, io.OrderId});
        modelBuilder.Entity<ItemOrder>()
            .HasOne(i => i.Item)
            .WithMany(io => io.ItemOrders)
            .HasForeignKey(i => i.ItemId);
        modelBuilder.Entity<ItemOrder>()
            .HasOne(i => i.Order)
            .WithMany(io => io.ItemOrders)
            .HasForeignKey(o => o.OrderId);

        modelBuilder.Entity<Session>()
            .HasIndex(s => s.TableId).IsUnique(false);
    }
}