using System.ComponentModel.DataAnnotations;
using CarMaintanance.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarMaintanance.Model
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreado { get; set; }
        public int UsuarioID { get; set; }
        public virtual List<Recordatorios> RecordatorioList { get; set; }
        public virtual List<Solicitudes> DetalleSolicitud { get; set; }
        public virtual List<Facturas> DetalleFacturas { get; set; }
    }
}
