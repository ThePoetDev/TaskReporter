using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.DTO;

public class WeeklyReportDTO : WeeklyReportCreateDTO
{
    public int Id { get; set; }
}

public class WeeklyReportCreateDTO
{
    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    
    public int OwnerId { get; set; }
}