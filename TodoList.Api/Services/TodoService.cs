using TodoList.Api.DTOs;
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

        public Task<TodoResponseDto> CreateTodoAsync(TodoRequestDto newTodo)
        {
            throw new NotImplementedException();
        }

        public Task<TodoResponseDto> DeleteTodoAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<TodoResponseDto> GetTodoByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoResponseDto>> GetTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
