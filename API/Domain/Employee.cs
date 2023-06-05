namespace API.Domain
{
    public class Employee : User
    {
        public List<Logger> Loggers { get; set; }
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }
        public List<Assignment> Assignments { get; set; } = new();
        public bool Active { get; set; }
    }
}