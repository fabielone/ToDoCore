namespace TodoListCore.Models;

public class UserRole
{
    public int ID { get; set; }
    public int theRole_ID { get; set; }
    public int theUser_ID { get; set; }

    public User User { get; set; }
    public Role Role { get; set; }
}
