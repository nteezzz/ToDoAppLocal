namespace ToDoAppLocal.Models
{
    public class TodoItem
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }=null;
        public bool IsCompleted { get; set; } = false;
        public required string DueDate { get; set; }
        public string Priority { get; set; } = "low";

        public TodoItem()
        {
            DueDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        }


    }

}
