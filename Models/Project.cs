namespace TodoListCore.Models;

public class Project
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserID { get; set; }

    public User? User { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}
