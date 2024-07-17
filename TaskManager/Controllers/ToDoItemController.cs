using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ToDoItem> Get(FilterInfo filterInfo)
        {
            return Enumerable.Empty<ToDoItem>();
        }

        [HttpPost]
        public void Post(ToDoItemInfo itemInfo)
        {
            
        }

        [HttpDelete]
        public void Delete(ToDoItemInfo itemInfo)
        {

        }



    }

    public record FilterInfo(bool isCompleted, int priorityId, int userId);
    public record ToDoItemInfo(int title, int description, bool isCompleted, DateTime dueDate, int priorityId, int userId);
}
