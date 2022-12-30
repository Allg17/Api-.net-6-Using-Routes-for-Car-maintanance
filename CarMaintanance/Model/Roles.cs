using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }
        public int PerfilID { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public virtual Perfiles Perfil { get; set; }
    }
}
