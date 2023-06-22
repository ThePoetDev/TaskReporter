using TaskReporter.Business.DTO;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Interfaces;

public interface IUserService
{
    UserDTO GetById(int id);
    void Insert(UserCreateDTO entity);
    void Delete(int id);
    void Update(UserDTO entity);
    List<User> GetAll();
}