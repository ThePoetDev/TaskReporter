using TaskReporter.Business.DTO;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Interfaces;

public interface IMonthlyReportService
{
    MonthlyReportDTO GetById(int id);
    void Insert(MonthlyReportCreateDTO entity);
    void Delete(int id);
    void Update(int id, MonthlyReportCreateDTO entity);
    List<MonthlyReport> GetAll();
}