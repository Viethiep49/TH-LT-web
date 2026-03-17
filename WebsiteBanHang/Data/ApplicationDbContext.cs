using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sách Văn Học" },
                new Category { Id = 2, Name = "Sách Khoa Học" },
                new Category { Id = 3, Name = "Sách Giáo Khoa" },
                new Category { Id = 4, Name = "Truyện Tranh" },
                new Category { Id = 5, Name = "Kinh Tế" }
            );

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Đắc Nhân Tâm",
                    Price = 85000,
                    Description = "Cuốn sách hay nhất mọi thời đại về nghệ thuật giao tiếp.",
                    CategoryId = 1,
                    ImageUrl = "https://m.media-amazon.com/images/I/71X8k8-A-hL._AC_UF1000,1000_QL80_.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Lược Sử Thời Gian",
                    Price = 125000,
                    Description = "Tìm hiểu về vũ trụ từ vụ nổ Big Bang đến các lỗ đen.",
                    CategoryId = 2,
                    ImageUrl = "https://m.media-amazon.com/images/I/81S6-n-8K5L._AC_UF1000,1000_QL80_.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Thám Tử Lừng Danh Conan - Tập 100",
                    Price = 25000,
                    Description = "Hành trình phá án của cậu bé Shinichi.",
                    CategoryId = 4,
                    ImageUrl = "https://product.hstatic.net/200000343865/product/100_072df29c782b4923bd09f90be0543f30.jpg"
                }
            );
        }
    }
}
