using TaskReporter.Business.DTO;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Interfaces;

public interface IDailyReportService
{
    DailyReportDTO GetById(int id);
    void Insert(DailyReportCreateDTO entity);
    void Delete(int id);
    void Update(int id, DailyReportCreateDTO entity);
    List<DailyReport> GetAll();
}