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
            Context = report.Context,
            OwnerId = report.OwnerId
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
            MonthName = entity.MonthName,
            OwnerId = entity.OwnerId
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
        report.OwnerId = entity.OwnerId;
        
        _monthlyReportReposity.Update(report);
    }

    public List<MonthlyReportDTO> GetAll()
    {
        var ReportList = _monthlyReportReposity.GetAll();
        var DTOList = ReportList.Select(c => new MonthlyReportDTO
        {
            CreationDate = c.CreationDate,
            MonthName = c.MonthName,
            Subject = c.Subject,
            Title = c.Title,
            Context = c.Context,
            OwnerId = c.OwnerId,
            Id = c.Id
        }).ToList();
        
        return DTOList;
    }
}