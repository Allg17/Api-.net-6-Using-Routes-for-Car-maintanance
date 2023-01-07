using CarMaintanance.Model;
using CarMaintanance.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Repository
{
    public class UsuarioRepository : RepositorioBase<Usuarios>, IUsuarios
    {
        public UsuarioRepository(CarDbContext CarContext) : base(CarContext)
        {
        }

        public Usuarios Get(string username, string clave)
        {
            return Db.Usuarios
                .Include(x => x.Rol)
                .ThenInclude(x=>x.PefilesRoles)
                .ThenInclude(x=>x.Perfil)
                .ThenInclude(x=>x.ModulosDetalle)
                .Where(x => x.User == username && x.Clave == clave)
                .FirstOrDefault();
        }
    }
}
