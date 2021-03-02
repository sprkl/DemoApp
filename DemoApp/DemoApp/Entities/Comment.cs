namespace DemoApp.Domain.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        
        public long PostId { get; set; }
        public long UserId { get; set; }
    }
}