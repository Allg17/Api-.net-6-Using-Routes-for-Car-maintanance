using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface IClientesRepository : IBaseRepository<Clientes>
    {
        Clientes GetClienteByCedula(string valor);

        List<Clientes> GetClientes(string valor, int limit);
    }
}
