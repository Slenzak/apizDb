using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Task = WebApplication1.Models.Task;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly AppDataContext _appDataContext;
        public TaskController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        [HttpGet]
        public List<Task> TasksGet()
        {
            return _appDataContext.Task.ToList();
        }
        [HttpGet("{id}")]
        public Task TaskGet(int id)
        {
            return _appDataContext.Task.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost("{title},{description}")]
        public List<Task> TaskSet(string title,string description)
        {
            _appDataContext.Task.Add(new Task { Title = title, Description = description });
            _appDataContext.SaveChanges();
            return _appDataContext.Task.ToList();
        }
        [HttpPut("{id},{title},{description}")]
        public List<Task> TaskUpdate(int id, string title,string description)
        {
            var temp = _appDataContext.Task.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                temp.Title = title;
                _appDataContext.SaveChanges();
            }
            return _appDataContext.Task.ToList();
        }
        [HttpDelete("{id}")]
        public List<Task> TasksDelete(int id)
        {
            var temp = _appDataContext.Task.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                _appDataContext.Remove(temp);
                _appDataContext.SaveChanges();
            }
            return _appDataContext.Task.ToList();
        }
    }
}
