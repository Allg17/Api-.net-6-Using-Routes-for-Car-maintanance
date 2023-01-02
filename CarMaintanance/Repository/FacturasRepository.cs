using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;

namespace CarMaintanance.Repository
{
    public class FacturasRepository : RepositorioBase<Facturas>, IFacturas
    {
        public FacturasRepository(CarDbContext CarContext) : base(CarContext)
        {
        }
    }
}
