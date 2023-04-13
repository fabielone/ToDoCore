namespace TodoListCore.Models;

public class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Project> Projects { get; set; }
}