namespace WebApplication1.Models
{
    public class TaskTag
    {
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public int TagId { get; set; }
        public virtual TaskTags Tag { get; set; }
    }
}
