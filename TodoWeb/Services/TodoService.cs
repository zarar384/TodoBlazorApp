using System.Net.Http.Json;
using TodoWeb.IServices;
using TodoWeb.Models;

namespace TodoWeb.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TodoService> _logger;

        public TodoService(HttpClient httpClient, ILogger<TodoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<TodoDto> CreateAsync(TodoDto dto)
        {
            try
            {
                _logger.LogInformation("Adding a new todo item to API.");
                var response = await _httpClient.PostAsJsonAsync("api/todos", dto);

                response.EnsureSuccessStatusCode();

                var createdTodo = await response.Content.ReadFromJsonAsync<TodoDto>();
                return createdTodo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new todo item.");

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting todo item with ID {0} from API.", id);
                var response = await _httpClient.DeleteAsync($"api/todos/{id}");

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting todo item with ID {0}.", id);

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all todo items from API.");
                var todos = await _httpClient.GetFromJsonAsync<List<TodoDto>>("api/todos");

                return todos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching todo items.");

                throw new Exception(ex.Message);
            }
        }

        public async Task<TodoDto> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching todo item with ID {0} from API.", id);
                var todo = await _httpClient.GetFromJsonAsync<TodoDto>($"api/todos/{id}");

                return todo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching todo item with ID {0}.", id);

                throw new Exception(ex.Message);
            }
        }

        public async Task<TodoDto> UpdateAsync(int id, TodoDto dto)
        {
            try
            {
                _logger.LogInformation("Updating todo item with ID {0} in API.", id);
                var response = await _httpClient.PutAsJsonAsync($"api/todos/{id}", dto);

                response.EnsureSuccessStatusCode();

                var updatedTodoItem = await response.Content.ReadFromJsonAsync<TodoDto>();
                return updatedTodoItem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating todo item with ID {0}.", id);

                throw new Exception(ex.Message);
            }
        }
    }
}
