using Microsoft.EntityFrameworkCore;
using MyMvc.Models;

namespace MyMvc.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 50, Name="Mouse",
                    Price=14, SerialNumberId=10
                }
                );
            modelBuilder.Entity<SerialNumber>().HasData(
             new SerialNumber
             {
                 Id = 10,
                 Name = "MIC150",
                 ItemId=50
             }
             );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics"

                }, new Category
                {
                    Id = 2,
                    Name = "Books"
                }

                );
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId, ic.ClientId
            });
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic=>ic.ItemClients).HasForeignKey(i=>i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);
            base.OnModelCreating(modelBuilder);
        }
           }
}

