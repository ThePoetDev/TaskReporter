using EntityFramework.EntityFrameworkCore;
using EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Repositories;

public class MonthlyReportRepository : IMonthlyReportReposity
{
    private readonly TaskReporterDBContext _dbContext;
    private readonly DbSet<MonthlyReport> _dbSet;

    public MonthlyReportRepository(TaskReporterDBContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<MonthlyReport>();
    }

    public MonthlyReport FindById(int id)
    {
        return _dbSet.FirstOrDefault(f => f.Id == id);
    }

    public void Insert(MonthlyReport entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _dbSet.Remove(_dbSet.FirstOrDefault(f => f.Id == id));
        _dbContext.SaveChanges();
    }

    public void Update(int id, MonthlyReport entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }

    public List<MonthlyReport> GetAll()
    {
        return _dbSet.AsQueryable().ToList();
    }
}