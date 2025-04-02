using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class TaskCattegoryController : Controller
        {
            private readonly AppDataContext _appDataContext;
            public TaskCattegoryController(AppDataContext appDataContext)
            {
                _appDataContext = appDataContext;
            }
            [HttpGet]
            public List<TaskCattegory> TaskCattegoriesGet()
            {
                return _appDataContext.TaskCattegories.ToList();
            }
            [HttpGet("{id}")]
            public TaskCattegory TaskCattegoryGet(int id)
            {
                return _appDataContext.TaskCattegories.FirstOrDefault(x => x.Id == id);
            }
            [HttpPost("{title}")]
            public List<TaskCattegory> TaskCattegoriesSet(string title)
            {
                _appDataContext.TaskCattegories.Add(new TaskCattegory { Title = title });
                _appDataContext.SaveChanges();
                return _appDataContext.TaskCattegories.ToList();
            }
            [HttpPut("{id},{title}")]
            public List<TaskCattegory> TaskCattegoryUpdate(int id, string username)
            {
                var temp = _appDataContext.TaskCattegories.FirstOrDefault(x => x.Id == id);
                if (temp != null)
                {
                    temp.Title = username;
                    _appDataContext.SaveChanges();
                }
                return _appDataContext.TaskCattegories.ToList();
            }
            [HttpDelete("{id}")]
            public List<TaskCattegory> TaskCattegoriesDelete(int id)
            {
                var temp = _appDataContext.TaskCattegories.FirstOrDefault(x => x.Id == id);
                if (temp != null)
                {
                    _appDataContext.TaskCattegories.Remove(temp);
                    _appDataContext.SaveChanges();
                }
                return _appDataContext.TaskCattegories.ToList();
            }
        }
}
