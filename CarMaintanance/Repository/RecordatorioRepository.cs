using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Repository
{
    public class RecordatorioRepository : RepositorioBase<Recordatorios>, IRecordatorio
    {
        public RecordatorioRepository(CarDbContext CarContext) : base(CarContext)
        {
        }
    }
}
