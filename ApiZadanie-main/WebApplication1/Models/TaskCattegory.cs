﻿namespace WebApplication1.Models
{
    public class TaskCattegory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<TaskCategoryAssignment> TaskCategoryAssignments { get; set; } = new();

    }
}
