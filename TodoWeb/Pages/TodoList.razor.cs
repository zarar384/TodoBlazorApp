using Microsoft.AspNetCore.Components;
using TodoWeb.IServices;
using TodoWeb.Models;

// TODO Handle exceptions
namespace TodoWeb.Pages
{
    public partial class TodoList : ComponentBase
    {
        [Inject]
        private ITodoService TodoService { get; set; }

        private int pageSize = 10;
        private int todoCount;
        private int currentPageIndex = 0;
        private List<TodoDto> todos = new List<TodoDto>();
        private TodoDto newTodo = new TodoDto();
        private bool isAddNewTodo = false;
        private bool isEditTodo = false;
        private int? editingTodoId = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                todoCount = await TodoService.GetCount();
                await LoadTodoAsync(currentPageIndex);
            }
            catch
            {
                // Handle exceptions
            }
        }

        private async Task LoadTodoAsync(int pageIndex)
        {
            try
            {
                currentPageIndex = pageIndex;
                todos = await TodoService.GetTodoAsync(pageIndex, pageSize);

                if (isAddNewTodo)
                {
                    isAddNewTodo = false;
                }
            }
            catch
            {
                // Handle exceptions
            }
        }

        private async Task ToggleComplete(TodoDto todo)
        {
            try
            {
                todo.IsComplete = !todo.IsComplete;
                await TodoService.SetComplete(todo.Id, todo);
            }
            catch
            {
                // Handle exceptions
            }
        }

        private void EditTodo(TodoDto todo)
        {
            editingTodoId = todo.Id;
        }

        private async Task DeleteTodo(TodoDto todo)
        {
            try
            {
                await TodoService.DeleteAsync(todo.Id);
                todos.Remove(todo);
                todoCount--;

                if (todos.Count == 0 && todoCount > 0)
                {
                    int lastPageIndex = (todoCount - 1) / pageSize;
                    await LoadTodoAsync(lastPageIndex);
                }
                else
                {
                    await LoadTodoAsync(currentPageIndex);
                }
            }
            catch
            {
                // Handle exceptions
            }
        }

        private async void ShowAddNewTodo()
        {
            newTodo = new TodoDto();
            int lastPageIndex = todoCount / pageSize;

            if (currentPageIndex != lastPageIndex)
            {
                await LoadTodoAsync(lastPageIndex);
            }

            isAddNewTodo = true;
            StateHasChanged();
        }

        private async Task SaveNewTodo()
        {
            try
            {
                var nt = await TodoService.CreateAsync(newTodo);
                todos.Add(nt);
                todoCount++;

                if (todos.Count == 1)
                {
                    await LoadTodoAsync(currentPageIndex);
                }

                isAddNewTodo = false;
                StateHasChanged();
            }
            catch
            {
                // Handle exceptions
            }
        }

        private async Task UpdateTodo(TodoDto todo)
        {
            try
            {
                var updatedTodo = await TodoService.UpdateAsync(todo.Id, todo);
                var index = todos.FindIndex(t => t.Id == todo.Id);

                if (index != -1)
                {
                    todos[index] = updatedTodo;
                }

                editingTodoId = null;
                StateHasChanged();
            }
            catch
            {
                // Handle exceptions
            }
        }

        private async void CancelTodo()
        {
            isAddNewTodo = false;
            editingTodoId = null;
            newTodo = new TodoDto();

            if (todos.Count == 0)
            {
                currentPageIndex--;
                await LoadTodoAsync(currentPageIndex);
            }

            StateHasChanged(); 
        }
    }
}
