using Identity.API.Entity;
using Identity.API.Entity.Customer;
using Identity.API.Entity.Seller;
using Microsoft.EntityFrameworkCore;
using Qaysar.Shared.Entity.DeliveryManEntity;

namespace Identity.API.Data
{
    public sealed class DataContext : DbContext
    {
#pragma warning disable CS8618
        public DataContext(DbContextOptions<DataContext> options) : base(options)
#pragma warning restore CS8618
        {
            Database.EnsureCreated(); // создаем бд с новой схемой
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
