﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintanance.Model
{
    public class Perfiles
    {
        [Key]
        public int PerfilID { get; set; }
        public int UsuarioID { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        public int AreaID { get; set; }
        public virtual Areas Area { get; set; }
        public virtual List<PerfilesRoles> PefilesRoles { get; set; }

        public virtual List<Modulos> ModulosDetalle { get; set; }
    }
}
