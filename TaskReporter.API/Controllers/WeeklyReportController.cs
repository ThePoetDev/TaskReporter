using Microsoft.AspNetCore.Mvc;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Controllers;

[ApiController]
public class WeeklyReportController
{
    private readonly IWeeklyReportService _weeklyReportService;

    public WeeklyReportController(IWeeklyReportService weeklyReportService)
    {
        _weeklyReportService = weeklyReportService;
    }

    [HttpGet("WeeklyGetById")]
    public WeeklyReportDTO GetById(int id)
    {
        return _weeklyReportService.GetById(id);
    }

    [HttpPost("WeeklyInsert")]
    public void Insert(WeeklyReportCreateDTO report)
    {
        _weeklyReportService.Insert(report);
    }

    [HttpDelete("WeeklyDelete")]
    public void Delete(int id)
    {
        _weeklyReportService.Delete(id);
    }

    [HttpPut("WeeklyUpdate")]
    public void Update(int id, WeeklyReportCreateDTO report)
    {
        _weeklyReportService.Update(id, report);
    }

    [HttpGet("WeeklyGetAll")]
    public List<WeeklyReport> GetAll()
    {
        return _weeklyReportService.GetAll();
    }
    
    
    
    
}