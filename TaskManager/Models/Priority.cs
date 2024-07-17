namespace TaskManager.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public ICollection<ToDoItem> ToDoItem { get; set; }
    }
}