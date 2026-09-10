using TodoList.Api.Models;

namespace TodoList.Api.Repositories
{
    public class Repository : IRepository
    {
        public Repository() { }

        public Task<TodoItemModel> CreateTodoAsync(TodoItemModel newTodo)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemModel> DeleteTodoAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemModel> GetTodoByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItemModel>> GetTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
