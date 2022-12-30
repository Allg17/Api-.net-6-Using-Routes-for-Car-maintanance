using CarMaintanance.Model;
using System.Security.Cryptography.Xml;

namespace CarMaintanance.Repository
{
    public class ClientesRepository : RepositorioBase<Clientes>, IClientesRepository
    {
        public ClientesRepository(CarDbContext CarContext) : base(CarContext)
        {
        }
    }
}
