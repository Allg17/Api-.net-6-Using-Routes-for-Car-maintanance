﻿using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Solicitudes
    {
        [Key]
        public int SolicitudID { get; set; }
        public string Descripcion { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public bool Completada { get; set; }
        public int UsuarioID { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual List<SolicitudesHijas> Detalle { get; set; }
        public virtual List<AreasDetalle> AreaDetalle { get; set; }
        public int FacturasID { get; set; }
        public virtual Facturas Factura { get; set; }
    }
}
