namespace TaskReporter.Domain.Entities;

public class WeeklyReport : Report
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}