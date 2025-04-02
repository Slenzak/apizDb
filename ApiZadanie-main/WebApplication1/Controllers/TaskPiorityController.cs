using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskPiorityController : Controller
    {
        private readonly AppDataContext _appDataContext;
        public TaskPiorityController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        [HttpGet]
        public List<TaskPiority> TaskPioritiesGet()
        {
            return _appDataContext.TaskPiorities.ToList();
        }
        [HttpGet("{taskid}")]
        public TaskPiority TaskPiorityGet(int taskid)
        {
            return _appDataContext.TaskPiorities.FirstOrDefault(x => x.TaskId == taskid);
        }
        [HttpPut("{taskid},{piority}")]
        public List<TaskPiority> TaskPiorityUpdate(int taskid, string piority)
        {
            var temp = _appDataContext.TaskPiorities.FirstOrDefault(x => x.TaskId == taskid);
            if (temp != null)
            {
                temp.Piority = piority;
                _appDataContext.SaveChanges();
            }
            return _appDataContext.TaskPiorities.ToList();
        }
    }
}
