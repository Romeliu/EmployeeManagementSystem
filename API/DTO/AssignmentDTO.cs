namespace API.DTO
{
    public class AssignmentDTO : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int EmployeeId { get; set; }
    }
}