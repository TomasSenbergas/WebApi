using Microsoft.AspNetCore.Mvc;
using P01_Intro.Models;

namespace P01_Intro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly List<TodoItem> _todos;

        public TodoController()
        {
            _todos = new List<TodoItem>()
            {
                new TodoItem(1, "Todo 1", "Content 1", DateTime.Now, "User 1"),
                new TodoItem(2, "Todo 2", "Content 2", DateTime.Now, "User 2"),
                new TodoItem(3, "Todo 1", "Content 3", DateTime.Now, "User 3"),
                new TodoItem(4, "Todo 1", "Content 4", DateTime.Now, "User 4"),
                new TodoItem(5, "Todo 5", "Content 5", DateTime.Now, "User 5"),
            };

        }

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _todos;
        }
        //GET path ketimas get metodui (relative)
        [HttpGet("GetAllTodoItems")]
        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _todos;
        }
        //path ketimas get metodui (absolute)
        [HttpGet("/GetAllTodoItems")]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _todos;
        }

        //metodas kuris grazina todoitem pagal id
        [HttpGet("{id:int:min(1)}")]
        public TodoItem GetTodoItemById(int id)
        {
            return _todos.Find(x => x.Id == id);
        }

        //metodas kuris filtruoja todo pagal tipa
        [HttpGet("GetTodoItemsByType")]
        public IEnumerable<TodoItem> GetTodoItemsByType(string name)
        {
            return _todos.Where(x => x.Name == name);
        }
        //metodas kuris filtruoja todo pagal pavadinima ir grazina viena pagal id
        [HttpGet("{id:int}/GetTodoItemByName")]
        public TodoItem? GetTodoItemByName(string name, int id)
        {
            return _todos.Find(x => x.Name == name && x.Id == id);
        }

    }
}
