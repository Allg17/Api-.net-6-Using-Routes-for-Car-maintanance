using System.ComponentModel.DataAnnotations;

namespace CarMaintanance.Model
{
    public class PerfilesModulos : baseClass
    {
        [Key]
        public int ID { get; set; }
        public int ModuloID { get; set; }
        public virtual Modulos Modulos { get; set; }
        public int PerfilID { get; set; }
        public virtual Perfiles Perfil { get; set; }
    }
}
