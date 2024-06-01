using System.Net.Http.Json;
using TodoWeb.Extensions;
using TodoWeb.Helpers;
using TodoWeb.IServices;
using TodoWeb.Models;

namespace TodoWeb.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TodoService> _logger;
        private readonly HttpClient _client;

        public TodoService(IHttpClientFactory httpClientFactory, ILogger<TodoService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("TodoMiniApiService"); 
            _logger = logger;
        }

        public async Task<TodoDto> CreateAsync(TodoDto dto)
        {
            try
            {
                _logger.LogInformation("Adding a new todo item to API.");
                var response = await _httpClient.PostAsJsonAsync("/todoitems", dto);

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
                var response = await _httpClient.DeleteAsync($"/todoitems/{id}");

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting todo item with ID {0}.", id);

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TodoDto>> GetTodoAsync(int pageIndex, int pageSize)
        {
            try
            {
                _logger.LogInformation("Fetching todo items from API. Page Index: {0}, Page Size: {1}", pageIndex, pageSize);

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/todoitems");
                
                HttpExtensions.AddPaginationHeader(requestMessage, new PaginationHeader(pageIndex, pageSize));

                var response = await _httpClient.SendAsync(requestMessage);

                response.EnsureSuccessStatusCode();

                var todos = await response.Content.ReadFromJsonAsync<List<TodoDto>>();

                return todos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching todo items.Page Index: {0}, Page Size: {1}", pageIndex, pageSize);

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all todo items from API.");

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/todoitems");

                var todos = await _httpClient.GetFromJsonAsync<List<TodoDto>>("/todoitems");

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
                var todo = await _httpClient.GetFromJsonAsync<TodoDto>($"/todoitems/{id}");

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
                var response = await _httpClient.PutAsJsonAsync($"/todoitems/{id}", dto);

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

        public async Task<int> GetCount()
        {
            try
            {
                _logger.LogInformation("Fetching count of todo items from API.");
                var response = await _httpClient.GetAsync("/todoitems/count");

                response.EnsureSuccessStatusCode();

                var countStrign = await response.Content.ReadAsStringAsync();
                var count = int.Parse(countStrign);

                return count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching count of todo items.");

                throw new Exception(ex.Message);
            }
        }
    }
}
