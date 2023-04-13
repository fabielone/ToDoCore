namespace TodoListCore.Models;

public class Role
{
    public int ID { get; set; }
    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}