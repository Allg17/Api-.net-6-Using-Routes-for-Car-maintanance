using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class AreasDetalle
    {
        [Key]
        public int AreaDetalleID { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }
        public int SolicitudID { get; set; }
        public int AreaID { get; set; }
        public virtual Solicitudes Solicitud { get; set; }
        public virtual Areas Area { get; set; }
        public virtual List<SolicitudesHijas> DetalleHijas { get; set; }
    }
}
