using System.Text.Json;
using ToDoAppLocal.Models;

namespace ToDoAppLocal.Services
{
    public class TodoService
    {
        private readonly string _filePath = "Data/todos.json";

        public List<TodoItem> GetAllTodos()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TodoItem>();
            }

            var json = File.ReadAllText(_filePath);
            var todos = JsonSerializer.Deserialize<List<TodoItem>>(json);
            return todos ?? new List<TodoItem>();
        }

        public void SaveAllTodos(List<TodoItem> list)
        {
            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(_filePath, json);
        }
    }
}
