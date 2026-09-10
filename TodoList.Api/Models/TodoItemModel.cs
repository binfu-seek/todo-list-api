namespace TodoList.Api.Models
{
    public enum TodoItemStatus
    {
        New,
        InProgress,
        Done,
        Pending,
        Cancelled
    }
    public class TodoItemModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoItemStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }
    }
}
