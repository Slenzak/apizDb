namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; }
        public virtual Task Task { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
