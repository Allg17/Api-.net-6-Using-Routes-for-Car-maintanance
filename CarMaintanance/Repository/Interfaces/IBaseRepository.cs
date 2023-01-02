namespace CarMaintanance.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Save(T obj);
        int Delete(int Id);
        int Update(T obj);
    }
}
