namespace TodoListCore.Models;
using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }

    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}


