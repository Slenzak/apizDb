namespace WebApplication1.Models
{
    public class Task
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<UserTask> UserTasks { get; set; } = new();
        public virtual List<TaskCategoryAssignment> TaskCategoryAssignments { get; set; } = new();
        public virtual List<TaskTag> TaskTags { get; set; } = new();
    }
}
