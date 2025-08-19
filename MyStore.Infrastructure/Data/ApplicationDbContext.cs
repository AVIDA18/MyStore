using Microsoft.EntityFrameworkCore;
using MyStore.Core.Entities;

namespace MyStore.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Cart> Carts{ get; set; }

        //Join tables
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                base.OnModelCreating(modelBuilder);

                //To define the price decimal property
                modelBuilder.Entity<Product>()
                    .Property(p => p.Price)
                    .HasPrecision(18, 2);

                // UserRole
                modelBuilder.Entity<UserRole>()
                    .HasKey(ur => new { ur.UserId, ur.RoleId });

                modelBuilder.Entity<UserRole>()
                    .HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);

                modelBuilder.Entity<UserRole>()
                    .HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                // OrderItem
                modelBuilder.Entity<OrderItem>()
                    .HasKey(oi => new { oi.OrderId, oi.ProductId });

                modelBuilder.Entity<OrderItem>()
                    .HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId);

                modelBuilder.Entity<OrderItem>()
                    .HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId);

                // CartItem
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

                // Seed Roles
                modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, Name = "Admin" },
                    new Role { Id = 2, Name = "Customer" }
                );

                //We will add more relationships as more models are created
            }
        }
    }
}