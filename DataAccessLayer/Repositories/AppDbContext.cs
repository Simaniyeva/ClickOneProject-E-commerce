using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<ProductCollection> ProductCollections { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<ProductParameter> ProductParameters { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Favourite> Favourities { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
