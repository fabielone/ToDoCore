using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListCore.Models;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly AppDbContext _context;

    public TaskController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Tasks
    [HttpGet]
    public ActionResult<IEnumerable<TodoListCore.Models.Task>> GetAll()
    {
        return _context.Tasks.ToList();
    }

    // GET: api/Tasks/5
    [HttpGet("{id}")]
    public ActionResult<TodoListCore.Models.Task> GetById(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    // POST: api/Tasks
    [HttpPost]
    public ActionResult<TodoListCore.Models.Task> Create(TodoListCore.Models.Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = task.ID }, task);
    }

    // PUT: api/Tasks/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, TodoListCore.Models.Task task)
    {
        if (id != task.ID)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Tasks/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return NoContent();
    }
}