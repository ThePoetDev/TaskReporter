using EntityFramework.Interfaces;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public UserDTO GetById(int id)
    {
        var user = _userRepository.FindById(id);
        var userDTO = new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname
        };

        return userDTO;
    }

    public void Insert(UserCreateDTO entity)
    {
        var user = new User
        {
            Name = entity.Name,
            Surname = entity.Surname
        };
        
        _userRepository.Insert(user);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }

    public void Update(UserDTO entity)
    {
        var user = _userRepository.FindById(entity.Id);

        if (user == null)
        {
            throw new Exception("No data was found in the database with this ID.");
        }

        user.Name = entity.Name;
        user.Surname = entity.Surname;
        
        _userRepository.Update(user);
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }
}