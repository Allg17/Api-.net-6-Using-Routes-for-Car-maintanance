using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface IRoles : IBaseRepository<Roles>
    {
        Roles GetRolesWithPerfiles();
    }
}
