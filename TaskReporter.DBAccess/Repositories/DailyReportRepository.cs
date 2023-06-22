using EntityFramework.EntityFrameworkCore;
using EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Repositories;

public class DailyReportRepository : IDailyReportRepository
{
    private readonly TaskReporterDBContext _dbContext;
    private readonly DbSet<DailyReport> _dbSet;

    public DailyReportRepository(TaskReporterDBContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<DailyReport>();
    }

    public DailyReport FindById(int id)
    {
        return _dbSet.FirstOrDefault(f => f.Id == id);
    }

    public void Insert(DailyReport entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _dbSet.Remove(_dbSet.FirstOrDefault(f => f.Id == id));
        _dbContext.SaveChanges();
    }

    public void Update(DailyReport entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }

    public List<DailyReport> GetAll()
    {
        return _dbSet.Include(r => r.Owner).ToList();
    }
}