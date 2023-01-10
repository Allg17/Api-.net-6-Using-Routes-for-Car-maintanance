using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Repository
{
    public class RecordatorioRepository : RepositorioBase<Recordatorios>, IRecordatorio
    {
        public RecordatorioRepository(CarDbContext CarContext) : base(CarContext)
        {
        }

        public List<Recordatorios> GetallRecordatorio()
        {
            return Db.Recordatorios.Include(x => x.Cliente).ToList();
        }
    }
}
