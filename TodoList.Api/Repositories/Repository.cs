using System.Collections.Concurrent;
using TodoList.Api.Models;

namespace TodoList.Api.Repositories
{
    public class Repository : IRepository
    {
        private ConcurrentDictionary<Guid, TodoItemModel> _todos = new ConcurrentDictionary<Guid, TodoItemModel>();
        public Repository() { }

        public Task<TodoItemModel> CreateTodoAsync(TodoItemModel newTodo)
        {
            _todos[newTodo.Guid] = newTodo;
            return Task.FromResult(newTodo);
        }

        public Task<TodoItemModel> DeleteTodoAsync(Guid guid)
        {
            _todos.TryRemove(guid, out TodoItemModel todo);
            return Task.FromResult(todo);
        }

        public Task<TodoItemModel> GetTodoByIdAsync(Guid guid)
        {
            _todos.TryGetValue(guid, out TodoItemModel todo);
            return Task.FromResult(todo);
        }

        public Task<IEnumerable<TodoItemModel>> GetTodosAsync()
        {
            return Task.FromResult<IEnumerable<TodoItemModel>>(_todos.Values);
        }
    }
}
