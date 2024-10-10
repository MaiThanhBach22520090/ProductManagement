using Microsoft.EntityFrameworkCore;


namespace ProductManagement.Models
{
    public class ProductManagementContext : DbContext
    {

        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Catalog>().ToTable("Catalog");
        }
    }
}
