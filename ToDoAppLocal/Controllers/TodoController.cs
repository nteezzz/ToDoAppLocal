using Microsoft.AspNetCore.Mvc;
using ToDoAppLocal.Models;
using ToDoAppLocal.Services;
using System.Collections.Generic;
using System.Linq;

namespace ToDoAppLocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // Get all todos
        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            return _todoService.GetAllTodos();
        }

        // Get a specific todo by id
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todo = _todoService.GetAllTodos().FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // Add a new todo
        [HttpPost]
        public ActionResult Add(TodoItem item)
        {
            var todos = _todoService.GetAllTodos();
            item.Id = todos.Count > 0 ? todos.Max(t => t.Id) + 1 : 1;
            todos.Add(item);
            _todoService.SaveAllTodos(todos);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        // Update an existing todo
        [HttpPut("{id}")]
        public ActionResult Update(int id, TodoItem updatedItem)
        {
            var todos = _todoService.GetAllTodos();
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Title = updatedItem.Title;
            todo.Description = updatedItem.Description;
            todo.DueDate = updatedItem.DueDate;
            todo.Priority = updatedItem.Priority;
            todo.IsCompleted = updatedItem.IsCompleted;

            _todoService.SaveAllTodos(todos);
            return NoContent();
        }

        // Toggle completion status of a todo
        [HttpPatch("{id}/toggleComplete")]
        public ActionResult ToggleComplete(int id)
        {
            var todos = _todoService.GetAllTodos();
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsCompleted = !todo.IsCompleted;
            _todoService.SaveAllTodos(todos);
            return NoContent();
        }

        // Delete a todo
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todos = _todoService.GetAllTodos();
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todos.Remove(todo);
            _todoService.SaveAllTodos(todos);
            return NoContent();
        }
    }
}
