namespace API.Domain
{
    public class Record : Entity
    {
        public DateTime Date { get; set; }
        public List<Logger> Loggers { get; set; }
    }
}