using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Facturas : baseClass
    {
        [Key]
        public int FacturasID { get; set; }
        public int SolicitudID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Comentario { get; set; }
        public bool Completada { get; set; }
        public int UsuarioID { get; set; }
        public virtual Solicitudes Solicitud { get; set; }
    }
}
