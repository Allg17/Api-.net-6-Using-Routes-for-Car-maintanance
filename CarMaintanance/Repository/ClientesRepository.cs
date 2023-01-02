using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;

namespace CarMaintanance.Repository
{
    public class ClientesRepository : RepositorioBase<Clientes>, IClientesRepository
    {
        CarDbContext _db;
        public ClientesRepository(CarDbContext CarContext) : base(CarContext)
        {
            _db = CarContext;
        }

        public Clientes GetClienteByCedula(string valor)
        {
            //Func<Clientes, bool> expression = null;

            //switch (opcion)
            //{
            //    case 1:
            //        expression = s => s.Nombre.cont valor;
            //        break;

            //    case 2:
            //        expression = s => s.Telefono == valor;
            //        break;
            //    case 3:
            //        expression = s => s.Correo == valor;
            //        break;
            //}
            return Db.Clientes.Where(x => x.Cedula==valor).FirstOrDefault();
        }
    }
}
