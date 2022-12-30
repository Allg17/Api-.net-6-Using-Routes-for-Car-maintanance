using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Perfiles
    {
        [Key]
        public int PerfilID { get; set; }
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public bool Crear_Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Ver { get; set; }
        public int AreaID { get; set; }
        public virtual Areas Area { get; set; }

        public int RolID { get; set; }
        public virtual Roles Rol { get; set; }
    }
}
