using Microsoft.EntityFrameworkCore;
using TodoMiniAPIApp.Data;
using TodoMiniAPIApp.Modules;

namespace TodoMiniAPIApp.Endpoints
{
    public static class TodoEndpoints
    {
        public static void Map(WebApplication app)
        {
            var todoItemsEndpoint = app.MapGroup("/todoitems");

            todoItemsEndpoint.MapGet("", async (AppDbContext db) => await db.Todos.ToListAsync());

            todoItemsEndpoint.MapGet("{id:int}", async (int id, AppDbContext db) => await db.Todos.FindAsync(id));

            todoItemsEndpoint.MapPost("", async (Todo todo, AppDbContext db) => { 
                db.Todos.Add(todo); 
                await db.SaveChangesAsync(); 
                return Results.Created($"/todoitems/{todo.Id}", todo); 
            });

            todoItemsEndpoint.MapPut("{id:int}", async (int id, Todo inputTodo, AppDbContext db) =>
            {
                var todo = await db.Todos.FindAsync(id);
                if (todo == null) return Results.NotFound();
                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            todoItemsEndpoint.MapDelete("{id:int}", async (int id, AppDbContext db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }
                return Results.NotFound();
            });
        }
    }
}
