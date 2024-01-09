using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Database
{
    public class DatabaseContext : DbContext
    {
        private IConfiguration _config;

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        static DatabaseContext()
        {
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DatabaseContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {    
            optionsBuilder
            .AddInterceptors(new TimestampInterceptor())
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .UseSnakeCaseNamingConvention(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Role>();
            modelBuilder.Entity<OrderDetail>().HasKey("ProductId", "OrderId");

            modelBuilder.Entity<User>(e =>
            {
                e.HasData(SeedingData.GetUsers());
            });

            modelBuilder.Entity<ProductSize>(e =>
            {
                e.HasIndex(e => e.Value).IsUnique();
            });

            modelBuilder.Entity<ProductColor>(e =>
            {
                e.HasIndex(e => e.Value).IsUnique();
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<ProductLine>(e =>
            {
                e.HasIndex(e => e.Title).IsUnique();
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasIndex(e => new { e.ProductLineId, e.ColorId, e.SizeId }).IsUnique();
            });

            /* Seeding the database */
            modelBuilder.Entity<User>().HasData(SeedingData.GetUsers());
            modelBuilder.Entity<ProductColor>().HasData(SeedingData.GetProductColors());
            modelBuilder.Entity<ProductSize>().HasData(SeedingData.GetProductSizes());
            modelBuilder.Entity<Category>().HasData(SeedingData.GetCategories());
            modelBuilder.Entity<ProductLine>().HasData(SeedingData.GetProductLines());
            modelBuilder.Entity<Image>().HasData(SeedingData.GetImages());
            modelBuilder.Entity<Product>().HasData(SeedingData.GetProducts());

        }
    }
}