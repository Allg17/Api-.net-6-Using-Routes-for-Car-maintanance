using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Roles : baseClass
    {
        [Key]
        public int RolID { get; set; }
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        public virtual List<Usuarios> Usuario { get; set; }
        public virtual List<PerfilesRoles> PefilesRoles { get; set; }
    }
}
