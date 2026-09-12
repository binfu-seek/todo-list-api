using TodoList.Api.DTOs;
using TodoList.Api.Models;
using TodoList.Api.Repositories;
using TodoList.Api.Services;

namespace TodoList.Api.Test.Services
{


    public class TodoServiceTests
    {
        private sealed class FakeRepository : IRepository
        {
            public IEnumerable<TodoItemModel> Todos { get; set; } = [];
            public int CreateTodoCallCount { get; private set; }
            public int DeleteTodoCallCount { get; private set; }
            public int GetAllTodoCallCount { get; private set; }
            public TodoItemModel? DeletedTodo { get; set; } = new TodoItemModel
            {
                Title = "Todo 1",
                Description = "Description 1",
                Status = TodoItemStatus.New
            };

            public Task<IEnumerable<TodoItemModel>> GetTodosAsync() {
                GetAllTodoCallCount++;
                return Task.FromResult(Todos);
            }

            public Task<TodoItemModel> GetTodoByIdAsync(Guid guid) =>
                Task.FromResult(Todos.FirstOrDefault(todo => todo.Guid == guid));

            public Task<TodoItemModel> CreateTodoAsync(TodoItemModel newTodo)
            {
                CreateTodoCallCount++;
                return Task.FromResult(newTodo);
            }

            public Task<TodoItemModel> DeleteTodoAsync(Guid guid)
            {
                DeleteTodoCallCount++;
                if (DeletedTodo != null)
                {
                    DeletedTodo.Guid = guid;
                }

                return Task.FromResult(DeletedTodo!);
            }
        }

        #region GetTodo Tests
        [Fact]
        public async Task Test_GetTodos_Returns_All_Todos()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();

            var Todos = new List<TodoItemModel>
            {
                new TodoItemModel { Guid = guid1, Title = "Todo 1", Description = "Description 1", Status = TodoItemStatus.New },
                new TodoItemModel { Guid = guid2, Title = "Todo 2", Description = "Description 2", Status = TodoItemStatus.Pending }
            };

            // Arrange
            var repository = new FakeRepository
            {
                Todos = Todos
            };
            var todoService = new TodoService(new FakeRepository());

            // Act
            var results = await todoService.GetTodosAsync();

            // Assert
            var todos = results.ToList();
            for (int i = 0; i < results.Count(); i++)
            {
                Assert.Equal(1, repository.GetAllTodoCallCount);
                Assert.Equal(Todos[i].Guid, todos[i].Guid);
                Assert.Equal(Todos[i].Title, todos[i].Title);
                Assert.Equal(Todos[i].Description, todos[i].Description);
                Assert.Equal(Todos[i].Status, todos[i].Status);
            }
        }

        #endregion

        #region CreateTodo Tests

        [Fact]
        public async Task Test_CreateTodo_Returns_New_Todos()
        {
            var repository = new FakeRepository();
            var service = new TodoService(repository);

            var result = await service.CreateTodoAsync(new TodoRequestDto
            {
                Title = "Buy milk",
                Description = "Two liters"
            });

            Assert.Equal(1, repository.CreateTodoCallCount);
            Assert.Equal("Buy milk", result.Title);
            Assert.Equal("Two liters", result.Description);
            Assert.Equal(TodoItemStatus.New, result.Status);
            Assert.NotEqual(Guid.Empty, result.Guid);
        }

        // Do not test invalid input here since the model validation handles the cases when title is null or length is out of range

        #endregion

        #region DeleteTodo Tests

        [Fact]
        public async Task Test_DeleteTodo_Returns_Mapped_Deleted_TodoDto()
        {
            var guid = Guid.NewGuid();

            // Arrange
            var repository = new FakeRepository();
            var todoService = new TodoService(repository);

            // Act
            var result = await todoService.DeleteTodoAsync(guid);

            // Assert
            Assert.Equal(1, repository.DeleteTodoCallCount);
            Assert.NotNull(result);
            Assert.Equal(guid, result.Guid);
            Assert.Equal("Todo 1", result.Title);
            Assert.Equal("Description 1", result.Description);
            Assert.Equal(TodoItemStatus.New, result.Status);
        }

        [Fact]
        public async Task Test_DeleteTodo_Throws_Error_For_Non_Existent_Todo()
        {
            var guid = Guid.NewGuid();

            // Arrange
            var repository = new FakeRepository { DeletedTodo = null };
            var todoService = new TodoService(repository);

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => todoService.DeleteTodoAsync(guid));

            // Assert
            Assert.Equal($"Todo item with Guid {guid} not found.", exception.Message);
            Assert.Equal(1, repository.DeleteTodoCallCount);
        }

        #endregion
    }
}
