using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Usuarios : baseClass
    {
        [Key]
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Nombre { get; set; }
        public int RolID { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
        public virtual Roles Rol { get; set; }
    }
}
