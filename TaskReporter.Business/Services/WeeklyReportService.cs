using EntityFramework.Interfaces;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Services;

public class WeeklyReportService : IWeeklyReportService
{
    private readonly IWeeklyReportRepository _weeklyReportRepository;

    public WeeklyReportService(IWeeklyReportRepository weeklyReportRepository)
    {
        _weeklyReportRepository = weeklyReportRepository;
    }
    
    public WeeklyReportDTO GetById(int id)
    {
        var report = _weeklyReportRepository.FindById(id);
        var reportDTO = new WeeklyReportDTO
        {
            CreationDate = report.CreationDate,
            StartDate = report.StartDate,
            EndDate = report.EndDate,
            Subject = report.Subject,
            Title = report.Title,
            Context = report.Context,
            OwnerId = report.OwnerId

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
            EndDate = entity.EndDate,
            OwnerId = entity.OwnerId
        };
        
        _weeklyReportRepository.Insert(report);
    }

    public void Delete(int id)
    {
        _weeklyReportRepository.Delete(id);
    }

    public void Update(WeeklyReportDTO entity)
    {
        var report = _weeklyReportRepository.FindById(entity.Id);

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
        report.OwnerId = entity.OwnerId;

        _weeklyReportRepository.Update(report);
    }

    public List<WeeklyReportDTO> GetAll()
    {
        var ReportList = _weeklyReportRepository.GetAll();
        var DTOList = ReportList.Select(c => new WeeklyReportDTO
        {
            CreationDate = c.CreationDate,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
            Subject = c.Subject,
            Title = c.Title,
            Context = c.Context,
            OwnerId = c.OwnerId,
            Id = c.Id
        }).ToList();
        
        return DTOList;
    }
}