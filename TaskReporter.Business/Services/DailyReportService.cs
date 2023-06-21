using EntityFramework.Interfaces;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Services;

public class DailyReportService : IDailyReportService
{
    private readonly IDailyReportRepository _dailyReportRepository;

    public DailyReportService(IDailyReportRepository dailyReportRepository)
    {
        _dailyReportRepository = dailyReportRepository;
    }

    public DailyReportDTO GetById(int id)
    {
        var report = _dailyReportRepository.FindById(id);
        var reportDTO = new DailyReportDTO
        {
            Id = report.Id,
            CreationDate = report.CreationDate,
            Subject = report.Subject,
            Title = report.Title,
            Context = report.Context
        };

        return reportDTO;
    }
    
    public void Insert(DailyReportCreateDTO entity)
    {
        var report = new DailyReport
        {
            CreationDate = entity.CreationDate,
            Subject = entity.Subject,
            Title = entity.Title,
            Context = entity.Context
        };
        
        _dailyReportRepository.Insert(report);
        
    }

    public void Delete(int id)
    {
        _dailyReportRepository.Delete(id);
    }

    public void Update(int id, DailyReportCreateDTO entity)
    {
        var report = _dailyReportRepository.FindById(id);

        if (report == null)
        {
            throw new Exception("No data was found in the database with this ID.");
        }

        report.CreationDate = entity.CreationDate;
        report.Subject = entity.Subject;
        report.Title = entity.Title;
        report.Context = entity.Context;
        
        _dailyReportRepository.Update(id, report);
    }

    public List<DailyReport> GetAll()
    {
        return _dailyReportRepository.GetAll();
    }
}