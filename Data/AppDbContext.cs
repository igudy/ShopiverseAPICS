using shopiversecs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace shopiversecs.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Add DbSet for other entities here
        public DbSet<ProductAPIModel> Products { get; set; }
    }
}