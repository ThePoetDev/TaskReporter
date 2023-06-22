namespace EntityFramework.Interfaces;

public interface IGenericRepository<T> where T:class
{
    T FindById(int id);
    void Insert(T entity);
    void Delete(int id);
    void Update(T entity);
    List<T> GetAll();

}