using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Recordatorios : baseClass
    {
        [Key]
        public int RecordatorioID { get; set; }
        public int ClienteID { get; set; }
        public DateTime FechaRecordatorio { get; set; }
        public bool Completado { get; set; }
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Observacion { get; set; }
        public virtual Clientes Cliente { get; set; }
    }
}
