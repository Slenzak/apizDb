using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskTagController : Controller
    {
        private readonly AppDataContext _appDataContext;
        public TaskTagController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTaskTags(int taskId)
        {
            var tags = _appDataContext.TaskTag
                .Where(tt => tt.TaskId == taskId)
                .Include(tt => tt.Tag)
                .Select(tt => tt.Tag)
                .ToList();

            return Ok(tags);
        }

        [HttpPost("{taskId}/{tagName}")]
        public IActionResult AddTagToTask(int taskId, string tagName)
        {
            var task = _appDataContext.Task.Find(taskId);
            if (task == null)
                return NotFound("Zadanie nie istnieje");

            var tag = _appDataContext.TaskTags.FirstOrDefault(t => t.Tag == tagName);
            if (tag == null)
            {
                tag = new TaskTags { Tag = tagName };
                _appDataContext.TaskTags.Add(tag);
                _appDataContext.SaveChanges();
            }

            var taskTag = new TaskTag { TaskId = taskId, TagId = tag.Id };
            _appDataContext.TaskTag.Add(taskTag);
            _appDataContext.SaveChanges();

            return Ok("Tag dodany do zadania");
        }

        [HttpDelete("{taskId}/{tagId}")]
        public IActionResult RemoveTagFromTask(int taskId, int tagId)
        {
            var taskTag = _appDataContext.TaskTag.FirstOrDefault(tt => tt.TaskId == taskId && tt.TagId == tagId);
            if (taskTag == null)
                return NotFound("Tag nie jest przypisany do tego zadania");

            _appDataContext.TaskTag.Remove(taskTag);
            _appDataContext.SaveChanges();

            return Ok("Tag usunięty z zadania");
        }
    }
}
