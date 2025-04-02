namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateOnly CreatedDate { get; set; }
        public virtual List<UserTask> UserTasks { get; set; } = new();
    }
}
