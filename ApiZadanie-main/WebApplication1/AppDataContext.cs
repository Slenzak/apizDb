using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AppDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public virtual DbSet<User>? User { get; set; }
        public virtual DbSet<Models.Task>? Task { get; set; }
        public virtual DbSet<TaskCattegory>? TaskCattegories { get; set; }
        public virtual DbSet<TaskPiority>? TaskPiorities { get; set; }
        public virtual DbSet<Models.TaskStatus>? TaskStatus { get; set; }
        
        public virtual DbSet<Comment>? Comment { get; set; }
        public virtual DbSet<UserTask>? UserTasks { get; set; }
        public virtual DbSet<TaskCategoryAssignment>? TaskCategoryAssignments { get; set; }
        public virtual DbSet<TaskTag>? TaskTag { get; set; }
        public virtual DbSet<TaskTags>? TaskTags { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserTask>()
           .HasKey(ut => new { ut.UserId, ut.TaskId });

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.Task)
                .WithMany(t => t.UserTasks)
                .HasForeignKey(ut => ut.TaskId);
            modelBuilder.Entity<TaskCategoryAssignment>()
           .HasKey(tc => new { tc.TaskId, tc.TaskCategoryId });

            modelBuilder.Entity<TaskCategoryAssignment>()
                .HasOne(tc => tc.Task)
                .WithMany(t => t.TaskCategoryAssignments)
                .HasForeignKey(tc => tc.TaskId);

            modelBuilder.Entity<TaskCategoryAssignment>()
                .HasOne(tc => tc.TaskCategory)
                .WithMany(c => c.TaskCategoryAssignments)
                .HasForeignKey(tc => tc.TaskCategoryId);
            modelBuilder.Entity<TaskTag>()
                .HasKey(tt => new { tt.TaskId, tt.TagId });

            modelBuilder.Entity<TaskTag>()
                .HasOne(tt => tt.Task)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TaskId);

            modelBuilder.Entity<TaskTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TaskTag)
                .HasForeignKey(tt => tt.TagId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

            optionsBuilder.UseMySql(_configuration.GetConnectionString("MySqlConnection"), serverVersion).UseLazyLoadingProxies();
        }

    }
}
