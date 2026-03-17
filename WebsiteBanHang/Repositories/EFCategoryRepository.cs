using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Data;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories.Interfaces;

namespace WebsiteBanHang.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
