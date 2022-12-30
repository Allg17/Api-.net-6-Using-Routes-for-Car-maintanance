using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Recordatorios
    {
        [Key]
        public int RecordatorioID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public bool Completado { get; set; }
        public int UsuarioID { get; set; }
        public virtual Clientes Cliente { get; set; }
    }
}
