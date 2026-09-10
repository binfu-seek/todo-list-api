using TodoList.Api.Models;

namespace TodoList.Api.DTOs
{
    public class TodoRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
