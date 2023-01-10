using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarMaintanance.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarMaintanance.Model
{
    public class Clientes : baseClass
    {
        [Key]
        public int ClienteID { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Telefono { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Correo { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Cedula { get; set; }
        public virtual List<Recordatorios> RecordatorioList { get; set; }
        public virtual List<Solicitudes> DetalleSolicitud { get; set; }
        public virtual List<Facturas> DetalleFacturas { get; set; }
    }
}
