using TodoList.Api.Models;
using TodoList.Api.DTOs;

namespace TodoList.Api.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoResponseDto>> GetTodosAsync();
        Task<TodoResponseDto> GetTodoByIdAsync(Guid guid);
        Task<TodoResponseDto> CreateTodoAsync(TodoRequestDto newTodo);
        Task<TodoResponseDto> DeleteTodoAsync(Guid guid);
    }
}
