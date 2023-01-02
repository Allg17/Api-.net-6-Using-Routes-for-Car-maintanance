using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Modulos
    {
        [Key]
        public int ModuloId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        public bool Crear_Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Ver { get; set; }
        public int PerfilID { get; set; }
        public virtual Perfiles Perfil { get; set; }
    }
}
