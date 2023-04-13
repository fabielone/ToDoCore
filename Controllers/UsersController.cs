using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListCore.Models; // Replace with your actual namespace containing the models

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        return _context.Users.ToList();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: api/Users
    [HttpPost]
    public ActionResult<User> Create(User user)
    {
        
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = user.ID }, user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.ID)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}