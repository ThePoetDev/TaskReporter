namespace TaskReporter.Business.DTO;

public class DailyReportDTO : DailyReportCreateDTO
{
    public int Id { get; set; }
}

public class DailyReportCreateDTO
{
    public DateTime CreationDate { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
}