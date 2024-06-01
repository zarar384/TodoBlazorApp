
using TodoWeb.Helpers;

namespace TodoWeb.IServices
{
    public interface IBaseService<TDto>
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task<TDto> UpdateAsync(int id, TDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
