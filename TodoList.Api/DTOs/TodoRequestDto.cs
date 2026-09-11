using System.ComponentModel.DataAnnotations;
using TodoList.Api.Models;

namespace TodoList.Api.DTOs
{
    public class TodoRequestDto
    {
        [Required(ErrorMessage = "The todo title cannot be empty.")]
        [StringLength(10, MinimumLength = 3, 
            ErrorMessage = "The title must be between 3 and 100 characters long.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
