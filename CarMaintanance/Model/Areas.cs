﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Areas : baseClass
    {
        [Key]
        public int AreaID { get; set; }
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        public bool AreaVehicular { get; set; }
        public virtual List<SolicitudesHijas> Hijas { get; set; }
        public virtual List<Perfiles> Perfil { get; set; }
    }
}
