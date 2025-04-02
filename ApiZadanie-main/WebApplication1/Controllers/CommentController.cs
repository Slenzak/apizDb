using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly AppDataContext _appDataContext;
        public CommentController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        [HttpGet("{taskId}")]
        public IActionResult CommentsGet(int taskid)
        {
            var comment = _appDataContext.Comment.Where(x => x.TaskId == taskid);
            return Ok(comment);
        }
        [HttpPost("{author},{descripton},{taskid},{title}")]
        public List<Comment> CommentsSet(int taskid,string author,string title,string descripton)
        {
            _appDataContext.Comment.Add(new Comment { Author = author, TaskId= taskid,Title=title,Description=descripton });
            return _appDataContext.Comment.ToList();
        }
        [HttpPut("{id},{title},{description}")]
        public List<Comment> CommentUpdate(int id, string title,string description)
        {
            var temp = _appDataContext.Comment.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                temp.Title = title;
                temp.Description = description;
                _appDataContext.SaveChanges();
            }
            return _appDataContext.Comment.ToList();
        }
        [HttpDelete("{id}")]
        public List<Comment> CommentsDelete(int id)
        {
            var temp = _appDataContext.Comment.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                _appDataContext.Comment.Remove(temp);
                _appDataContext.SaveChanges();
            }
            return _appDataContext.Comment.ToList();
        }
    }
}
