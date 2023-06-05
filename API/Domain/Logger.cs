namespace API.Domain
{
    public class Logger : Entity
    {
        public int CheckInHour { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}