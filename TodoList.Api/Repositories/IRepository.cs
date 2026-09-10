using TodoList.Api.DTOs;
using TodoList.Api.Models;

namespace TodoList.Api.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<TodoItemModel>> GetTodosAsync();
        Task<TodoItemModel> GetTodoByIdAsync(Guid guid);
        Task<TodoItemModel> CreateTodoAsync(TodoItemModel newTodo);
        Task<TodoItemModel> DeleteTodoAsync(Guid guid);
    }
}
