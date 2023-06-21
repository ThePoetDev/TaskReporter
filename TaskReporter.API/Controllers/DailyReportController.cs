using Microsoft.AspNetCore.Mvc;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Controllers;

[ApiController]
public class DailyReportController
{
    private readonly IDailyReportService _dailyReportService;

    public DailyReportController(IDailyReportService dailyReportService)
    {
        _dailyReportService = dailyReportService;
    }

    [HttpGet("DailyGetById")]
    public DailyReportDTO GetById(int id)
    {
        return _dailyReportService.GetById(id);
    }

    [HttpPost("DailyInsert")]
    public void Insert(DailyReportCreateDTO report)
    {
        _dailyReportService.Insert(report);
    }

    [HttpDelete("DailyDelete")]
    public void Delete(int id)
    {
        _dailyReportService.Delete(id);
    }
    
    [HttpPut("DailyUpdate")]
    public void Update(int id, DailyReportCreateDTO report)
    {
        _dailyReportService.Update(id, report);
    }

    [HttpGet("DailyGetAll")]
    public List<DailyReport> GetAll()
    {
        return _dailyReportService.GetAll();
    }
    


}