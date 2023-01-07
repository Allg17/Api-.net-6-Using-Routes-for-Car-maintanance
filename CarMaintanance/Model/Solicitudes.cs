using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Solicitudes
    {
        [Key]
        public int SolicitudID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Descripcion { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public bool Completada { get; set; }
        public bool Facturada { get; set; }
        public bool Despachada { get; set; }
        public int UsuarioID { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual List<SolicitudesHijas> Detalle { get; set; }
        public int FacturasID { get; set; }
        public virtual Facturas Factura { get; set; }
    }
}
