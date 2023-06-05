using API.Domain;

public class Assignment : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool Completed { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}