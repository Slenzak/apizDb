using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using TaskStatus = WebApplication1.Models.TaskStatus;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskStatusController : Controller
    {
        private readonly AppDataContext _appDataContext;
        public TaskStatusController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        [HttpGet]
        public List<TaskStatus> TaskStatusesGet()
        {
            return _appDataContext.TaskStatus.ToList();
        }
        [HttpGet("{id}")]
        public TaskStatus TaskStatusGet(int taskid)
        {
            return _appDataContext.TaskStatus.FirstOrDefault(x => x.TaskId == taskid);
        }
        [HttpPut("{id},{status}")]
        public List<TaskStatus> TaskStatusUpdate(int taskid, string status)
        {
            var temp = _appDataContext.TaskStatus.FirstOrDefault(x => x.TaskId == taskid);
            if (temp != null)
            {
                temp.Status = status;
                _appDataContext.SaveChanges();
            }
            return _appDataContext.TaskStatus.ToList();
        }
    }
}
