using EntityFramework.EntityFrameworkCore;
using EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Repositories;

public class WeeklyReportRepository : IWeeklyReportReposity
{
    private readonly TaskReporterDBContext _dbContext;
    private readonly DbSet<WeeklyReport> _dbSet;

    public WeeklyReportRepository(TaskReporterDBContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<WeeklyReport>();
    }

    public WeeklyReport FindById(int id)
    {
        return _dbSet.FirstOrDefault(f => f.Id == id);
    }

    public void Insert(WeeklyReport entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _dbSet.Remove(_dbSet.FirstOrDefault(f => f.Id == id));
        _dbContext.SaveChanges();
    }

    public void Update(int id, WeeklyReport entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }

    public List<WeeklyReport> GetAll()
    {
        return _dbSet.AsQueryable().ToList();
    }
}