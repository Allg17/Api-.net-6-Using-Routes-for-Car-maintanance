using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Repository
{
    public class RolesRepository : RepositorioBase<Roles>, IRoles
    {
        public RolesRepository(CarDbContext CarContext) : base(CarContext)
        {
        }

        public Roles GetRolesWithPerfiles()
        {
            return new Roles();
        }
    }
}
