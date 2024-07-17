namespace TaskManager.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate{ get; set; }
        public Priority Priority { get; set; }
        public User User { get; set; }

    }
}
