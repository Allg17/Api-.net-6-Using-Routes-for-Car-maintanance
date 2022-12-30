using CarMaintanance.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CarMaintanance.Repository
{
    public class RepositorioBase<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public CarDbContext Db { get; set; }
        public RepositorioBase(CarDbContext CarContext)
        {
            Db = CarContext;
        }
        public int Delete(int Id)
        {
            Db.Set<TEntity>().Remove(GetById(Id));
            return Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public int Save(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            return Db.SaveChanges();
        }

        public int Update(TEntity obj)
        {

            Db.Entry(obj).State = EntityState.Modified;
            return Db.SaveChanges();
        }
        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

    }
}
