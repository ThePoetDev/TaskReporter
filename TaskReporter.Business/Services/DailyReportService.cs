﻿using EntityFramework.Interfaces;
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
            Context = report.Context,
            OwnerId = report.OwnerId
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
            Context = entity.Context,
            OwnerId = entity.OwnerId
        };
        
        _dailyReportRepository.Insert(report);
        
    }

    public void Delete(int id)
    {
        _dailyReportRepository.Delete(id);
    }

    public void Update(DailyReportDTO entity)
    {
        var report = _dailyReportRepository.FindById(entity.Id);

        if (report == null)
        {
            throw new Exception("No data was found in the database with this ID.");
        }
        
        report.CreationDate = entity.CreationDate;
        report.Subject = entity.Subject;
        report.Title = entity.Title;
        report.Context = entity.Context;
        report.OwnerId = entity.OwnerId;
        
        _dailyReportRepository.Update(report);
    }

    public List<DailyReportDTO> GetAll()
    {
        var ReportList = _dailyReportRepository.GetAll();
        var DTOList = ReportList.Select(c => new DailyReportDTO
        {
            CreationDate = c.CreationDate,
            Subject = c.Subject,
            Title = c.Title,
            Context = c.Context,
            OwnerId = c.OwnerId,
            Id = c.Id
        }).ToList();
        
        return DTOList;
    }
}