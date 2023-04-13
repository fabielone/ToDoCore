namespace TodoListCore.Models;

public class Task
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Project_ID { get; set; }

    public Project Project { get; set; }
}
