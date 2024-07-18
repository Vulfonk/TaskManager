using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
