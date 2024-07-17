﻿namespace TaskManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public ICollection<ToDoItem> ToDoItem { get; set; }
    }
}