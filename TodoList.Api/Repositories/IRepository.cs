using TodoList.Api.Models;

namespace TodoList.Api.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<TodoItemModel>> GetTodos();
        Task<TodoItemModel> GetTodoById(Guid guid);
        Task<TodoItemModel> DeleteTodo(Guid guid);
    }
}
