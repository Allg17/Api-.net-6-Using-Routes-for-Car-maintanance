using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class Areas
    {
        [Key]
        public int AreaID { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public virtual List<AreasDetalle> DetalleArea { get; set; }
        public int PerfilID { get; set; }
        public virtual Perfiles Perfil { get; set; }
    }
}
