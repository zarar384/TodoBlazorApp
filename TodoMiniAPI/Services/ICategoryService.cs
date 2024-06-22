using TodoMiniAPI.Models;

namespace TodoMiniAPI.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> UpdateCategoriesAsync(List<Category> categories, Type type);
    }
}
