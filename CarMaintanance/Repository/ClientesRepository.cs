using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;

namespace CarMaintanance.Repository
{
    public class ClientesRepository : RepositorioBase<Clientes>, IClientesRepository
    {
        public ClientesRepository(CarDbContext CarContext) : base(CarContext)
        {
         
        }

        public Clientes GetClienteByCedula(string valor)
        {
            return Db.Clientes.Where(x => x.Cedula==valor).FirstOrDefault();
        }

        public List<Clientes> GetClientes(string valor, int limit)
        {
            return Db.Clientes.Where(x => x.Nombre.Contains(valor) || x.Cedula.Contains(valor)).Take(limit).ToList();
        }
    }
}
