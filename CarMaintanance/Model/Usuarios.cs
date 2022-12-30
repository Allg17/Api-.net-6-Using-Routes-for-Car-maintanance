using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int RolID { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
        public virtual Roles Rol { get; set; }
    }
}
