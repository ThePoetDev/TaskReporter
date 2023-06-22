namespace TaskReporter.Business.DTO;

public class UserDTO : UserCreateDTO
{
    public int Id { get; set; }
}


public class UserCreateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
}