using EntityFramework.Interfaces;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Services;

public class MonthlyReportService : IMonthlyReportService
{
    private readonly IMonthlyReportReposity _monthlyReportReposity;

    public MonthlyReportService(IMonthlyReportReposity monthlyReportReposity)
    {
        _monthlyReportReposity = monthlyReportReposity;
    }
    
    public MonthlyReportDTO GetById(int id)
    {
        var report = _monthlyReportReposity.FindById(id);
        var reportDTO = new MonthlyReportDTO
        {
            Id = report.Id,
            MonthName = report.MonthName,
            CreationDate = report.CreationDate,
            Subject = report.Subject,
            Title = report.Title,
            Context = report.Context
        };

        return reportDTO;
    }

    public void Insert(MonthlyReportCreateDTO entity)
    {
        var report = new MonthlyReport
        {
            CreationDate = entity.CreationDate,
            Subject = entity.Subject,
            Title = entity.Title,
            Context = entity.Context,
            MonthName = entity.MonthName
        };
        
        _monthlyReportReposity.Insert(report);
    }

    public void Delete(int id)
    {
        _monthlyReportReposity.Delete(id);
    }

    public void Update(MonthlyReportDTO entity)
    {
        var report = _monthlyReportReposity.FindById(entity.Id);
        
        if (report == null)
        {
            throw new Exception("No data was found in the database with this ID.");
        }

        report.MonthName = entity.MonthName;
        report.CreationDate = entity.CreationDate;
        report.Subject = entity.Subject;
        report.Title = entity.Title;
        report.Context = entity.Context;
        
        _monthlyReportReposity.Update(report);
    }

    public List<MonthlyReport> GetAll()
    {
        return _monthlyReportReposity.GetAll();
    }
}