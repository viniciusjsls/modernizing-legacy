using LegacyModernization.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace LegacyModernization.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(resource =>
            {
                resource.ToTable("orders", "public").HasKey(a => a.Id);

                resource.HasMany(x => x.Items)
                    .WithOne()
                    .HasForeignKey(x => x.OrderId);
            });

            modelBuilder.Entity<OrderItem>(resource =>
            {
                resource.ToTable("order_items", "public").HasKey(a => a.Id);
            });
        }
    }
}
