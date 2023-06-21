namespace TaskReporter.Business.DTO;

public class MonthlyReportDTO : MonthlyReportCreateDTO
{
    public int Id { get; set; }
}

public class MonthlyReportCreateDTO
{
    public string MonthName { get; set; }
    public DateTime CreationDate { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
}