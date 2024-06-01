using TodoWeb.Models;

namespace TodoWeb.IServices
{
    public interface ITodoService: IBaseService<TodoDto>
    {
        Task<int> GetCount();
    }
}
