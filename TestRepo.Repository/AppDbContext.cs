using Microsoft.EntityFrameworkCore;
using TestRepo.Repository.Enity;

namespace TestRepo.Repository;

public class AppDbContext : DbContext
{
    public static Guid UserId1 = Guid.NewGuid();
    public static Guid UserId2 = Guid.NewGuid();
    public static Guid SellerId1 = Guid.NewGuid();
    public static Guid ParentCategoryId1 = Guid.NewGuid();
    public static Guid ParentCategoryId2 = Guid.NewGuid();
    public static Guid ProductId1 = Guid.NewGuid();
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

     public DbSet<User> Users { get; set; }
     public DbSet<Product> Products { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasOne(u => u.Seller)
                .WithOne(s => s.User)
                .HasForeignKey<Seller>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            var user = new List<User>()
            {
                new()
                {
                    Id = UserId1,
                    Email = "Anhpham@gmai.com",
                    Password = "password"
                },
                new()
                {
                    Id = UserId2,
                    Email = "Anhpham123@gmai.com",
                    Password = "password"
                }
            };
            builder.HasData(user);
        });
        modelBuilder.Entity<Product>(builder =>
            {
                builder.HasOne(p => p.Seller)
                    .WithMany(s => s.Products)
                    .HasForeignKey(s => s.SellerId)
                    .OnDelete(DeleteBehavior.Cascade);
                var product = new List<Product>()
                {
                    new()
                    {
                        Id = ProductId1,
                        Name = "Product1",
                        Price = 12435m,
                        SellerId = SellerId1
                    },

                };
                builder.HasData(product);
            }
        );
        modelBuilder.Entity<Category>(builder =>
        {
            var category = new List<Category>()
            {
                new()
                {
                    Id = ParentCategoryId1,
                    Name = "Áo",

                },
                new()
                {
                    Id = ParentCategoryId2,
                    Name = "Qần",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Áo 3 lo",
                    ParentId = ParentCategoryId1,
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Quần 3 lo",
                    ParentId = ParentCategoryId2,
                }

            };
            builder.HasData(category);
        });
        modelBuilder.Entity<Seller>(builder =>
        {
            var seller = new List<Seller>()
            {
                new()
                {
                    Id = SellerId1,
                    TaxCode = "taxcode",
                    CompanyName = "CompanyName",
                    CompanyAddress = "CompanyAddress",
                    UserId = UserId1,
                }
            };
            builder.HasData(seller);
        });

    }
}