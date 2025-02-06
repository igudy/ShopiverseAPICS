using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shopiversecs.Models;
using ProductAPI.Models;
using CategoryAPI.Models;

namespace shopiversecs.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Add DbSet for other entities(Models) here
        public DbSet<ProductAPIModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        // Cascading delete
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the one-to-many relationship
            modelBuilder.Entity<ProductAPIModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Ensures cascading delete
        }
    }
}
