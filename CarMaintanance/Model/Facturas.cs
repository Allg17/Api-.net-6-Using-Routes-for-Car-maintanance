﻿using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Facturas
    {
        [Key]
        public int FacturasID { get; set; }
        public int ClienteID { get; set; }
        public int SolicitudID { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public float Total { get; set; }
        public bool Completada { get; set; }
        public int UsuarioID { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual Solicitudes Solicitud { get; set; }
    }
}