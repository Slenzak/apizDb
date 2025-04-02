namespace WebApplication1.Models
{
    public class TaskTags
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public virtual List<TaskTag> TaskTag { get; set; } = new();
    }
}
