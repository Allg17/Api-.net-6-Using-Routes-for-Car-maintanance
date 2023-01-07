using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface IArea : IBaseRepository<Areas>
    {
        List<Areas> GetAreas(string valor, int limit);
    }
}
