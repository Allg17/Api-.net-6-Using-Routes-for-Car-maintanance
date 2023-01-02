using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Repository
{
    public class RolesRepository : RepositorioBase<Roles>, IRoles
    {
        CarDbContext db;
        public RolesRepository(CarDbContext CarContext) : base(CarContext)
        {
            db = CarContext;
        }

        public Roles GetRolesWithPerfiles()
        {
            return new Roles();
        }
    }
}
