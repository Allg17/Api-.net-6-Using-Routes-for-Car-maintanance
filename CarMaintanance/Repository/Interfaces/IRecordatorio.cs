using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface IRecordatorio : IBaseRepository<Recordatorios>
    {
        List<Recordatorios> GetallRecordatorio();
    }
}
