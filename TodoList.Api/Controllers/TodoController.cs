using Microsoft.AspNetCore.Mvc;
using TodoList.Api.DTOs;
using TodoList.Api.Services;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public async Task<IEnumerable<TodoResponseDto>> GetAsync()
        {
            return await _todoService.GetTodosAsync();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<TodoResponseDto> GetAsync(Guid id)
        {
            return await _todoService.GetTodoByIdAsync(id);
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<TodoResponseDto> PostAsync([FromBody] TodoRequestDto value)
        {
            return await _todoService.CreateTodoAsync(value);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _todoService.DeleteTodoAsync(id);
        }
    }
}
