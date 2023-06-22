using EntityFramework.EntityFrameworkCore;
using EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskReporterDBContext _dbContext;
    private readonly DbSet<User> _dbSet;

    public UserRepository(TaskReporterDBContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<User>();
    }

    public User FindById(int id)
    {
        return _dbSet.FirstOrDefault(f => f.Id == id);
    }

    public void Insert(User entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _dbSet.Remove(_dbSet.FirstOrDefault(f => f.Id == id));
        _dbContext.SaveChanges();
    }

    public void Update(User entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }

    public List<User> GetAll()
    {
        return _dbSet.AsQueryable().ToList();
    }
}