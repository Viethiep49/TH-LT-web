using WebsiteBanHang.Models;
namespace WebsiteBanHang.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
