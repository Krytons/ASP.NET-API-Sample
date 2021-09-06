using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId); //Makes ProductId primary key
                entity.Property(e => e.Name).IsRequired(); //Makes Name required
                entity.Property(e => e.Price).IsRequired(); //Makes Price required
            });

        }
    }
}
