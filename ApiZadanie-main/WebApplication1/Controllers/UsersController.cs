using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
        {
        private readonly AppDataContext _appDataContext;
        public UsersController(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        [HttpGet]
        public List<User> UsersGet()
        {
            return _appDataContext.User.ToList();
        }
        [HttpGet("{id}")]
        public User UserGet(int id)
        {
            return _appDataContext.User.FirstOrDefault(x => x.Id == id); 
        }
        [HttpPost("{username}")]
        public List<User> UsersSet(string username)
        {
            _appDataContext.User.Add(new User {Username = username, CreatedDate = DateOnly.FromDateTime(DateTime.Today) });
            _appDataContext.SaveChanges();
            return _appDataContext.User.ToList();
        }
        [HttpPut("{id},{username}")]
        public List<User> UserUpdate(int id,string username)
        {
            var temp = _appDataContext.User.FirstOrDefault(x => x.Id == id);
            if (temp != null)
            {
                temp.Username = username;
                _appDataContext.SaveChanges();
            }
            return _appDataContext.User.ToList();
        }
        [HttpDelete("{id}")]
        public List<User> UsersDelete(int id) 
        {
            var temp = _appDataContext.User.FirstOrDefault(x=> x.Id == id);
            if (temp != null)
            {
                _appDataContext.User.Remove(temp);
                _appDataContext.SaveChanges();
            }
            return _appDataContext.User.ToList();
        }
    }
}
