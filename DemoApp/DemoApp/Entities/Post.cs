﻿namespace DemoApp.Domain.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public long UserId { get; set; }
    }
}