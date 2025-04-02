namespace WebApplication1.Models
{
    public class TaskCategoryAssignment
    {
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int TaskCategoryId { get; set; }
        public virtual TaskCattegory TaskCategory { get; set; }
    }
}
