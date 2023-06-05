namespace API.Domain
{
    public class Manager : User
    {
        public List<Employee> Employees { get; set; }
    }
}