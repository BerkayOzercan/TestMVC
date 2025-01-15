using Microsoft.EntityFrameworkCore;
using TestMVC.Models;

namespace TestMVC.Data;

public class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemClient>().HasKey(ic => new
        {
            ic.ItemId,
            ic.ClientId
        }
        );

        modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
        modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);

        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 5, Name = "HeadPhone", Price = 15.0, SerialNumberId = 10 }
        );
        modelBuilder.Entity<SerialNumber>().HasData(
            new SerialNumber { Id = 10, Name = "HP150", ItemId = 5 }
        );
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" }
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<SerialNumber> SerialNumbers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ItemClient> ItemClients { get; set; }
}
