using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Repository
{
    public class AreaRepository : RepositorioBase<Areas>, IArea
    {
        public AreaRepository(CarDbContext CarContext) : base(CarContext)
        {
        }
        public List<Areas> GetAreas(string valor, int limit)
        {
            return Db.Areas.Where(x => x.Nombre.Contains(valor) && x.AreaVehicular).Take(limit).ToList();
        }
    }
}
