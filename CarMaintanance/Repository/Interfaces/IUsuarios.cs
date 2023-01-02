using CarMaintanance.Model;

namespace CarMaintanance.Repository.Interfaces
{
    public interface IUsuarios : IBaseRepository<Usuarios>
    {
        Usuarios Get(string username, string clave);
    }
}
