﻿namespace DemoApp.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        
        public long UserId { get; set; }
    }
}