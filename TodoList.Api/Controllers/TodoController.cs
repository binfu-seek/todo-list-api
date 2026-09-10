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
        public async Task PostAsync([FromBody] TodoRequestDto value)
        {
            await _todoService.CreateTodoAsync(value);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] TodoRequestDto value)
        {
            // Implementation for updating a todo item
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _todoService.DeleteTodoAsync(id);
        }
    }
}
