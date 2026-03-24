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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
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
                    ImageUrl = "https://placehold.jp/24/4361ee/ffffff/200x320.png?text=Dac%20Nhan%20Tam"
                },
                new Product
                {
                    Id = 2,
                    Name = "Lược Sử Thời Gian",
                    Price = 125000,
                    Description = "Tìm hiểu về vũ trụ từ vụ nổ Big Bang đến các lỗ đen.",
                    CategoryId = 2,
                    ImageUrl = "https://placehold.jp/24/3f37c9/ffffff/200x320.png?text=Luoc%20Su%20Thoi%20Gian"
                },
                new Product
                {
                    Id = 3,
                    Name = "Thám Tử Lừng Danh Conan - Tập 100",
                    Price = 25000,
                    Description = "Hành trình phá án của cậu bé Shinichi.",
                    CategoryId = 4,
                    ImageUrl = "https://placehold.jp/24/4cc9f0/ffffff/200x320.png?text=Conan%20100"
                }
            );
        }
    }
}
