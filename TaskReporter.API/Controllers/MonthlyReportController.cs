using Microsoft.AspNetCore.Mvc;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Controllers;

[ApiController]
public class MonthlyReportController
{
    private readonly IMonthlyReportService _monthlyReportService;

    public MonthlyReportController(IMonthlyReportService monthlyReportService)
    {
        _monthlyReportService = monthlyReportService;
    }

    [HttpGet("MonthlyGetById")]
    public MonthlyReportDTO GetById(int id)
    {
        return _monthlyReportService.GetById(id);
    }

    [HttpPost("MonthlyInsert")]
    public void Insert(MonthlyReportCreateDTO report)
    {
        _monthlyReportService.Insert(report);
    }

    [HttpDelete("MonthlyDelete")]
    public void Delete(int id)
    {
        _monthlyReportService.Delete(id);
    }

    [HttpPut("MonthlyUpdate")]
    public void Update(MonthlyReportDTO report)
    {
        _monthlyReportService.Update(report);
    }

    [HttpGet("MonthlyGetAll")]
    public List<MonthlyReport> GetAll()
    {
        return _monthlyReportService.GetAll();
    }
    
}