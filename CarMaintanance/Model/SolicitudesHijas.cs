using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class SolicitudesHijas
    {
        [Key]
        public int SolicitudHijaID { get; set; }
        public int SolicitudID { get; set; }
        public DateTime Fecha { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        public float Precio { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public bool Facturada { get; set; }
        public int UsuarioID { get; set; }
        public int AreaDetalleID { get; set; }
        public virtual Solicitudes Solicitud { get; set; }
        public virtual AreasDetalle AreaDetalle { get; set; }
    }
}
