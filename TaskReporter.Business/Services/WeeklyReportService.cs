using EntityFramework.Interfaces;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Services;

public class WeeklyReportService : IWeeklyReportService
{
    private readonly IWeeklyReportReposity _weeklyReportReposity;

    public WeeklyReportService(IWeeklyReportReposity weeklyReportReposity)
    {
        _weeklyReportReposity = weeklyReportReposity;
    }
    
    public WeeklyReportDTO GetById(int id)
    {
        var report = _weeklyReportReposity.FindById(id);
        var reportDTO = new WeeklyReportDTO
        {
            CreationDate = report.CreationDate,
            StartDate = report.StartDate,
            EndDate = report.EndDate,
            Subject = report.Subject,
            Title = report.Title,
            Context = report.Context
        };

        return reportDTO;
    }

    public void Insert(WeeklyReportCreateDTO entity)
    {
        var report = new WeeklyReport
        {
            CreationDate = entity.CreationDate,
            Subject = entity.Subject,
            Title = entity.Title,
            Context = entity.Context,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate
        };
        
        _weeklyReportReposity.Insert(report);
    }

    public void Delete(int id)
    {
        _weeklyReportReposity.Delete(id);
    }

    public void Update(WeeklyReportDTO entity)
    {
        var report = _weeklyReportReposity.FindById(entity.Id);

        if (report == null)
        {
            throw new Exception("No data was found in the database with this ID.");
        }
        
        report.CreationDate = entity.CreationDate;
        report.Subject = entity.Subject;
        report.Title = entity.Title;
        report.Context = entity.Context;
        report.StartDate = entity.StartDate;
        report.EndDate = entity.EndDate;

        _weeklyReportReposity.Update(report);
    }

    public List<WeeklyReport> GetAll()
    {
        return _weeklyReportReposity.GetAll();
    }
}