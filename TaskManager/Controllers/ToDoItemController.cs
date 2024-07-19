using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Models;
using TaskManager.Data;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ToDoItemsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ToDoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetToDoItems()
    {
        return await _context.ToDoItems
            .Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate,
                PriorityId = item.PriorityId,
                UserId = item.UserId
            }).ToListAsync();
    }

    // GET api/ToDoItems/filter
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<ToDoItemDto>>> Get([FromQuery] bool? status = null, [FromQuery] int? priorityId = null)
    {
        return await _context.ToDoItems
            .Where(t => 
            (status == null) || (t.IsCompleted == status) &&
            (priorityId == null) || (t.PriorityId == priorityId)
            )
            .Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate,
                PriorityId = item.PriorityId,
                UserId = item.UserId
            }).ToListAsync();
    }

    // GET: api/ToDoItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemDto>> GetToDoItem(int id)
    {
        var toDoItem = await _context.ToDoItems
            .Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate,
                PriorityId = item.PriorityId,
                UserId = item.UserId
            })
            .FirstOrDefaultAsync(item => item.Id == id);

        if (toDoItem == null)
        {
            return NotFound();
        }

        return toDoItem;
    }

    // PUT: api/ToDoItems/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutToDoItem(int id, ToDoItemDto toDoItemDto)
    {
        if (id != toDoItemDto.Id)
        {
            return BadRequest();
        }

        var toDoItem = await _context.ToDoItems.FindAsync(id);
        if (toDoItem == null)
        {
            return NotFound();
        }

        toDoItem.Title = toDoItemDto.Title;
        toDoItem.Description = toDoItemDto.Description;
        toDoItem.IsCompleted = toDoItemDto.IsCompleted;
        toDoItem.DueDate = toDoItemDto.DueDate;
        toDoItem.PriorityId = toDoItemDto.PriorityId;
        toDoItem.UserId = toDoItemDto.UserId;

        _context.Entry(toDoItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToDoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // PUT api/tasks/5/assign/{userId}
    [HttpPut("{id}/assign/{userId}")]
    public async Task<ActionResult> AssignTask(int id, int userId)
    {
        var task = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
        if (task == null) 
            return NotFound();

        task.UserId = userId;
        _context.Entry(task).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToDoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();

    }

    // POST: api/ToDoItems
    [HttpPost]
    public async Task<ActionResult<ToDoItemDto>> PostToDoItem(ToDoItemDto toDoItemDto)
    {
        var toDoItem = new ToDoItem
        {
            Title = toDoItemDto.Title,
            Description = toDoItemDto.Description,
            IsCompleted = toDoItemDto.IsCompleted,
            DueDate = toDoItemDto.DueDate,
            PriorityId = toDoItemDto.PriorityId,
            UserId = toDoItemDto.UserId
        };

        _context.ToDoItems.Add(toDoItem);
        await _context.SaveChangesAsync();

        toDoItemDto.Id = toDoItem.Id;

        return CreatedAtAction("GetToDoItem", new { id = toDoItemDto.Id }, toDoItemDto);
    }

    // DELETE: api/ToDoItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToDoItem(int id)
    {
        var toDoItem = await _context.ToDoItems.FindAsync(id);
        if (toDoItem == null)
        {
            return NotFound();
        }

        _context.ToDoItems.Remove(toDoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ToDoItemExists(int id)
    {
        return _context.ToDoItems.Any(e => e.Id == id);
    }
}
