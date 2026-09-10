using TodoList.Api.DTOs;
using TodoList.Api.Models;
using TodoList.Api.Repositories;

namespace TodoList.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository _repository;
        public TodoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoResponseDto> CreateTodoAsync(TodoRequestDto newTodo)
        {
            var result = await _repository.CreateTodoAsync(new TodoItemModel
            {
                Guid = Guid.NewGuid(),
                Title = newTodo.Title,
                Description = newTodo.Description,
                Status = TodoItemStatus.New,
                CreatedAt = DateTime.Now,
                Notes = newTodo.Notes
            });

            return new TodoResponseDto
            {
                Guid = result.Guid,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                CreatedAt = result.CreatedAt,
                Notes = result.Notes
            };
        }

        public async Task<TodoResponseDto> DeleteTodoAsync(Guid guid)
        {
            var result = await _repository.DeleteTodoAsync(guid);

            if (result == null)
            {
                throw new KeyNotFoundException($"Todo item with Guid {guid} not found.");
            }

            return new TodoResponseDto
            {
                Guid = result.Guid,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                CreatedAt = result.CreatedAt,
                Notes = result.Notes
            };
        }

        public async Task<TodoResponseDto> GetTodoByIdAsync(Guid guid)
        {
            var result = await _repository.GetTodoByIdAsync(guid);

            if (result == null)
            {
                throw new KeyNotFoundException($"Todo item with Guid {guid} not found.");
            }

            return new TodoResponseDto
            {
                Guid = result.Guid,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                CreatedAt = result.CreatedAt,
                Notes = result.Notes
            };
        }

        public async Task<IEnumerable<TodoResponseDto>> GetTodosAsync()
        {
            var results = await _repository.GetTodosAsync();
            return results.Select(todo => new TodoResponseDto
            {
                Guid = todo.Guid,
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                CreatedAt = todo.CreatedAt,
                Notes = todo.Notes
            });
        }
    }
}
